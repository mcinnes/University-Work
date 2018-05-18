//
//  EventInfoViewController.m
//  Assignment2
//
//  Created by Matt on 26/05/2015.
//
//

#import "EventInfoViewController.h"

@implementation EventInfoViewController {
    bool *going;
}
@synthesize event, titleLabel, timeLabel, mapView, textView, attendingButton;
- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.title =  event[@"Name"];

    [titleLabel setText:event[@"Name"]];
    [timeLabel setText:[NSString stringWithFormat:@"%@", event[@"Time"]]];
    [textView setText:event[@"Description"]];
    
    
   // PFGeoPoint *location = [event objectForKey:@"Location"];
    
  //  CLLocationCoordinate2D coordinate = CLLocationCoordinate2DMake(location.latitude, location.longitude);
    
   // MKCoordinateRegion viewRegion = MKCoordinateRegionMakeWithDistance(coordinate, 0.5*1609.344, 0.5*1609.344);
    //[mapView setRegion:viewRegion animated:YES];

    //If the user is attending we change the button
    NSString *attendingList;

    attendingList = [[PFUser currentUser]objectForKey:@"attending"];

    NSRange searchResult = [attendingList rangeOfString:event.objectId];
    if (searchResult.location == NSNotFound) {
        attendingButton.backgroundColor = [UIColor greenColor];
        attendingButton.titleLabel.text = @"Attend";

    } else {
        attendingButton.backgroundColor = [UIColor redColor];
        attendingButton.titleLabel.text = @"Cancel Attendance";
        going = true;
    }
    
    
    
}

//Updating the list of attendance
- (IBAction)attending:(id)sender {
    NSString *attendingList;
    PFUser *currentUser = [PFUser currentUser];
    
    attendingList = [[PFUser currentUser]objectForKey:@"attending"];
    NSLog(@"attend %@", attendingList);

    if (!going) {
        attendingList=[attendingList stringByAppendingString:[NSString stringWithFormat:@"%@-", event.objectId]];

    } else {
        
        NSString *removalString = [NSString stringWithFormat:@"%@-", event.objectId];
        
        NSString *attendingList = [attendingList stringByReplacingOccurrencesOfString:removalString withString:@""];

    }
    NSLog(@"%@", attendingList);
    
    [currentUser save];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


@end
