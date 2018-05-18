using Xamarin.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Project3
{
    public partial class App : Application
    {
        public static QuizHandler qh = new QuizHandler();
        
        public static bool LoggedIn = new bool();
        public static bool Locked = new bool();
        public static bool PasscodeChanged = new bool();
        public App()
        {
            InitializeComponent();
            
            //Application.Current.Properties["Lock"] = "9BE87048F0913385E325DCE080FD7684B2A0B29578721A36F0E841C0AEE231D5".ToLower();
            //Application.Current.Properties.Remove("Lock");
             
            //Application.Current.Properties.Remove("LoggedIn");

            if (Application.Current.Properties.ContainsKey("LoggedIn")){
                LoggedIn = true;
                //MainPage = new MainPage();
            } 
            if (Application.Current.Properties.ContainsKey("Locked")){
                Locked = true;
                //MainPage = new MainPage();
            } 
            
            MainPage = new MainPage();
    
        }
        
        public static string GetSha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";
    
            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += string.Format("{0:x2}", x);
            }
            return hex;
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
           //qh = new QuizHandler();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
