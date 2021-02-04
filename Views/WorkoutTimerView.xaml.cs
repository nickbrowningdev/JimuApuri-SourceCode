using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JimuApuri.Views
{
    public partial class WorkoutTimerView : ContentPage
    {
        // implementing stop watch mobile feature
        Stopwatch stopwatch;

        public WorkoutTimerView()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();

            // default text
            lblStopwatch.Text = "00:00:00";
        }

        // stopwatch starts/running
        private void btnStart_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(0), () =>
                {
                    // convert stopwatch value to string
                    lblStopwatch.Text = stopwatch.Elapsed.ToString();

                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }

                );
            }
        }

        // stopwatch stops
        private void btnStop_Clicked(object sender, EventArgs e)
        {
            btnStart.Text = "Resume";
            stopwatch.Stop();
        }

        // stopwatch reset
        private void btnReset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch.Text = "00:00:00";
            btnStart.Text = "Start";
            stopwatch.Reset();
        }

    }
}
