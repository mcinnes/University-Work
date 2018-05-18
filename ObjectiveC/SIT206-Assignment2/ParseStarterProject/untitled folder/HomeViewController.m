//
//  HomeViewController.m
//  Assignment2
//
//  Created by Matt on 24/05/2015.
//
//

#import "HomeViewController.h"
#import <Parse/Parse.h>
#import "MYBlurIntroductionView.h"
#import "MYIntroductionPanel.h"
#import <QuartzCore/QuartzCore.h>
@interface HomeViewController () <MYIntroductionDelegate>
@property (nonatomic, strong) AFDropdownNotification *notification;

@end

@implementation HomeViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    _notification = [[AFDropdownNotification alloc] init];
    _notification.notificationDelegate = self;
    NSUserDefaults *defaults = [NSUserDefaults standardUserDefaults];
    if ([[defaults objectForKey:@"firstRun"] isEqualToString:@"yes"]) {
        
    }
    else {
        [self showIntro];
        [defaults setObject:@"yes" forKey:@"firstRun"];
    }
    
    [self login];
    self.view.backgroundColor = [UIColor colorWithPatternImage:[UIImage imageNamed:@"deakin.jpg"]];

    
    // Do any additional setup after loading the view.
}
-(void)viewWillAppear:(BOOL)animated {
    self.navigationController.navigationBarHidden = YES;

}
-(void)viewDidAppear:(BOOL)animated {

}
-(void)noConnection {
    _notification.titleText = @"No internet connection";
    _notification.subtitleText = @"This app needs internet to function";
    _notification.dismissOnTap = YES;
    
    [_notification presentInView:self.view withGravityAnimation:YES];
}

-(void)showIntro {
    
    self.navigationController.navigationBar.hidden = true;
    
    //Introduction screen setup
    //Using The MYIntroductionPanel Library
    //Create Panel 1
    MYIntroductionPanel *panel1 = [[MYIntroductionPanel alloc] initWithFrame:CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height) title:@"Welcome to Deakin Open Day" description:@"This app is designed to guide you through your open day experience at Deakin" image:[UIImage imageNamed:@"HeaderImage.png"]];
    
//Create Panel 2
    MYIntroductionPanel *panel2 = [[MYIntroductionPanel alloc] initWithFrame:CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height) title:@"Use the map" description:@"Use the map to find points of interest around campus. Points of interest include: Cafes, Libraries, Lecture Halls, and Computer Labs" image:[UIImage imageNamed:@"ForkImage.png"]];
    
    
    //Add panels to an array
    NSArray *panels = @[panel1, panel2];
    
    //Create the introduction view and set its delegate
    MYBlurIntroductionView *introductionView = [[MYBlurIntroductionView alloc] initWithFrame:CGRectMake(0, 0, self.view.frame.size.width, self.view.frame.size.height)];
    introductionView.delegate = self;
    introductionView.BackgroundImageView.image = [UIImage imageNamed:@"deakin.jpg"];
    [introductionView setBackgroundColor:[UIColor colorWithRed:90.0f/255.0f green:175.0f/255.0f blue:113.0f/255.0f alpha:0.65]];
    //introductionView.LanguageDirection = MYLanguageDirectionRightToLeft;
    
    //Build the introduction with desired panels
    [introductionView buildIntroductionWithPanels:panels];
    
    //Add the introduction to your view
    [self.view addSubview:introductionView];
}

-(void)introduction:(MYBlurIntroductionView *)introductionView didFinishWithType:(MYFinishType)finishType {
    [self showNotification:self];
    self.navigationController.navigationBar.hidden = false;
}

-(void)login {
    //In production this would be set as a device based user. But we needed the data out of it for an example
    
    [PFUser logInWithUsernameInBackground:@"test" password:@"indiana1"
                                    block:^(PFUser *user, NSError *error) {
                                        if (user) {
                                            // Do stuff after successful login.
                                        } else {
                                            // The login failed. Check error to see why.
                                        }
                                    }];
}

-(IBAction)showNotification:(id)sender {
    //Query server for the latest messages
    PFQuery *query = [PFQuery queryWithClassName:@"Message"];
    [query whereKey:@"Message" equalTo:@"message"];
    [query findObjectsInBackgroundWithBlock:^(NSArray *objects, NSError *error) {
        if (!error) {
            for (PFObject *object in objects) {
                
                _notification.titleText = object[@"Title"];
                _notification.subtitleText = object[@"Body"];;
                _notification.image = [UIImage imageNamed:@"update"];
                _notification.dismissOnTap = YES;
                
                [_notification presentInView:self.view withGravityAnimation:YES];
                
                [_notification listenEventsWithBlock:^(AFDropdownNotificationEvent event) {
                    
                    switch (event) {
                        case AFDropdownNotificationEventTopButton:
                            // Top button
                            break;
                            
                        case AFDropdownNotificationEventBottomButton:
                            // Bottom button
                            break;
                            
                        case AFDropdownNotificationEventTap:
                            // Tap
                            break;
                            
                        default:
                            break;
                    }
                }];
            }
        } else {
            // Log details of the failure
            NSLog(@"Error: %@ %@", error, [error userInfo]);
        }
    }];
    
    
    NSLog(@"show notification");
}

//Notification delegates
-(void)dropdownNotificationTopButtonTapped {
    
    NSLog(@"Top button tapped");
    
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Top button tapped" message:@"Hooray! You tapped the top button" delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil];
    [alert show];
    
    [_notification dismissWithGravityAnimation:YES];
}

-(void)dropdownNotificationBottomButtonTapped {
    
    NSLog(@"Bottom button tapped");
    
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Bottom button tapped" message:@"Hooray! You tapped the bottom button" delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil];
    [alert show];
    
    [_notification dismissWithGravityAnimation:YES];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}
-(void)viewDidDisappear:(BOOL)animated {
    self.navigationController.navigationBarHidden = NO;
}

- (IBAction)openFacebook:(id)sender {
 
    //Open the deakin facebook page
    [[UIApplication sharedApplication] openURL:[NSURL URLWithString:@"https://www.facebook.com/DeakinUniversity"]];

}

- (IBAction)openTwitter:(id)sender {
    //open the deakin twitter
     [[UIApplication sharedApplication] openURL:[NSURL URLWithString:@"https://twitter.com/Deakin"]];
}




@end
