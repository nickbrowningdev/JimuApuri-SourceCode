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
    public partial class ExerciseBarbellBenchPressView : ContentPage
    {
        // get contents
        private ObservableCollection<ExerciseBarbellBenchPressViewModel> getContents;
        private ObservableCollection<ExerciseBarbellBenchPressViewModel> _expandedContent;

        public ExerciseBarbellBenchPressView()
        {
            InitializeComponent();

            getContents = ExerciseBarbellBenchPressViewModel.Contents;
            UpdateListContent();
        }
        
        // when arrow is tapped
        private void HeaderTapped(object sender, EventArgs args)
        {
            int ListselectedIndex = _expandedContent.IndexOf(((ExerciseBarbellBenchPressViewModel)((Button)sender).CommandParameter));
            getContents[ListselectedIndex].Expanded = !getContents[ListselectedIndex].Expanded;
            UpdateListContent();
        }

        // updates content
        private void UpdateListContent()
        {
            _expandedContent = new ObservableCollection<ExerciseBarbellBenchPressViewModel>();
            foreach (ExerciseBarbellBenchPressViewModel group in getContents)
            {
                ExerciseBarbellBenchPressViewModel exercises = new ExerciseBarbellBenchPressViewModel(group.Title, group.Expanded);
                exercises.ExerciseItems = group.Count;
                if (group.Expanded)
                {
                    foreach (ExerciseBarbellBenchPressModel exercise in group)
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
