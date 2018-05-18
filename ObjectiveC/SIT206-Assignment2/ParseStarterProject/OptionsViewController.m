//
//  OptionsViewController.m
//  Assignment2
//
//  Created by Matt on 26/05/2015.
//
//

#import "OptionsViewController.h"
#import "MapViewViewController.h"
@interface OptionsViewController ()

@end

@implementation OptionsViewController {
    MapViewViewController *mapview;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    mapview = [[MapViewViewController alloc]init];
    // Do any additional setup after loading the view.
}
- (IBAction)setOption:(id)sender {
    UIButton *button = (UIButton *)sender;
    
    switch(button.tag)
    {
        case 0:{
            break;
        }
        case 1: {
            mapview.condition = @"Library";
            break;
        }//do stuff
        default: {
            break;
        }
    }
    mapview.condition = @"Food";

    [self dismissViewControllerAnimated:YES completion:nil];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
