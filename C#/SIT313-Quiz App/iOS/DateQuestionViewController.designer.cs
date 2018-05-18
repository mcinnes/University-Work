// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace JSONTest.iOS
{
    [Register ("DateQuestionViewController")]
    partial class DateQuestionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel questionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton submitButton { get; set; }

        [Action ("SubmitQuestion:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitQuestion (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (questionLabel != null) {
                questionLabel.Dispose ();
                questionLabel = null;
            }

            if (submitButton != null) {
                submitButton.Dispose ();
                submitButton = null;
            }
        }
    }
}