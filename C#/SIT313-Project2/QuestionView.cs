using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Project3
{
    public class QuestionView : ContentPage
    {
        Question CurrentQuestion;
        String answerText;
        
        public QuestionView(Question currentQuestion)
        {
            CurrentQuestion = currentQuestion;
            
            var InputControl = (View)null;
            
            
            //Buttons
            var button = new Button {
                Text = "Next Question",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            
            button.Clicked += NextQuestion;

            if (CurrentQuestion.type == "textbox"){
              Entry EntryType = new Entry
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                EntryType.TextChanged += (object sender, TextChangedEventArgs e) => { answerText = EntryType.Text; };
                InputControl = EntryType;
                
            } else if (CurrentQuestion.type == "textarea"){
                InputControl = new Editor
                {
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    MinimumHeightRequest = 140.00
                    
                };
            } else if (CurrentQuestion.type == "choice"){                
                ListView ListInput = new ListView
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    SeparatorVisibility = SeparatorVisibility.None,
                    
                };
                ListInput.ItemsSource = CurrentQuestion.options;
                ListInput.ItemSelected += (sender, e) => {
                    //Console.WriteLine(e.SelectedItem.ToString());
                    answerText = e.SelectedItem.ToString();
                    
                };
                InputControl = ListInput;
                
            } else if (CurrentQuestion.type == "date"){
                InputControl = new DatePicker
                {
                    Format = "D",
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
            }
            
            //Content Layout
            Content = new StackLayout
            {
                Spacing = 40,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new Label { Text = CurrentQuestion.text, HorizontalOptions = LayoutOptions.Center },
                    InputControl,
                    button
                }
            };
            
            if (CurrentQuestion.help != null){
                ToolbarItems.Add(new ToolbarItem("Hint", null, 
                    async () => {
                        var hintPage = new HintView(CurrentQuestion.help);
                           await Navigation.PushModalAsync (hintPage);
                    }));
            }

            if (CurrentQuestion.answer != null)
                Console.WriteLine(CurrentQuestion.answer.GetType());
            
        }
        
        async void NextQuestion(object sender, EventArgs e){

            //if the question has an answer
            if (CurrentQuestion.answer != null)
            {
                //if the answer is true
                if (Answer())
                {
                    App.qh.CurrentScore += (int)CurrentQuestion.weighting;
                    App.qh.QuizProgression.CurrentScore += (int)CurrentQuestion.weighting;
                    App.qh.AddCorrectAnswer();
                } else {
                    App.qh.AddWrongAnswer();
                }
            }
            
            if (CurrentQuestion.validate != null)
            {
               if (!Validate())
                {
                    await DisplayAlert("Check your answer", "The format of your answer is incorrect", "Continue");
                    return;
                } 
            }
            
            string next = App.qh.NextQuestion();
    
            Console.WriteLine(next);

            if (next == "ended")
                QuizEnded();
            else
                await Navigation.PushAsync(new QuestionView(App.qh.GetQuestion()));
           
        }
        
        protected bool Validate(){

            if(answerText != null){                
                Regex regex = new Regex(CurrentQuestion.validate);
                
                Match match = regex.Match(answerText);
                
                if (match.Success){
                    return true;
                }
            } else {
                DisplayAlert("No answer given", "", "Retry");
                return false;
            }
            
        
            return true;
        }
        
        protected bool Answer(){
            bool correct = false;
            
            if (CurrentQuestion.answer is String){
                if (answerText.ToLower() == (((string)CurrentQuestion.answer).ToLower())){
                    correct = true;
                }
               // return true;
            }
            
            if (CurrentQuestion.answer is Newtonsoft.Json.Linq.JArray){
                foreach (string a in ((Newtonsoft.Json.Linq.JArray)CurrentQuestion.answer).Children()){
                    if (answerText.ToLower() == a.ToLower()){
                        correct = true;
                    }
                }
            }
                
            return correct;
        }
          
      protected void QuizEnded(){
        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        string result = "{\"score\":" + App.qh.CurrentScore +",\"time\": "+ unixTimestamp +"}";
        App.qh.SaveResult(result);
        Navigation.PushAsync(new ResultScreen());
        
      }    
      
      protected override void OnDisappearing()
        {
            Application.Current.Properties["inProgress"] = true;
           
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "progress.json");
            
            File.WriteAllText(filename, JsonConvert.SerializeObject(App.qh.QuizProgression));
            
            base.OnDisappearing();
        
        }
    }
}

