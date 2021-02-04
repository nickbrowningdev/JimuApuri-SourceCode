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
    public partial class ExerciseBarbellSquatView : ContentPage
    {
        // get contents
        private ObservableCollection<ExerciseBarbellSquatViewModel> getContents;
        private ObservableCollection<ExerciseBarbellSquatViewModel> _expandedContent;

        public ExerciseBarbellSquatView()
        {
            InitializeComponent();

            getContents = ExerciseBarbellSquatViewModel.Contents;
            UpdateListContent();
        }

        // when arrow is tapped
        private void HeaderTapped(object sender, EventArgs args)
        {
            int ListselectedIndex = _expandedContent.IndexOf(((ExerciseBarbellSquatViewModel)((Button)sender).CommandParameter));
            getContents[ListselectedIndex].Expanded = !getContents[ListselectedIndex].Expanded;
            UpdateListContent();
        }

        // updates content
        private void UpdateListContent()
        {
            _expandedContent = new ObservableCollection<ExerciseBarbellSquatViewModel>();
            foreach (ExerciseBarbellSquatViewModel group in getContents)
            {
                ExerciseBarbellSquatViewModel exercises = new ExerciseBarbellSquatViewModel(group.Title, group.Expanded);
                exercises.ExerciseItems = group.Count;
                if (group.Expanded)
                {
                    foreach (ExerciseBarbellSquatModel exercise in group)
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
