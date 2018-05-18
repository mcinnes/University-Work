//
//  EventInfoViewController.h
//  Assignment2
//
//  Created by Matt on 26/05/2015.
//
//

#import <UIKit/UIKit.h>
#import <Parse/Parse.h>
#import <MapKit/MapKit.h>
@interface EventInfoViewController : UIViewController <MKMapViewDelegate>
@property (nonatomic, retain) PFObject *event;
@property (weak, nonatomic) IBOutlet MKMapView *mapView;
@property (weak, nonatomic) IBOutlet UILabel *titleLabel;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UITextView *textView;
@property (weak, nonatomic) IBOutlet UIButton *attendingButton;

@end
