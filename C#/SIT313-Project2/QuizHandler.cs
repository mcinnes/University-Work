﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Threading.Tasks;
namespace Project3
{
    public class QuizHandler
    {

        static string kbaseURL = "http://introtoapps.com/datastore.php";
        static string kLoginURL = "?action=save&appid=214119048&objectid=quizresults/";

        public Quiz CurrentQuiz { get; set; }
        public int CurrentQuestion { get; set; }
        public int CurrentScore { get; set; }
        private static QuizHandler instance = null;
        public QuizProgress QuizProgression = new QuizProgress();
        
        public void setQuiz(Quiz quiz){
            CurrentQuiz = quiz;
            QuizProgression.QuizId = quiz.id;
            QuizProgression.QuizName = quiz.title;
            
        }
        public string GetQuizID(){
            return CurrentQuiz.id;
        }
        
        public int GetCurrentQuestionID(){
            return CurrentQuestion;
        }
        
        public QuizHandler(){
        //Set current question index to 0 when new quiz is started
          CurrentQuestion = 0;
        }
       
        public void CheckAnswer(){

        }
        
        public void AddWrongAnswer(){
            QuizProgression.WrongAnswers.Add(GetCurrentQuestionID());
        }
        public void AddCorrectAnswer(){
            QuizProgression.CorrectAnswers.Add(GetCurrentQuestionID());
        }
        //
        public String StartQuiz(){
            //Reset question index for new quiz
            CurrentQuestion = 0;
            //Reset score for new quiz
            CurrentScore = 0;
            //Reset Answer Arrays

            QuizProgression.CorrectAnswers = new List<int>();
            QuizProgression.WrongAnswers = new List<int>();
            
            
            //Return the first question type as a string
            return CurrentQuiz.questions[CurrentQuestion].type;
        }
        
        public String NextQuestion(){
            CurrentQuestion++;
            QuizProgression.Question = CurrentQuestion;
            
            try
            {
                //Returns the next questions type so the correct view can be loaded
                if (CurrentQuestion <= CurrentQuiz.questions.Count)
                {
                    return CurrentQuiz.questions[CurrentQuestion].type;
                }
                else
                {
                    //If there are no more questions return "ended" to move to the end screen and delete progress of quiz
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string filename = Path.Combine(path, "progress.json");
                    File.Delete(filename);
                    App.Current.Properties.Remove("inProgress");
                    
                    return "ended";
                }
            }
            catch{
                return "ended";
            }   
        }
        
        public int GetMaxScore(){
            if (CurrentQuiz.score != null){
                return (int)CurrentQuiz.score;
            } else {
                return 0;
            }
        }
        
        public bool IsScored(){
           if (CurrentQuiz.score != null){
                return true;
            } else {
                return false;
            } 
        }
        
         public Question GetQuestion(){
            //Returns the next question in its full form
            return CurrentQuiz.questions[CurrentQuestion];
        }

        public string SaveResult(string quizResult){

            string result;
            string url = kbaseURL + kLoginURL + App.Current.Properties["Username"] + "-" + CurrentQuiz.id + "&data=" + quizResult;
            
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
            request.ContentType = "application/json";
            request.Method = "GET";
        
           
            // Send the request to the server and wait for the response:
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd(); // do something fun...
                }
            }
            return result;            
            
        }
        
        // Lock the QuizHandler object so only one instance can be created at a time.
		 private static object syncLock = new object();
		 
		 public static QuizHandler Instance
		 {
		    get{
		      lock (syncLock){
	           if (QuizHandler.instance == null){
                QuizHandler.instance = new QuizHandler();
               }
		        return QuizHandler.instance;
		       }
            }
		 }
 
        
    }
}
