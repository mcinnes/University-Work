using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Project3
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (App.Locked == true)
            {
                Navigation.PushModalAsync(new LockPage(0));
            }
           
            if (App.LoggedIn == false){
            
              Navigation.PushModalAsync (new LoginView());

            }
        }
    }
}
