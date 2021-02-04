using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JimuApuri.iOS;
using Foundation;
using SQLite;
using JimuApuri.Models;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace JimuApuri.iOS
{
    // sql queries for iOS
    public class SQLite_iOS : ISQLite
    {
        SQLiteConnection con;

        // establishing sql connection
        public SQLiteConnection GetConnectionWithCreateDatabase()
        {
            string fileName = "workoutexerciseDatabase.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            con = new SQLiteConnection(path);
            con.CreateTable<WorkoutExerciseModel>();
            return con;
        }

        // save exercise
        public bool SaveExercise(WorkoutExerciseModel workoutexercise)
        {
            bool res = false;
            try
            {
                con.Insert(workoutexercise);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }

        // get all workouts 
        public List<WorkoutExerciseModel> GetWorkoutExercises()
        {
            string sql = "SELECT * FROM WorkoutExerciseModel";
            List<WorkoutExerciseModel> workoutexercise = con.Query<WorkoutExerciseModel>(sql);
            return workoutexercise;
        }

        // update workout
        public bool UpdateExercise(WorkoutExerciseModel workoutexercise)
        {
            bool res = false;
            try
            {
                string sql = $"UPDATE WorkoutExerciseModel SET Name='{workoutexercise.Name}'" +
                                $"WHERE Id={workoutexercise.Id}";
                con.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }

        // delete workout
        public void DeleteExercise(int Id)
        {
            string sql = $"DELETE FROM WorkoutExerciseModel WHERE Id={Id}";
            con.Execute(sql);
        }

        // delete exercise but, established for iOS devices due to technical differences between an Android and iOS
        public bool DeleteExerciseAlt(WorkoutExerciseModel workoutexercise)
        {
            bool res = false;
            try
            {
                string sql = $"DELETE FROM WorkoutExerciseModel WHERE Name='{workoutexercise.Name}'" +
                                $"AND Id={workoutexercise.Id}";
                con.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
    }

}
