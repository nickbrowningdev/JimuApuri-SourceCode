using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimuApuri.Models
{
    // this model is used to interact with WorkoutPlanner and AddExercise
    public class WorkoutExerciseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
