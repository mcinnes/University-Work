using System;
using System.Security.Cryptography;
using System.Text;

using Xamarin.Forms;

namespace Project3
{

    public class LockPage : ContentPage
    {
        int PasscodeType;
        string passValue; 
        Entry passwordEntry;
        Entry passwordEntry1;
        Entry passwordEntry2;
        Entry passwordEntry3;

        public LockPage(int passcodeType)
        {
            PasscodeType = passcodeType;
            
            passwordEntry = new Entry {
            Placeholder = "",
            IsPassword = true,
            Keyboard = Keyboard.Numeric,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            passwordEntry1 = new Entry {
            Placeholder = "",
            IsPassword = true,
            Keyboard = Keyboard.Numeric,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
            };
             passwordEntry2 = new Entry {
            Placeholder = "",
            IsPassword = true,
            Keyboard = Keyboard.Numeric,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
            };
             passwordEntry3 = new Entry {
            Placeholder = "",
            IsPassword = true,
            Keyboard = Keyboard.Numeric,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
            };

            passwordEntry.TextChanged += Entry_TextChanged;
            passwordEntry1.TextChanged += Entry_TextChanged;
            passwordEntry2.TextChanged += Entry_TextChanged;
            passwordEntry3.TextChanged += Entry_TextChanged;
        
        
           

            var grid = new Grid ();
            grid.Children.Add (passwordEntry, 0, 0);
            grid.Children.Add (passwordEntry1, 1, 0);
            grid.Children.Add (passwordEntry2, 2, 0);
            grid.Children.Add (passwordEntry3, 3, 0);
            grid.HorizontalOptions = LayoutOptions.CenterAndExpand;
            grid.VerticalOptions = LayoutOptions.CenterAndExpand;

            string TitleString = "";
            
            if (passcodeType == 0){
                TitleString = "App Locked";
            } else if (passcodeType == 1){
                TitleString = "Type in a Passcode";
            } else if (passcodeType == 2) {
                TitleString = "Retype Passcode";
            }
            
            Content = new StackLayout
            {
                Spacing = 20,
                Children = {
                    new Label { Text = TitleString,
                    VerticalOptions = LayoutOptions.CenterAndExpand},
                    grid
                }
            };
            passwordEntry.Focus();
        }
        
         void Entry_TextChanged (object sender, TextChangedEventArgs e){
            //string _text= passwordEntry.Text;      //Get Current Text

            if(passwordEntry.IsFocused){
                passwordEntry1.Focus();
            } else if(passwordEntry1.IsFocused) {
                passwordEntry2.Focus();
            } else if(passwordEntry2.IsFocused) {
                passwordEntry3.Focus();
            }
            
            if(PasswordString(e.NewTextValue).Length == 4){
            
                string HashedEntry = App.GetSha256FromString(passValue);
                
                //Login
                if (PasscodeType == 0){
                    if (HashedEntry == Application.Current.Properties["Lock"].ToString()){
                        Navigation.PopModalAsync();
                    } else {
                        passValue = "";
                        passwordEntry.Text = "";
                        passwordEntry1.Text = "";
                        passwordEntry2.Text = "";
                        passwordEntry3.Text = "";
                        passwordEntry.Focus();
                    }
                    //Set new passcode
                } else if (PasscodeType == 1){
                    Application.Current.Properties.Add("LockTemp",HashedEntry);
                    Navigation.PushModalAsync(new LockPage(2));
                    //Re-enter new passcode
                } else if (PasscodeType == 2) {
                    if (HashedEntry == Application.Current.Properties["LockTemp"].ToString())
                    {
                        Application.Current.Properties.Remove("Lock");
                        Application.Current.Properties.Add("Lock", HashedEntry);
                        Application.Current.Properties.Remove("LockTemp");
                        App.PasscodeChanged = true;
                        Navigation.PopModalAsync();
                        
                    }
                    else { 
                        DisplayAlert("Wrong Passcode Entered","","Retry");
                        passValue = "";
                        passwordEntry.Text = "";
                        passwordEntry1.Text = "";
                        passwordEntry2.Text = "";
                        passwordEntry3.Text = "";
                        passwordEntry.Focus();
                    }
                }
                
                
            } else {
                
            }
          
         }
         
         protected string PasswordString(string entry){

            passValue = passValue + entry;
            
            return passValue;
         
         }
         protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.PasscodeChanged){
                App.PasscodeChanged = false;
                Navigation.PopModalAsync();
            }
        }
    }
}

