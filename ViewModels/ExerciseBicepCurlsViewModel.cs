using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    // creates dropdown interface for exercise details
    public class ExerciseBicepCurlsViewModel : ObservableCollection<ExerciseBicepCurlsModel>, INotifyPropertyChanged
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

        public ExerciseBicepCurlsViewModel(string title, bool expanded = false)
        {
            Title = title;

            Expanded = expanded;
        }

        public static ObservableCollection<ExerciseBicepCurlsViewModel> Contents { private set; get; }

        static ExerciseBicepCurlsViewModel()
        {
            ObservableCollection<ExerciseBicepCurlsViewModel> Items = new ObservableCollection<ExerciseBicepCurlsViewModel>{

                new ExerciseBicepCurlsViewModel("Areas"){
                    new ExerciseBicepCurlsModel { Description = "Biceps, Forearms, Wrist Flexors"},

                },
                new ExerciseBicepCurlsViewModel("Equipment"){
                    new ExerciseBicepCurlsModel {Description = "Dumbbell"},

                },
                new ExerciseBicepCurlsViewModel("Instructions"){
                    new ExerciseBicepCurlsModel {Description = "Hold dumbbells next to sides and keep arms straight. " +
                    " Lift dumbells up." +
                    " Hold for one seconds and return to starting position."},


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
