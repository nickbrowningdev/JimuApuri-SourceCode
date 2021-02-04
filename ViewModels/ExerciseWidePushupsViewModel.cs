using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    // creates dropdown interface for exercise details
    public class ExerciseWidePushupsViewModel : ObservableCollection<ExerciseWidePushupsModel>, INotifyPropertyChanged
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

        public ExerciseWidePushupsViewModel(string title, bool expanded = false)
        {
            Title = title;

            Expanded = expanded;
        }

        public static ObservableCollection<ExerciseWidePushupsViewModel> Contents { private set; get; }

        static ExerciseWidePushupsViewModel()
        {
            ObservableCollection<ExerciseWidePushupsViewModel> Items = new ObservableCollection<ExerciseWidePushupsViewModel>{

                new ExerciseWidePushupsViewModel("Areas"){
                    new ExerciseWidePushupsModel { Description = "Pecs, Front Deltoids, Triceps"},

                },
                new ExerciseWidePushupsViewModel("Equipment"){
                    new ExerciseWidePushupsModel {Description = "Bodyweight"},

                },
                new ExerciseWidePushupsViewModel("Instructions"){
                    new ExerciseWidePushupsModel {Description = "Lie down chest first with your hands on the floor. Position hands next to your lower chest. Increase distance between hands while keeping a straight back" +
                    " Lower chest inches off ground by bending elbows. Hold for one second and return to start position"},


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
