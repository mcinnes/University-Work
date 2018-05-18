//
//  ActivitesTableViewController.m
//  Assignment2
//
//  Created by Matt on 24/05/2015.
//
// Using the standard Parse tableview

#import "ActivitesTableViewController.h"
#import "SimpleTableCell.h"
#import "EventInfoViewController.h"
@interface ActivitesTableViewController ()

@end

@implementation ActivitesTableViewController
{
    PFObject *obj;
    EventInfoViewController *eventView;
}

- (id)initWithCoder:(NSCoder *)aDecoder
{
    self = [super initWithCoder:aDecoder];
    if (self) {
        // Custom the table
        
        // The className to query on
        self.parseClassName = @"Activities";
        
        // The key of the PFObject to display in the label of the default cell style
        self.textKey = @"Name";
        
        // The title for this table in the Navigation Controller.
        self.title = @"Events";
        
        // Whether the built-in pull-to-refresh is enabled
        self.pullToRefreshEnabled = YES;
        
        // Whether the built-in pagination is enabled
        self.paginationEnabled = YES;
        
        // The number of objects to show per page
        self.objectsPerPage = 10;
    }
    return self;
}

#pragma mark - View lifecycle

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self.tableView setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    
    
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (void)viewWillAppear:(BOOL)animated
{
    [super viewWillAppear:animated];
}

- (void)viewDidAppear:(BOOL)animated
{

    [super viewDidAppear:animated];
}

- (void)viewWillDisappear:(BOOL)animated
{
    [super viewWillDisappear:animated];
}

- (void)viewDidDisappear:(BOOL)animated
{
    [super viewDidDisappear:animated];
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    // Return YES for supported orientations
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

- (void)didReceiveMemoryWarning
{
    // Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
    
    // Release any cached data, images, etc that aren't in use.
}

#pragma mark - Parse

//- (void)objectsDidLoad:(NSError *)error {
//  [self objectsDidLoad:error];

// This method is called every time objects are loaded from Parse via the PFQuery
//}

- (void)objectsWillLoad {
  [super objectsWillLoad];

// This method is called before a PFQuery is fired to get more objects
}


// Override to customize what kind of query to perform on the class. The default is to query for
// all objects ordered by createdAt descending.
- (PFQuery *)queryForTable {
    PFQuery *query = [PFQuery queryWithClassName:self.parseClassName];
    
    // If no objects are loaded in memory, we look to the cache first to fill the table
    // and then subsequently do a query against the network.
   // if ([self.objects count] == 0) {
    //    query.cachePolicy = kPFCachePolicyCacheThenNetwork;
    //}
    
    [query orderByAscending:@"endTime"];
    
    return query;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath object:(PFObject *)object
{
    static NSString *simpleTableIdentifier = @"SimpleTableCell";
    
    SimpleTableCell *cell = (SimpleTableCell *)[tableView dequeueReusableCellWithIdentifier:simpleTableIdentifier];
    if (cell == nil)
    {
        NSArray *nib = [[NSBundle mainBundle] loadNibNamed:@"SimpleTableCell" owner:self options:nil];
        cell = [nib objectAtIndex:0];
    }
    
    
/*    PFFile *thumbnail = [object objectForKey:@"CoverPhoto"];
    [thumbnail getDataInBackgroundWithBlock:^(NSData *data, NSError *error) {
        if (!error) {
            // Now that the data is fetched, update the cell's image property with thumbnail
            cell.thumbnailImageView.image = [UIImage imageWithData:data];
        } else {
            // Log details of the failure
            NSLog(@"Error: %@ %@", error, [error userInfo]);
        }
        
    }];
    */
    //Set image based on type of activity
    if ([object[@"photo"]  isEqual: @"food"]) {
        cell.thumbnailImageView.image = [UIImage imageNamed:@"food.png"];

    } else if ([object[@"photo"]  isEqual: @"lecture"]) {
        cell.thumbnailImageView.image = [UIImage imageNamed:@"lecture.png"];
        
    }
    else if ([object[@"photo"]  isEqual: @"demonstation"]) {
        cell.thumbnailImageView.image = [UIImage imageNamed:@"deom.png"];
        
    }
    //Set rest of the cell
    cell.nameLabel.text = [object objectForKey:@"Name"];
    cell.TimeLabel.text = [NSString stringWithFormat:@"%@", [object objectForKey:@"Time"]];
    cell.locationLabel.text = [NSString stringWithFormat:@"%@", [object objectForKey:@"Location"]];
    
    
    cell.typeLabel.text = [NSString stringWithFormat:@"%@", [object objectForKey:@"Type"]];

    
    return cell;
}
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    return 130;
}


#pragma mark - Table view data source


#pragma mark - Table view delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    [super tableView:tableView didSelectRowAtIndexPath:indexPath];
    obj = [self.objects objectAtIndex:indexPath.row];
    
    //Call de second view with the selected Category on iniWithCategory:obj.objectId
    //NSUserDefaults *defaults;
    //[defaults setObject:obj.objectId forKey:@"eventID"];
    //[defaults synchronize];
    [self performSegueWithIdentifier:@"EventInfo" sender:self];

    
    
    //
    
}

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    if ([segue.destinationViewController isKindOfClass:[EventInfoViewController class]]) {
        EventInfoViewController *asker = (EventInfoViewController *) segue.destinationViewController;
        asker.event= obj;
        
    }
}
@end
