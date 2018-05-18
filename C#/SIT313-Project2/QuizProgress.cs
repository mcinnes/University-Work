using System;
using System.Collections.Generic;

namespace Project3
{
    public class QuizProgress
    {
        public string QuizName { get; set; }
        public string QuizId { get; set; }
        public int Question { get; set; }
        public  List<int> WrongAnswers { get; set; }
        public  List<int> CorrectAnswers { get; set; }
        public int CurrentScore { get; set; }
        public int QuizListId { get; set; }
    }
}
