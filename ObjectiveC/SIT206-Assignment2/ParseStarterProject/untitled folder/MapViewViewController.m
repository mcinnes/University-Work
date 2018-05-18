//
//  MapViewViewController.m
//  Assignment2
//
//  Created by Matt on 24/05/2015.
//
//

#import "MapViewViewController.h"
#import <Parse/Parse.h>
#import "PAWPost.h"
#define IS_OS_8_OR_LATER ([[[UIDevice currentDevice] systemVersion] floatValue] >= 8.0)

@interface MapViewViewController ()
@property (nonatomic, strong) CLLocationManager *locationManager;
@property (nonatomic, strong) CLLocation *currentLocation;

@property (nonatomic, strong) MKCircle *circleOverlay;
@property (nonatomic, strong) NSMutableArray *annotations;
@property (nonatomic, assign) BOOL mapPinsPlaced;
@property (nonatomic, assign) BOOL mapPannedSinceLocationUpdate;
@property (nonatomic, strong) NSMutableArray *allPosts;

@end

@implementation MapViewViewController {
    NSArray *_pickerData;
    NSString *condition;
}
@synthesize condition;
- (void)viewDidLoad {
    [super viewDidLoad];
    //Setup location manager and map view
    _mapView.delegate = self;
    self.locationManager = [[CLLocationManager alloc] init];
    self.locationManager.delegate = self;
#ifdef __IPHONE_8_0
    if(IS_OS_8_OR_LATER) {
        // Use one or the other, not both. Depending on what you put in info.plist
        [self.locationManager requestWhenInUseAuthorization];
        //[self.locationManager requestAlwaysAuthorization];
    }
#endif
    [self.locationManager startUpdatingLocation];
    CLLocation *location = [_locationManager location]; //Our current location

    CLLocationCoordinate2D startCoord = [location coordinate];
    //Move mapview to current position
    MKCoordinateRegion adjustedRegion = [_mapView regionThatFits:MKCoordinateRegionMakeWithDistance(startCoord, 200, 200)];
    [_mapView setRegion:adjustedRegion animated:YES];
    [_mapView setMapType:MKMapTypeSatellite];
    [_mapView setZoomEnabled:YES];
    [_mapView setScrollEnabled:YES];
    _mapView.showsUserLocation = YES;

    [self queryForAllPostsNearLocation:self.locationManager.location withNearbyDistance:20];
    
    UIBarButtonItem *flipButton = [[UIBarButtonItem alloc]
                                   initWithTitle:@"Options"
                                   style:UIBarButtonItemStyleBordered
                                   target:self
                                   action:@selector(showOptions)];
    self.navigationItem.rightBarButtonItem = flipButton;    // Do any additional setup after loading the view.
    
  //  self.title = [NSString stringWithFormat:(@"%@",[_locationManager location])];
}

-(void)showOptions{
    
    [self performSegueWithIdentifier:@"option" sender:self];
}



- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    
    [self.navigationController setNavigationBarHidden:NO animated:animated];
    
    [self.locationManager startUpdatingLocation];
}

- (void)viewDidDisappear:(BOOL)animated {
    [super viewDidDisappear:animated];
    NSLog(@"%@", condition);
    [self.locationManager stopUpdatingLocation];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}
#pragma mark Fetch map pins

- (void)queryForAllPostsNearLocation:(CLLocation *)currentLocation withNearbyDistance:(CLLocationAccuracy)nearbyDistance {
    PFQuery *query = [PFQuery queryWithClassName:@"Locations"];
    
    if (currentLocation == nil) {
        NSLog(@"%s got a nil location!", __PRETTY_FUNCTION__);
    }
    
    
    //This is not working currently in this project. It stop the app from querying the server and redownloading every result.
    //If this was a production ready app this would need to be fixed
    // If no objects are loaded in memory, we look to the cache first to fill the table
    // and then subsequently do a query against the network.
  //  if ([self.allPosts count] == 0) {
   //     query.cachePolicy = kPFCachePolicyCacheThenNetwork;
   // }
    
    
    // Query for posts sort of kind of near our current location.
    PFGeoPoint *point = [PFGeoPoint geoPointWithLatitude:currentLocation.coordinate.latitude longitude:currentLocation.coordinate.longitude];
    [query whereKey:@"coordinates" nearGeoPoint:point withinKilometers:1];
    
    if (condition == nil) {
    } else {
    [query whereKey:@"type" equalTo:condition];
    }

    query.limit = 20;
    
    [query findObjectsInBackgroundWithBlock:^(NSArray *objects, NSError *error) {
        if (error) {
            NSLog(@"error in geo query!"); // todo why is this ever happening?
        } else {
            //Setup new events to be added
            NSMutableArray *newPosts = [[NSMutableArray alloc] initWithCapacity:20];
            NSMutableArray *allNewPosts = [[NSMutableArray alloc] initWithCapacity:[objects count]];
            for (PFObject *object in objects) {
                PAWPost *newPost = [[PAWPost alloc] initWithPFObject:object];
                [allNewPosts addObject:newPost];
                if (![_allPosts containsObject:newPost]) {
                    [newPosts addObject:newPost];
                }
            }
            
            //Setup the events to be removed
            NSMutableArray *postsToRemove = [[NSMutableArray alloc] initWithCapacity:20];
            for (PAWPost *currentPost in _allPosts) {
                if (![allNewPosts containsObject:currentPost]) {
                    [postsToRemove addObject:currentPost];
                }
            }
          
            for (PAWPost *newPost in newPosts) {
                CLLocation *objectLocation = [[CLLocation alloc] initWithLatitude:newPost.coordinate.latitude
                                                                        longitude:newPost.coordinate.longitude];
                CLLocationDistance distanceFromCurrent = [currentLocation distanceFromLocation:objectLocation];
                [newPost setTitleAndSubtitleOutsideDistance:( distanceFromCurrent > nearbyDistance ? YES : NO )];
                newPost.animatesDrop = self.mapPinsPlaced;
            }
            
            //Remove events not near us and add new ones near us
            [self.mapView removeAnnotations:postsToRemove];
            [self.mapView addAnnotations:newPosts];
            
            [_allPosts addObjectsFromArray:newPosts];
            [_allPosts removeObjectsInArray:postsToRemove];
            
            self.mapPinsPlaced = YES;
            
            NSLog(@"%@", newPosts);
        }
    }];
}

- (NSString *)deviceLocation {
    return [NSString stringWithFormat:@"latitude: %f longitude: %f", self.locationManager.location.coordinate.latitude, self.locationManager.location.coordinate.longitude];
}
- (NSString *)deviceLat {
    return [NSString stringWithFormat:@"%f", self.locationManager.location.coordinate.latitude];
}
- (NSString *)deviceLon {
    return [NSString stringWithFormat:@"%f", self.locationManager.location.coordinate.longitude];
}
- (NSString *)deviceAlt {
    return [NSString stringWithFormat:@"%f", self.locationManager.location.altitude];
}



@end
