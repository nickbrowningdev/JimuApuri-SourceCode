using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    // creates dropdown interface for exercise details
    public class ExerciseTricepExtensionViewModel : ObservableCollection<ExerciseTricepExtensionModel>, INotifyPropertyChanged
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

        public ExerciseTricepExtensionViewModel(string title, bool expanded = false)
        {
            Title = title;

            Expanded = expanded;
        }

        public static ObservableCollection<ExerciseTricepExtensionViewModel> Contents { private set; get; }

        static ExerciseTricepExtensionViewModel()
        {
            ObservableCollection<ExerciseTricepExtensionViewModel> Items = new ObservableCollection<ExerciseTricepExtensionViewModel>{

                new ExerciseTricepExtensionViewModel("Areas"){
                    new ExerciseTricepExtensionModel { Description = "Pecs, Triceps"},

                },
                new ExerciseTricepExtensionViewModel("Equipment"){
                    new ExerciseTricepExtensionModel {Description = "Barbell"},

                },
                new ExerciseTricepExtensionViewModel("Instructions"){
                    new ExerciseTricepExtensionModel {Description = "Stand straight with feet shoulder width apart. " +
                    " Hold barbell with shoulder width and fully extend arms overhead." +
                    " Lower barbell until behind head. Hold for one second. Return to starting position."},


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
