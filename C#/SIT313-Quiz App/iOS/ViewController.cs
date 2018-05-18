using System;
using Newtonsoft.Json;
using UIKit;
using System.IO;
using System.Collections.Generic;

namespace JSONTest.iOS
{
    public partial class ViewController : UIViewController
    {
        string firstQuestionType;
        public ViewController(IntPtr handle) : base(handle)
         
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            //Set background image from file
            UIImage bgImage = new UIImage(filename: "bg.png");
            this.View.BackgroundColor = UIColor.FromPatternImage(bgImage);
            
            //Set title of home screen
            NavigationItem.Title = "SIT313 Quiz App";
            
            //Load quiz data from json file
	        JSONTest();            
        }
        
        public void JSONTest(){
        
        //Load each quiz into a list of type Quiz
	    var quizList = JsonConvert.DeserializeObject<List<Quiz>>(File.ReadAllText(@"quizzes_sample.json"));
	        
        //Tell the app to use the first quiz
        App.quizHandler.setQuiz(quizList[0]);
        
        firstQuestionType = App.quizHandler.StartQuiz();
       
           
	    }


        partial void changeView(UIButton sender)
        {
            
            this.NavigationController.PerformSegue(firstQuestionType, this);
        }
        
        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

           
            
        }
        
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }
        #region Application Access
	    public static AppDelegate App {
	        get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
	    }
        #endregion
    }
}
