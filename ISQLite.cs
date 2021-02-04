using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using JimuApuri.Models;

namespace JimuApuri
{
    public interface ISQLite
    {
        // establishes SQL connection
        SQLiteConnection GetConnectionWithCreateDatabase();

        // saves workout model information
        bool SaveExercise(WorkoutExerciseModel workoutexercise);

        // gets all workout exercises made for plan
        List<WorkoutExerciseModel> GetWorkoutExercises();

        // changes name of exercise
        bool UpdateExercise(WorkoutExerciseModel workoutexercise);

        // deletes exercise (for android users only)
        void DeleteExercise(int Id);

        // deletes exercise (for android and iOS users)
        bool DeleteExerciseAlt(WorkoutExerciseModel workoutexercise);
    }
}
