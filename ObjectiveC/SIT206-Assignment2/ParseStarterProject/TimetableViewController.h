//
//  TimetableViewController.h
//  Assignment2
//
//  Created by Matt on 26/05/2015.
//
//

#import <UIKit/UIKit.h>

@interface TimetableViewController : UIViewController <UITableViewDelegate, UITableViewDataSource>

@property (weak, nonatomic) IBOutlet UITableView *tableView;

@end
