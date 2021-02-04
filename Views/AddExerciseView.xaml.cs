using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JimuApuri.Models;

using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace JimuApuri.Views
{
    public partial class AddExerciseView : ContentPage
    {
        WorkoutExerciseModel workoutexerciseDetails;

        // get workout list
        public object WorkoutPlanList { get; private set; }
    
        public AddExerciseView(WorkoutExerciseModel details)
        {
            InitializeComponent();

            // if exercise already exists, edit function appears
            if (details != null)
            {
                workoutexerciseDetails = details;
                PopulateDetails(workoutexerciseDetails);
            }
            else
            {
                deleteBtn.Text = "Delete Function Disabled";
            }
        }

        // shake to erase text
        // mobile feature accelometer
        protected override async void OnAppearing()
        {
            base.OnAppearing();        

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;

            Accelerometer.Start(SensorSpeed.Game);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Stop();
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                name.Text = string.Empty;
            });
        }

            // write data
            private void PopulateDetails(WorkoutExerciseModel details)
        {
            name.Text = details.Name;
            saveBtn.Text = "Update";
            this.Title = "Edit Exercise";
        }

        // saves exercise
        private void SaveExercise(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                WorkoutExerciseModel workoutexercise = new WorkoutExerciseModel();
                workoutexercise.Name = name.Text;

                

                bool res = DependencyService.Get<ISQLite>().SaveExercise(workoutexercise);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Warning", "Data Failed To Save", "OK");
                }
            }
            else
            {
                // update exercise
                workoutexerciseDetails.Name = name.Text;

                bool res = DependencyService.Get<ISQLite>().UpdateExercise(workoutexerciseDetails);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Warning", "Data Failed To Update", "Ok");
                }
            }
        }

        // for iOS users to delete exercise
        private void DeleteExerciseAlt(object sender, EventArgs e)
        {
            if (deleteBtn.Text == "Delete")
            {
                if (!string.IsNullOrWhiteSpace(name.Text))
                {
                    workoutexerciseDetails.Name = name.Text;

                    bool res = DependencyService.Get<ISQLite>().DeleteExerciseAlt(workoutexerciseDetails);
                    if (res)
                    {
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Warning", "Data Failed To Delete", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Warning", "Data Failed To Delete", "Ok");
                }
            }
        }
    }
}
