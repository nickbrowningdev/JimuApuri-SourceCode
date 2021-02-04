using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JimuApuri.Models;
using JimuApuri.ViewModels;
using JimuApuri.Views;
using SQLite;
using SQLitePCL;

namespace JimuApuri
{
    public partial class App : Application
    {
        public App()
        {
            LogbookMainMenuViewModel._ViewModel = new LogbookViewModel();
            InitializeComponent();

            // creates SQL connection
            SQLiteConnection sQLiteConnection = DependencyService.Get<ISQLite>().GetConnectionWithCreateDatabase();

            // starts at HomePageView
            MainPage = new NavigationPage(new Views.HomePageView())
            {
                BarBackgroundColor = Color.White,
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
