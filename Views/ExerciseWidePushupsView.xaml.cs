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
    public partial class ExerciseWidePushupsView : ContentPage
    {
        // get contents
        private ObservableCollection<ExerciseWidePushupsViewModel> getContents;
        private ObservableCollection<ExerciseWidePushupsViewModel> _expandedContent;

        public ExerciseWidePushupsView()
        {
            InitializeComponent();

            getContents = ExerciseWidePushupsViewModel.Contents;
            UpdateListContent();
        }

        // when arrow is tapped
        private void HeaderTapped(object sender, EventArgs args)
        {
            int ListselectedIndex = _expandedContent.IndexOf(((ExerciseWidePushupsViewModel)((Button)sender).CommandParameter));
            getContents[ListselectedIndex].Expanded = !getContents[ListselectedIndex].Expanded;
            UpdateListContent();
        }

        // updates content
        private void UpdateListContent()
        {
            _expandedContent = new ObservableCollection<ExerciseWidePushupsViewModel>();
            foreach (ExerciseWidePushupsViewModel group in getContents)
            {
                ExerciseWidePushupsViewModel exercises = new ExerciseWidePushupsViewModel(group.Title, group.Expanded);
                exercises.ExerciseItems = group.Count;
                if (group.Expanded)
                {
                    foreach (ExerciseWidePushupsModel exercise in group)
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
