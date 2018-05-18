using System;

using Xamarin.Forms;

namespace Project3
{
    public class ResultScreen : ContentPage
    {
        public ResultScreen()
        {
            Title = "Your Results";
            
            Label ScoreLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                Margin = 50
            };
            
            ScoreLabel.Text = "You scored " + App.qh.CurrentScore.ToString();
            
            
             ListView WrongAnswerList = new ListView
                {
                    HorizontalOptions = LayoutOptions.Center,
                    SeparatorVisibility = SeparatorVisibility.Default,
                    
                };
                WrongAnswerList.Header = "Wrong Answers";
                WrongAnswerList.ItemsSource = App.qh.QuizProgression.WrongAnswers;
                WrongAnswerList.ItemSelected += (sender, e) => {
                    //Console.WriteLine(e.SelectedItem.ToString());
                    //answerText = e.SelectedItem.ToString();
                    
                };
                
            ListView CorrectAnswerList = new ListView
                {
                    HorizontalOptions = LayoutOptions.Center,
                    SeparatorVisibility = SeparatorVisibility.Default,
                    
                };
                CorrectAnswerList.Header = "Correct Answers";
                CorrectAnswerList.ItemsSource = App.qh.QuizProgression.CorrectAnswers;
                CorrectAnswerList.ItemSelected += (sender, e) => {
                    //Console.WriteLine(e.SelectedItem.ToString());
                    //answerText = e.SelectedItem.ToString();
                    
                };
                
                  //Buttons
            var FinishedButton = new Button {
                Text = "Finish Quiz",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            
            FinishedButton.Clicked += Finished;
            
            Content = new StackLayout
            {
                Children = {
                    ScoreLabel,
                    WrongAnswerList,
                    CorrectAnswerList,
                    FinishedButton
                }
            };
        }
        async void Finished(object sender, EventArgs e){
            await Navigation.PopToRootAsync();
        }
    }
}

