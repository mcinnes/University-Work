﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSONTest
{
    public class QuizHandler
    {
        public Quiz CurrentQuiz { get; set; }
        public int CurrentQuestion { get; set; }
        public int CurrentScore { get; set; }
        private static QuizHandler instance = null;
        
        
        public void setQuiz(Quiz quiz){
            CurrentQuiz = quiz;
            
        }
        public QuizHandler(){
        //Set current question index to 0 when new quiz is started
          CurrentQuestion = 0;
        }
       
        public void CheckAnswer(){

        }
        //
        public String StartQuiz(){
            //Reset question index for new quiz
            CurrentQuestion = 0;
            //Reset score for new quiz
            CurrentScore = 0;
            
            //Return the first question type as a string
            return CurrentQuiz.questions[CurrentQuestion].type;
        }
        
        public String NextQuestion(){
            CurrentQuestion++;
            
            //Returns the next questions type so the correct view can be loaded
            if (CurrentQuestion <= CurrentQuiz.questions.Count){
                return CurrentQuiz.questions[CurrentQuestion].type;            
            } else {
                //If there are no more questions return "ended" to move to the end screen
                return "ended";
            }
            
        }
         public Question GetQuestion(){
            //Returns the next question in its full form
            return CurrentQuiz.questions[CurrentQuestion];
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
