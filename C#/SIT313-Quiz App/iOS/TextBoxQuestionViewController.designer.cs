// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace JSONTest.iOS
{
    [Register ("TextBoxQuestionViewController")]
    partial class TextBoxQuestionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField answerTextBox { get; set; }

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
            if (answerTextBox != null) {
                answerTextBox.Dispose ();
                answerTextBox = null;
            }

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