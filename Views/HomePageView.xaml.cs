using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace JimuApuri.Views
{
    public partial class HomePageView : ContentPage
    {
        public HomePageView()
        {
            InitializeComponent();
        }

        // displays SearchExerciseListView
        private async void Button1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchExerciseListView());
        }

        // displays WorkoutPlanner
        private async void Button2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutPlanner());
        }

        // displays WorkoutTimer
        private async void Button3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutTimerView());
        }

        // displays LogBookMainMenu
        private async void Button4_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogbookMainMenuView());
        }

        // display maps (either google maps or apple maps) with a gps
        private async void Button5_Clicked(object sender, EventArgs e)
        {
            // latitude and longitude coordinates for gps
            String lat_entry = "-32.724447";
            String lng_entry = "151.541197";

            // converts latitude to double
            if (!double.TryParse(lat_entry, out double lat))
            {
                return;
            }

            // converts longitude to double
            if (!double.TryParse(lng_entry, out double lng))
            {
                return;
            }

            // displays map and open with a gps with driving cooridinates
            // for world gym maitland
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = "World Gym Maitland",
                NavigationMode = NavigationMode.Driving
            }

            ); 
        }
    }
}
