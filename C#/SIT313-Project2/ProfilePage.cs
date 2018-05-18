using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project3
{
    public class ProfilePage : ContentPage
    {
        static string kbaseURL = "http://introtoapps.com/datastore.php";
        static string kLoadURL = "?action=load&appid=214119048&objectid=users/";
        static string kUpdateURL = "?action=save&appid=214119048&objectid=users/";
        static string kDataURL = "&data=";
        Entry OldPassword = new Entry();
        Entry NewPassword = new Entry();
        Entry NewPasswordConfirm = new Entry();
        
        public ProfilePage()
        {
            Button SavePasswordButton = new Button();
            SavePasswordButton.Text = "Save Password";
            SavePasswordButton.Clicked += UpdatePassword;

            OldPassword.Placeholder = "Old Password";
            OldPassword.IsPassword = true;
            
            NewPassword.Placeholder = "New Password";
            NewPassword.IsPassword = true;
            
            NewPasswordConfirm.Placeholder = "Confirm New Password";
            NewPasswordConfirm.IsPassword = true;

            Button LockAppButton = new Button();
            LockAppButton.Clicked += SetPasscode;
            
            Label IsLockedLabel = new Label();
            IsLockedLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
            
            if (Application.Current.Properties.ContainsKey("Lock")){
                IsLockedLabel.Text = "App Lock Enabled";
                LockAppButton.Text = "Change Passcode";
            } else {
                IsLockedLabel.Text = "App Lock Disabled";
                LockAppButton.Text = "Set Passcode";
            }
                
            
            
            
            Button DismissScreenButton = new Button();
            DismissScreenButton.Text = "Finished";
            DismissScreenButton.Clicked += (object sender, EventArgs e) => Navigation.PopModalAsync();
            
            
            Button LogoutButton = new Button();
            LogoutButton.Text = "Logout";
            LogoutButton.Clicked += Logout;
            
            Content = new StackLayout
            {
                Spacing = 40,
                Children = {
                    new Label { Text = "Change Password", Margin = 15, HorizontalOptions=LayoutOptions.CenterAndExpand},
                    OldPassword,
                    NewPassword,
                    NewPasswordConfirm,
                    SavePasswordButton,
                    IsLockedLabel,
                    LockAppButton,
                    LogoutButton,
                    DismissScreenButton
                    
                }
            };
        }
        
        async void UpdatePassword(object sender, EventArgs e)
        {
            if (NewPassword.Text == null || NewPasswordConfirm.Text == null || OldPassword.Text == null)
                return;
            
            if (NewPassword.Text == NewPasswordConfirm.Text){
                if (CheckLogin()){
                    string passwordHash = App.GetSha256FromString(NewPassword.Text.ToLower());
                    string username = Application.Current.Properties["Username"].ToString().ToLower();
                    string url = kbaseURL + kUpdateURL + username + kDataURL + username + ":" + passwordHash + ":" + "Matt";
                    //string loginResponse = await SendLoginDetails(url);      
        
                    string loginResponse = SendLoginDetails(url);
                    
                    if (loginResponse == "ok"){
                        App.LoggedIn = true;
                        await DisplayAlert("Password Update Successful", "", "Done");
                        OldPassword.Text = "";
                        NewPassword.Text = "";
                        NewPasswordConfirm.Text = "";
                    } else {
                        await DisplayAlert("Update Failed", "Please Try again", "Done");
                    }
                    
                }
            } else {
                await DisplayAlert("New Passwords do not match", "Please Try again", "Ok");
            }
           
            
        }
        
        private bool CheckLogin()
        {
            
            string url = kbaseURL + kLoadURL + Application.Current.Properties["Username"].ToString().ToLower();
            string passwordHash = App.GetSha256FromString(OldPassword.Text.ToLower());

            string loginResponse = SendLoginDetails(url);
            string[] responseArray = loginResponse.Split(':');
            
            if (responseArray[1].ToLower() == passwordHash){
                return true;

            } else {
                return false;
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

        async void SetPasscode(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LockPage(1));
        }
        
        protected void Logout(object sender, EventArgs e)
        {
           Application.Current.Properties.Remove("Name");
           Application.Current.Properties.Remove("Username");

        }
    }
}

