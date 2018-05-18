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
    [Register ("SlidingQuestionViewController")]
    partial class SlidingQuestionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel answerLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OptionsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel questionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider sliderControl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton submitButton { get; set; }

        [Action ("sliderChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void sliderChanged (UIKit.UISlider sender);

        [Action ("SubmitQuestion:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitQuestion (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (answerLabel != null) {
                answerLabel.Dispose ();
                answerLabel = null;
            }

            if (OptionsLabel != null) {
                OptionsLabel.Dispose ();
                OptionsLabel = null;
            }

            if (questionLabel != null) {
                questionLabel.Dispose ();
                questionLabel = null;
            }

            if (sliderControl != null) {
                sliderControl.Dispose ();
                sliderControl = null;
            }

            if (submitButton != null) {
                submitButton.Dispose ();
                submitButton = null;
            }
        }
    }
}