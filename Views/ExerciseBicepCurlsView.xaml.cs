using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JimuApuri.Models;
using JimuApuri.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JimuApuri.Views
{
    public partial class ExerciseBicepCurlsView : ContentPage
    {
        // get contents
        private ObservableCollection<ExerciseBicepCurlsViewModel> getContents;
        private ObservableCollection<ExerciseBicepCurlsViewModel> _expandedContent;

        public ExerciseBicepCurlsView()
        {
            InitializeComponent();

            getContents = ExerciseBicepCurlsViewModel.Contents;
            UpdateListContent();
        }

        // when arrow is tapped
        private void HeaderTapped(object sender, EventArgs args)
        {
            int ListselectedIndex = _expandedContent.IndexOf(((ExerciseBicepCurlsViewModel)((Button)sender).CommandParameter));
            getContents[ListselectedIndex].Expanded = !getContents[ListselectedIndex].Expanded;
            UpdateListContent();
        }

        // updates content
        private void UpdateListContent()
        {
            _expandedContent = new ObservableCollection<ExerciseBicepCurlsViewModel>();
            foreach (ExerciseBicepCurlsViewModel group in getContents)
            {
                ExerciseBicepCurlsViewModel exercises = new ExerciseBicepCurlsViewModel(group.Title, group.Expanded);
                exercises.ExerciseItems = group.Count;
                if (group.Expanded)
                {
                    foreach (ExerciseBicepCurlsModel exercise in group)
                    {
                        exercises.Add(exercise);
                    }
                }
                _expandedContent.Add(exercises);
            }
            MyListView.ItemsSource = _expandedContent;
        }
    }
}
