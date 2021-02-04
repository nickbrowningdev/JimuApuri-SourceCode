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
    public partial class ExerciseTricepExtensionView : ContentPage
    {
        // get contents
        private ObservableCollection<ExerciseTricepExtensionViewModel> getContents;
        private ObservableCollection<ExerciseTricepExtensionViewModel> _expandedContent;

        public ExerciseTricepExtensionView()
        {
            InitializeComponent();

            getContents = ExerciseTricepExtensionViewModel.Contents;
            UpdateListContent();
        }

        // when arrow is tapped
        private void HeaderTapped(object sender, EventArgs args)
        {
            int ListselectedIndex = _expandedContent.IndexOf(((ExerciseTricepExtensionViewModel)((Button)sender).CommandParameter));
            getContents[ListselectedIndex].Expanded = !getContents[ListselectedIndex].Expanded;
            UpdateListContent();
        }

        // updates content
        private void UpdateListContent()
        {
            _expandedContent = new ObservableCollection<ExerciseTricepExtensionViewModel>();
            foreach (ExerciseTricepExtensionViewModel group in getContents)
            {
                ExerciseTricepExtensionViewModel exercises = new ExerciseTricepExtensionViewModel(group.Title, group.Expanded);
                exercises.ExerciseItems = group.Count;
                if (group.Expanded)
                {
                    foreach (ExerciseTricepExtensionModel exercise in group)
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
