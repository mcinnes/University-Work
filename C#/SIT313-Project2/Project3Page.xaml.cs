using Xamarin.Forms;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Project3
{
    public partial class Project3Page : ContentPage
    {
        public Project3Page()
        {
            InitializeComponent();
            
            if (Application.Current.Properties.ContainsKey("inProgress")){
                DisplayAlert("You have a quiz in progress", "Do you wish to continue with it","No thanks");
            }
            //this.BackgroundImage = "bg.png";
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
             if (App.LoggedIn){
               WelcomeLabel.Text = "Welcome back " + Application.Current.Properties["Name"];
            }
            if (Application.Current.Properties.ContainsKey("inProgress"))
                ContinueQuizButton.Clicked += ContinueQuiz;
            
        }
        
        async void ShowProfile(object sender, EventArgs e){
           await Navigation.PushModalAsync(new ProfilePage());
        }
        
        async void ContinueQuiz(object sender, EventArgs e){
            //QuizListView quizListView = new QuizListView();
            
            //Load json to thing and set it
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string filename = Path.Combine(path, "progress.json");
            
            //QuizProgress QP = JsonConvert.DeserializeObject<QuizProgress>(filename);
            //App.qh.QuizProgression = QP;
            
            //App.qh.setQuiz(quizListView.quizList[App.qh.QuizProgression.QuizListId]);
            //App.qh.CurrentQuestion = App.qh.QuizProgression.Question;
            //App.qh.CurrentScore = App.qh.QuizProgression.CurrentScore;
            //await Navigation.PushAsync(new QuestionView(App.qh.GetQuestion()));
        }
    }
}
