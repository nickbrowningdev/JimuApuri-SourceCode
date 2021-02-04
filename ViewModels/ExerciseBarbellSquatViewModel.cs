using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    // creates dropdown interface for exercise details
    public class ExerciseBarbellSquatViewModel : ObservableCollection<ExerciseBarbellSquatModel>, INotifyPropertyChanged
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

        public ExerciseBarbellSquatViewModel(string title, bool expanded = false)
        {
            Title = title;

            Expanded = expanded;
        }

        public static ObservableCollection<ExerciseBarbellSquatViewModel> Contents { private set; get; }

        static ExerciseBarbellSquatViewModel()
        {
            ObservableCollection<ExerciseBarbellSquatViewModel> Items = new ObservableCollection<ExerciseBarbellSquatViewModel>{

                new ExerciseBarbellSquatViewModel("Areas"){
                    new ExerciseBarbellSquatModel { Description = "Quads, Glutes, Hamstrings"},

                },
                new ExerciseBarbellSquatViewModel("Equipment"){
                    new ExerciseBarbellSquatModel {Description = "Barbell"},

                },
                new ExerciseBarbellSquatViewModel("Instructions"){
                    new ExerciseBarbellSquatModel {Description = "Stand straight with shoulder width apart. Place barbell on shoulders. " +
                    " Lower yourself and bend knees while keeping back straight. " +
                    " Stop and hold when thighs are parallel. Return to starting position"},


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
