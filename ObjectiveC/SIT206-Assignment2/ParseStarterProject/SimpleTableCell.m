//
//  SimpleTableCell.m
//  SimpleTable
//
//

#import "SimpleTableCell.h"

@implementation SimpleTableCell
@synthesize nameLabel = _nameLabel;
@synthesize TimeLabel = _TimeLabel;
@synthesize locationLabel = _locationLabel;
@synthesize thumbnailImageView = _thumbnailImageView;
@synthesize typeLabel = _typeLabel;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        // Initialization code

    }
    return self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

}

@end
