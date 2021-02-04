using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    // creates dropdown interface for exercise details
    public class ExerciseBarbellDeadliftViewModel : ObservableCollection<ExerciseBarbellDeadliftModel>, INotifyPropertyChanged
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

        public ExerciseBarbellDeadliftViewModel(string title, bool expanded = false)
        {
            Title = title;

            Expanded = expanded;
        }

        public static ObservableCollection<ExerciseBarbellDeadliftViewModel> Contents { private set; get; }

        static ExerciseBarbellDeadliftViewModel()
        {
            ObservableCollection<ExerciseBarbellDeadliftViewModel> Items = new ObservableCollection<ExerciseBarbellDeadliftViewModel>{

                new ExerciseBarbellDeadliftViewModel("Areas"){
                    new ExerciseBarbellDeadliftModel { Description = "Lower Back, Glutes, Lats"},

                },
                new ExerciseBarbellDeadliftViewModel("Equipment"){
                    new ExerciseBarbellDeadliftModel {Description = "Barbell"},

                },
                new ExerciseBarbellDeadliftViewModel("Instructions"){
                    new ExerciseBarbellDeadliftModel {Description = "Place barbell on floor. Position yourself with knees close to bar." +
                                                        " Lower yourself while keeping back straight. Pull barbell up and hold for one second." +
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
