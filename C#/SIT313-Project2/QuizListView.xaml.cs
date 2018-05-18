using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using System.Net;
using System.Threading.Tasks;

namespace Project3
{
    public partial class QuizListView : ContentPage
    {
        public List<Quiz> quizList = new List<Quiz>();
        
        static string kbaseURL = "http://introtoapps.com/datastore.php";
        //static string kLoginURL = "?action=load&appid=214119048&objectid=users/";
        static string kQuizListURL = "?action=load&appid=214119048&objectid=quizzes/quizlist";
        //static string kDataURL = "&data=";
        public QuizListView()
        {
            InitializeComponent();
            
           

            if (CheckInternetConnection()){
            //We have internet
                quizList = GetQuizList(kbaseURL + kQuizListURL);
            } else {
            //No internet, load from device
            
                var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Project3.iOS.quizzes_sample.json");
                
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    quizList = JsonConvert.DeserializeObject<List<Quiz>>(json);

                }
            }
            
            List<ListViewItem> titles = new List<ListViewItem>();

            foreach (Quiz q in quizList)
            {
                ListViewItem item = new ListViewItem();
                item.Text = q.title; // Or whatever display text you need
                
                item.Tag = quizList.IndexOf(q);
                titles.Add(item);
            }

            lstView.ItemsSource = titles;
            
            
            var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            Console.WriteLine(documentsPath);
            var filePath = Path.Combine (documentsPath, "test.json");
            File.WriteAllText (filePath, "testtest");
            
        }
        
        private List<Quiz> GetQuizList (string url)
        {
            List<Quiz> result;
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create (new Uri (url));
            request.ContentType = "application/json";
            request.Method = "GET";
        
           
            // Send the request to the server and wait for the response:
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<Quiz>>(json);
                
                }
            }
            return result;
        }
        
        //static async Task<string> GetProductAsync(string path)
        //{
        //    string product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(response);
        //        product = response.Content.ToString();
        //    }
        //    return product;
        //}
        
        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            

            if (e == null) return; // has been set to null, do not 'process' tapped event
            
            Console.WriteLine("Tapped: " + e.Item);
            
            ListViewItem selectedQuiz = (ListViewItem)e.Item;

            App.qh.QuizProgression.QuizListId = selectedQuiz.Tag;
            
            App.qh.setQuiz(quizList[selectedQuiz.Tag]);
            
            Console.WriteLine(App.qh.StartQuiz());

            if (App.qh.GetQuestion() == null)
                throw new NotImplementedException();
            else
                await Navigation.PushAsync (new QuestionView (App.qh.GetQuestion()));

            ((ListView)sender).SelectedItem = null; // de-select the row
            
        }
        
        //https://forums.xamarin.com/discussion/19491/check-internet-connectivity ChristophThiel
        public bool CheckInternetConnection ()
        {
            string CheckUrl = "https://google.com";

            try {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create (CheckUrl);

                iNetRequest.Timeout = 5000;

                WebResponse iNetResponse = iNetRequest.GetResponse ();

                 Console.WriteLine ("...connection established..." + iNetRequest.ToString ());
                iNetResponse.Close ();

                return true;

            } catch (WebException ex) {

                 Console.WriteLine (".....no connection..." + ex.ToString ());

                return false;
            }
            
        }
    }
}
