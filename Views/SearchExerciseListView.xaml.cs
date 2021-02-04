using System;
using System.Collections.Generic;
using JimuApuri.Models;
using JimuApuri.ViewModels;
using Xamarin.Forms;

namespace JimuApuri.Views
{
    public partial class SearchExerciseListView : ContentPage
    {
        public SearchExerciseListView()
        {
            InitializeComponent();

            // displays information
            BindingContext = new SearchExerciseListViewModel();
        }

        // when exercise item is tapped, the corrrelated id
        // send the user to the exercise they pressed
        async private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (ExerciseListView.SelectedItem == null)
            {
                return;
            }

            // checks what item was selected
            var selectedexercise = e.Item as SearchExerciseListModel;
            switch (selectedexercise.Id)
            {
                case 1:
                    await Navigation.PushAsync(new ExerciseWidePushupsView());
                    break;

                case 2:
                    await Navigation.PushAsync(new ExerciseBicepCurlsView());
                    break;

                case 3:
                    await Navigation.PushAsync(new ExerciseTricepExtensionView());
                    break;

                case 4:
                    await Navigation.PushAsync(new ExerciseBarbellBenchPressView());
                    break;

                case 5:
                    await Navigation.PushAsync(new ExerciseBarbellSquatView());
                    break;

                case 6:
                    await Navigation.PushAsync(new ExerciseBarbellDeadliftView());
                    break;

                case 7:
                    await Navigation.PushAsync(new ExerciseBodyweightCrunchView());
                    break;
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}
