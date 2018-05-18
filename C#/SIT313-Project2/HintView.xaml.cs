using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Project3
{
    public partial class HintView : ContentPage
    {
        public HintView(string hint)
        {
            InitializeComponent();
             //Buttons
            var button = new Button {
                Text = "Done",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            
            button.Clicked += CloseModal;
            
            Content = new StackLayout
            {
                Spacing = 40,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new Label { Text = hint, HorizontalOptions = LayoutOptions.Center },
                    button
                }
            };
        }
        async void CloseModal(object sender, EventArgs e){
            await Navigation.PopModalAsync();
        }
    }
}
