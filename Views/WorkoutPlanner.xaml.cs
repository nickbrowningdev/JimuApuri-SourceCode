using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JimuApuri.Models;

namespace JimuApuri.Views
{
    public partial class WorkoutPlanner : ContentPage
    {
        public WorkoutPlanner()
        {
            InitializeComponent();
        }

        // when app is navitgated to the planner, the sql queries are read and displays list
        protected override void OnAppearing()
        {
            PopulateWorkoutList();
        }

        // displays list
        public void PopulateWorkoutList()
        {
            WorkoutPlanList.ItemsSource = null;
            WorkoutPlanList.ItemsSource = DependencyService.Get<ISQLite>().GetWorkoutExercises();
        }

        // navitgates to add exercise page
        private void AddExercise(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddExerciseView(null));
        }

        // navitgates to edit exercise page
        private void EditExercise(object sender, ItemTappedEventArgs e)
        {
            WorkoutExerciseModel details = e.Item as WorkoutExerciseModel;
            if (details != null)
            {
                Navigation.PushAsync(new AddExerciseView(details));
            }
        }

        // for android users only
        // deletes exercise when held
        private async void DeleteExercise(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete exercise?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                WorkoutExerciseModel details = menu.CommandParameter as WorkoutExerciseModel;
                DependencyService.Get<ISQLite>().DeleteExercise(details.Id);
                PopulateWorkoutList();
            }
        }


    }
}
