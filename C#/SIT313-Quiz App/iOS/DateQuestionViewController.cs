using System;

using UIKit;

namespace JSONTest.iOS
{
    public partial class DateQuestionViewController : UIViewController
    {
        private Question Question;

        public DateQuestionViewController (IntPtr handle) : base (handle)
        {
        }

       public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIImage bgImage = new UIImage(filename: "bg.png");
            this.View.BackgroundColor = UIColor.FromPatternImage(bgImage);
            setQuestion();
          
            NavigationItem.Title = "Question " + Question.id;
            questionLabel.Text = Question.text + " : " + Question.help;
            
            
           
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

