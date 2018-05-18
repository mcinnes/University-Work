using System;

using Foundation;
using UIKit;

namespace JSONTest.iOS
{
    public partial class QuizCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("QuizCollectionViewCell");
        public static readonly UINib Nib;

        static QuizCollectionViewCell()
        {
            Nib = UINib.FromName("QuizCollectionViewCell", NSBundle.MainBundle);
        }

        protected QuizCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
