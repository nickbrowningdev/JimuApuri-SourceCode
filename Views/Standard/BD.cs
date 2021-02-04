using System;

using Xamarin.Forms;

namespace JimuApuri.Views.Standard
{
    public class BD : ContentPage
    {
        public BD()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

