using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    public class SearchExerciseListViewModel
    {
        public ObservableCollection<SearchExerciseListModel> MyExerciseCollector { get; set; }

        // creates listview information
        public SearchExerciseListViewModel()
        {
            MyExerciseCollector = new ObservableCollection<SearchExerciseListModel>()
            {
                new SearchExerciseListModel(){Id=1, ExerciseName="Wide Pushups", ExerciseDetail="Pecs, Front Deltoids, Triceps"},
                new SearchExerciseListModel(){Id=2, ExerciseName="Bicep Curls", ExerciseDetail="Biceps, Forearms, Wrist Flexors"},
                new SearchExerciseListModel(){Id=3, ExerciseName="Barbell Tricep Extension", ExerciseDetail="Pecs, Triceps"},
                new SearchExerciseListModel(){Id=4, ExerciseName="Barbell Bench Press", ExerciseDetail="Pecs, Front Deltoids, Triceps"},
                new SearchExerciseListModel(){Id=5, ExerciseName="Barbell Squat", ExerciseDetail="Quads, Glutes, Hamstrings"},
                new SearchExerciseListModel(){Id=6, ExerciseName="Barbell Deadlift", ExerciseDetail="Lower Back, Glutes, Lats"},
                new SearchExerciseListModel(){Id=7, ExerciseName="Bodyweight Crunch", ExerciseDetail="Pecs, Front Deltoids, Triceps"}
            };
        }
    }
}
