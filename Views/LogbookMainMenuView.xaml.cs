using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JimuApuri.Views
{
    public partial class LogbookMainMenuView : ContentPage
    {
        public LogbookMainMenuView()
        {
            InitializeComponent();
        }

        // All buttons used to navagate pages//
        private void BBPButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standard.BBP());
        }
        private void BDButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standard.BD());
        }
        private void BSButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standard.BS());
        }
        private void BCButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standard.BC());
        }
        private void BWCButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standard.BWC());
        }
        private void TEButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standard.TE());
        }
        private void WPButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standard.WP());
        }
        private void RunButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cardio.Run());
        }
        private void WalkButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cardio.Walk());
        }
    }
}
