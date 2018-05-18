//
//  TimetableViewController.m
//  Assignment2
//
//  Created by Matt on 26/05/2015.
//
//

#import "TimetableViewController.h"
#import <Parse/Parse.h>
@implementation TimetableViewController {
    NSMutableArray *timetable;

}

-(void)viewDidLoad{
    [super viewDidLoad];
    timetable = [[NSMutableArray alloc]init]; //Setup array
    
    //All timetable events are saved in the user profile as a string seperated by '-', it was not possible to save thm in an array
    
    NSString *attendingString = [[PFUser currentUser]objectForKey:@"attending"];
    //String is split by '-' to get the id of each activity the user is going to
    NSArray *subStrings = [attendingString componentsSeparatedByString:@"-"];
    
    for (int i = 0; i < [subStrings count]; i++) {
        NSLog(@"substring %@", [subStrings objectAtIndex:i]);
        //Perform query based on id, repeat for every activity
        //No the best way to do this unfortunatly but due to time constraints I was only able to get this far
        PFQuery *query = [PFQuery queryWithClassName:@"Activities"];
        [query whereKey:@"objectId" equalTo:[subStrings objectAtIndex:i]];
        [query getFirstObjectInBackgroundWithBlock:^(PFObject *object, NSError *error){
        if (!error) {
                NSLog(@"objid %@", object.objectId);
            //Add object to timetable array
                    [timetable addObject:object];
                    NSLog(@"tt0 %@", timetable[0][@"Name"]);

            } else {
                // Log details of the failure
                NSLog(@"Error: %@ %@", error, [error userInfo]);
            }
        }];
    }
    [_tableView reloadData];
}
-(void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}
//Standard tableview
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [timetable count];
}
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *simpleTableIdentifier = @"SimpleTableItem";
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:simpleTableIdentifier];
    
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:simpleTableIdentifier];
    }
    
    cell.textLabel.text = timetable[indexPath.row][@"Name"];
    cell.detailTextLabel.text = [NSString stringWithFormat:@"%@", timetable[indexPath.row][@"Time"]];
    return cell;
}

@end
