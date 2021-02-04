using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    // creates dropdown interface for exercise details
    public class ExerciseBarbellBenchPressViewModel : ObservableCollection<ExerciseBarbellBenchPressModel>, INotifyPropertyChanged
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

        // changes icon when selected
        public string StateIcon
        {
            get { return Expanded ? "expand_arrow.png" : "collapse_arrow.png"; }
        }

        public int ExerciseItems { get; set; }

        public ExerciseBarbellBenchPressViewModel(string title, bool expanded = false)
        {
            Title = title;

            Expanded = expanded;
        }

        public static ObservableCollection<ExerciseBarbellBenchPressViewModel> Contents { private set; get; }

        static ExerciseBarbellBenchPressViewModel()
        {
            ObservableCollection<ExerciseBarbellBenchPressViewModel> Items = new ObservableCollection<ExerciseBarbellBenchPressViewModel>{

                new ExerciseBarbellBenchPressViewModel("Areas"){
                    new ExerciseBarbellBenchPressModel { Description = "Pecs, Triceps, Front Deltoids"},

                },
                new ExerciseBarbellBenchPressViewModel("Equipment"){
                    new ExerciseBarbellBenchPressModel {Description = "Barbell, Bench"},

                },
                new ExerciseBarbellBenchPressViewModel("Instructions"){
                    new ExerciseBarbellBenchPressModel {Description = "Lie back on a flat bench. Hold the barbell with overhand grip. Distance your hands slightly wider than shoulder width. " +
                    " Make sure the barbell is directly above chest. Lower barbell to chest while keeping elobows close to body." +
                    " Hold for 1 second and return to starting point."},


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
