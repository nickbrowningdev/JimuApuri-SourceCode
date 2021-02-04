using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    // creates dropdown interface for exercise details
    public class ExerciseBodyweightCrunchViewModel : ObservableCollection<ExerciseBodyweightCrunchModel>, INotifyPropertyChanged
    {
        private bool _expanded;
        public string Title { get; set; }

        public string ShortName { get; set; }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string StateIcon
        {
            get { return Expanded ? "expand_arrow.png" : "collapse_arrow.png"; }
        }

        public int ExerciseItems { get; set; }

        public ExerciseBodyweightCrunchViewModel(string title, bool expanded = false)
        {
            Title = title;

            Expanded = expanded;
        }

        public static ObservableCollection<ExerciseBodyweightCrunchViewModel> Contents { private set; get; }

        static ExerciseBodyweightCrunchViewModel()
        {
            ObservableCollection<ExerciseBodyweightCrunchViewModel> Items = new ObservableCollection<ExerciseBodyweightCrunchViewModel>{

                new ExerciseBodyweightCrunchViewModel("Areas"){
                    new ExerciseBodyweightCrunchModel { Description = "Pecs, Front Deltoids, Triceps"},

                },
                new ExerciseBodyweightCrunchViewModel("Equipment"){
                    new ExerciseBodyweightCrunchModel {Description = "Bodyweight"},

                },
                new ExerciseBodyweightCrunchViewModel("Instructions"){
                    new ExerciseBodyweightCrunchModel {Description = "Lie down on floor with feet flat. Hands behind head " +
                    " Raise upper body upward while keeping lower back on floor." +
                    " Return to starting position."},


                } };
            Contents = Items;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}