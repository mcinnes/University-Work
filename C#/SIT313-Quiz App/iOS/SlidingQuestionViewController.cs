using Foundation;
using System;
using UIKit;
using CoreGraphics;
namespace JSONTest.iOS
{
    public partial class SlidingQuestionViewController : UIViewController
    {
 
        

        private Question Question;
        
        public SlidingQuestionViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            setQuestion();
            //label1.Text = "trash";
            // Console.WriteLine(questionLabel.Text);
            NavigationItem.Title = "Question " + Question.id;
            questionLabel.Text = Question.text;
            this.sliderControl.MinValue = 0;
            sliderControl.MaxValue = ((float)Question.options.Count - (float)0.6);
           
        }
        
        partial void sliderChanged(UISlider sender)
        {
            double sliderValueDouble = Convert.ToDouble(sliderControl.Value);
            int roundedIndex = Convert.ToInt32(sliderControl.Value);
            OptionsLabel.Text = Question.options[roundedIndex];
            answerLabel.Text = Question.optionVisuals[roundedIndex];
            
        }
        
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            
        }
        //Shared accross all Question ViewControllers
        public void setQuestion ()
        {
            Question = App.quizHandler.GetQuestion();
        }
        
        partial void SubmitQuestion(UIButton sender)
        {
            //Do saving

            String nextQuestionType = App.quizHandler.NextQuestion();

            if (nextQuestionType != "ended"){
                //PerformSegue(nextQuestionType, this);

                this.NavigationController.PerformSegue(nextQuestionType, this);
                
            } else {
                PerformSegue("quizEnded", this);
            }
            
        }
        #region Application Access
	    public static AppDelegate App {
	        get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
	    }
    #endregion
        
    }
}