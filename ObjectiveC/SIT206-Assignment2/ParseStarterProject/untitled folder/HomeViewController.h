//
//  HomeViewController.h
//  Assignment2
//
//  Created by Matt on 24/05/2015.
//
//

#import <UIKit/UIKit.h>
#import "AFDropdownNotification.h"

@interface HomeViewController : UIViewController <AFDropdownNotificationDelegate>
-(void)noConnection;
@end
