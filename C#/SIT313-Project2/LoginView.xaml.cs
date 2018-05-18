using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

using Xamarin.Forms;

namespace Project3
{
    public partial class LoginView : ContentPage
    {
        Entry UsernameEntry;
        Entry PasswordEntry;
        Entry NameEntry;
        static string kbaseURL = "http://introtoapps.com/datastore.php";
        static string kLoginURL = "?action=load&appid=214119048&objectid=users/";
        static string kRegisterURL = "?action=save&appid=214119048&objectid=users/";
        static string kDataURL = "&data=";
       
        
        public LoginView()
        {
            InitializeComponent();
           
            var LoginButton = new Button {
                Text = "Login",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
             var RegisterButton = new Button {
                Text = "Register",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            
            LoginButton.Clicked += SubitLogin;
            RegisterButton.Clicked += Register;

            UsernameEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = 30,
                TranslationY = 30,
                Placeholder = "Username"
                
            };

            PasswordEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = 30,
                Placeholder = "Password",
                IsPassword = true
            };
            NameEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = 30,
                Placeholder = "Name",
                IsPassword = true
            };
            Content = new StackLayout
            {
                Spacing = 40,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    UsernameEntry,
                    PasswordEntry,
                    LoginButton,
                    NameEntry,
                    RegisterButton
                }
            };
        }
        
        async void SubitLogin(object sender, EventArgs e)
        {
            
            string url = kbaseURL + kLoginURL + UsernameEntry.Text.ToLower();
            string passwordHash = App.GetSha256FromString(PasswordEntry.Text.ToLower());
            //string loginResponse = await SendLoginDetails(url);      


            string loginResponse = SendLoginDetails(url);
            string[] responseArray = loginResponse.Split(':');
            Console.WriteLine(loginResponse.ToString());
            
            if (responseArray[1].ToLower() == passwordHash){
                App.LoggedIn = true;
                
                Application.Current.Properties["LoggedIn"] = true;
                Application.Current.Properties["Username"] = responseArray[0];
                Application.Current.Properties["Name"] = responseArray[2];
                
                await Navigation.PopModalAsync();

            } else {
                await DisplayAlert("Login Failed", "Please Try again", "Done");
            }
            
            
        }
        
        async void Register(object sender, EventArgs e)
        {
            string passwordHash = App.GetSha256FromString(PasswordEntry.Text.ToLower());
            
            string url = kbaseURL + kRegisterURL + UsernameEntry.Text.ToLower() + kDataURL + UsernameEntry.Text.ToLower() + ":" + passwordHash + ":" + NameEntry.Text;
            //string loginResponse = await SendLoginDetails(url);      

            string loginResponse = SendLoginDetails(url);
            
            
            if (loginResponse == "ok"){
                App.LoggedIn = true;
                
                await Navigation.PopToRootAsync();

            } else {
                await DisplayAlert("Login Failed", "Please Try again", "Done");
            }
            
            
        }
        
        private string SendLoginDetails (string url)
        {
            string result;
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
        
       
    }
}
