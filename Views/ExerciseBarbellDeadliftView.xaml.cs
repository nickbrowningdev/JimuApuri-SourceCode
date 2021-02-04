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
    public partial class ExerciseBarbellDeadliftView : ContentPage
    {
        // get contents
        private ObservableCollection<ExerciseBarbellDeadliftViewModel> getContents;
        private ObservableCollection<ExerciseBarbellDeadliftViewModel> _expandedContent;

        public ExerciseBarbellDeadliftView()
        {
            InitializeComponent();

            getContents = ExerciseBarbellDeadliftViewModel.Contents;
            UpdateListContent();
        }

        // when arrow is tapped
        private void HeaderTapped(object sender, EventArgs args)
        {
            int ListselectedIndex = _expandedContent.IndexOf(((ExerciseBarbellDeadliftViewModel)((Button)sender).CommandParameter));
            getContents[ListselectedIndex].Expanded = !getContents[ListselectedIndex].Expanded;
            UpdateListContent();
        }
        
        // updates content
        private void UpdateListContent()
        {
            _expandedContent = new ObservableCollection<ExerciseBarbellDeadliftViewModel>();
            foreach (ExerciseBarbellDeadliftViewModel group in getContents)
            {
                ExerciseBarbellDeadliftViewModel exercises = new ExerciseBarbellDeadliftViewModel(group.Title, group.Expanded);
                exercises.ExerciseItems = group.Count;
                if (group.Expanded)
                {
                    foreach (ExerciseBarbellDeadliftModel exercise in group)
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
