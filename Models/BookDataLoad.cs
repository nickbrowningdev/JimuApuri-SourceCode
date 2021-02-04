// Used to generate the days of the week for all the datagrids //
using System.Collections.ObjectModel;

namespace JimuApuri.Models
{
    public class BookDataLoad
    {
        //creates and calls to a variable//
        public string week;
        public ObservableCollection<BookData> CollectData(int count)
        {
            //links the ViewModel//
            ObservableCollection<BookData> bookdays = new ObservableCollection<BookData>();
            //runs a loop until the i becomes 6 as declared in ViewModel//
            for (int i = 0; i <= count; i++)
            {
                if (i == 0)
                {
                    week = "Monday";
                }
                if (i == 1)
                {
                    week = "Tuesday";
                }
                if (i == 2)
                {
                    week = "Wednesday";
                }
                if (i == 3)
                {
                    week = "Thursday";
                }
                if (i == 4)
                {
                    week = "Friday";
                }
                if (i == 5)
                {
                    week = "Saturday";
                }
                if (i == 6)
                {
                    week = "Sunday";
                }
                //======================================
                //Reference P7: personal assistance
                //Purpose: needed help on connecting the day from Bookdata
                //Date: 18/10/2019
                //Source: online chat with Balasubramani Sundaram
                //Assistence: explains how i could go about connecting it
                //======================================
                //sets the selected week to the Day//
                var d = new BookData()
                {
                    Day = week,
                };
                bookdays.Add(d);
                //======================================
                //End reference P7
                //======================================


            }
            //returns the output to ViewModel//
            return bookdays;
        }

    }
}
