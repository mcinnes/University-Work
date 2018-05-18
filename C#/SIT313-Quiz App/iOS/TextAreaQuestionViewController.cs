using System;

using UIKit;

namespace JSONTest.iOS
{
    public partial class TextAreaQuestionViewController : UIViewController
    {
        
        private Question Question;

        public TextAreaQuestionViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
            setQuestion();
            
            //Set the title of the screen
            NavigationItem.Title = "Question " + Question.id;
            questionLabel.Text = Question.text + " : " + Question.help;
            
            //Set background image for view
            UIImage bgImage = new UIImage(filename: "bg.png");
            this.View.BackgroundColor = UIColor.FromPatternImage(bgImage);
            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        
         //Shared accross all Question ViewControllers
        public void setQuestion ()
        {
            //Loads the current question to populate the view.
            Question = App.quizHandler.GetQuestion();
        }
        
        partial void SubmitQuestion(UIButton sender)
        {
            //Get next question type and perfom the move to the next vc
            String nextQuestionType = App.quizHandler.NextQuestion();
            
            
            if (nextQuestionType != "ended"){
                //Use the navigation controller to push the new view
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

