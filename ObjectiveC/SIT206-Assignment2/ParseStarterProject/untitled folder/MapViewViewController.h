//
//  MapViewViewController.h
//  Assignment2
//
//  Created by Matt on 24/05/2015.
//
//

#import <UIKit/UIKit.h>
#import <MapKit/MapKit.h> 
#import <CoreLocation/CoreLocation.h>


@interface MapViewViewController : UIViewController <MKMapViewDelegate, CLLocationManagerDelegate>
@property (weak, nonatomic) IBOutlet MKMapView *mapView;
@property (weak, nonatomic) IBOutlet UIPickerView *picker;
@property (retain, nonatomic) NSString *condition;
@end
