//
//  ActivitesTableViewController.m
//  Assignment2
//
//  Created by Matt on 24/05/2015.
//
//

#import "Messages.h"
#import "SimpleTableCell.h"

#import <Parse/Parse.h>
@interface Messages ()

@end

@implementation Messages
{
    PFObject *obj;
}

- (id)initWithCoder:(NSCoder *)aDecoder
{
    self = [super initWithCoder:aDecoder];
    if (self) {
        // Custom the table
        
        // The className to query on
        self.parseClassName = @"Message";
        
        // The key of the PFObject to display in the label of the default cell style
        self.textKey = @"Title";
        
        // The title for this table in the Navigation Controller.
        self.title = @"Messages";
        
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
    
    // Uncomment the following line to preserve selection between presentations.
    // self.clearsSelectionOnViewWillAppear = NO;
    NSLog(@"this");
    // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
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

//- (void)objectsWillLoad {
//  [super objectsWillLoad];

// This method is called before a PFQuery is fired to get more objects
//}


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



// Override to customize the look of a cell representing an object. The default is to display
// a UITableViewCellStyleDefault style cell with the label being the first key in the object.
/* - (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath object:(PFObject *)object {
 static NSString *CellIdentifier = @"Cell";
 
 UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
 if (cell == nil) {
 cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:CellIdentifier];
 }
 
 // Configure the cell
 cell.textLabel.text = [object objectForKey:@"Name"];
 cell.detailTextLabel.text = [NSString stringWithFormat:@"%@", [object objectForKey:@"Description"]];
 
 return cell;
 }
 */
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
    if ([object[@"status"]  isEqual: @"activity"]) {
        cell.backgroundColor = [UIColor blueColor];
        
    } else if ([object[@"status"]  isEqual: @"active"]) {
        cell.backgroundColor = [UIColor redColor];
        
    }
    else if ([object[@"status"]  isEqual: @"resolved"]) {
        cell.backgroundColor = [UIColor greenColor];
        
    }
    
    cell.nameLabel.textColor= [UIColor whiteColor];
    cell.TimeLabel.textColor= [UIColor whiteColor];
    cell.typeLabel.textColor= [UIColor whiteColor];
    cell.locationLabel.text = nil;
    cell.nameLabel.text = [object objectForKey:@"Title"];
    cell.TimeLabel.text = [object objectForKey:@"Body"];
    cell.typeLabel.text = [object objectForKey:@"Type"];
    
    
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
    }
@end
