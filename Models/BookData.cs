//initializing the colums of the datagrid//

using System;
using System.ComponentModel;

namespace JimuApuri.Models
{
    public class BookData : INotifyPropertyChanged
    {
        // Sets variables//
        private string day;

        private int bbpminutes;
        private int bbpamount;

        private int bdminutes;
        private int bdamount;

        private int bsminutes;
        private int bsamount;

        private int bcminutes;
        private int bcamount;

        private int bwcminutes;
        private int bwcamount;

        private int teminutes;
        private int teamount;

        private int wpminutes;
        private int wpamount;

        private int runminutes;
        private int rundistance;

        private int walkminutes;
        private int walkdistance;


        // create data columns along with allowing them to change the data within it//
        public string Day
        {
            get { return day; }
            set { this.day = value; }
        }

        public int BBPMinutes
        {
            get { return bbpamount; }
            set { this.bbpamount = value; }
        }
        public int BBPAmount
        {
            get { return bbpminutes; }
            set { this.bbpminutes = value; }
        }

        public int BDMinutes
        {
            get { return bdamount; }
            set { this.bdamount = value; }
        }
        public int BDAmount
        {
            get { return bdminutes; }
            set { this.bdminutes = value; }
        }

        public int BSMinutes
        {
            get { return bsamount; }
            set { this.bsamount = value; }
        }
        public int BSAmount
        {
            get { return bsminutes; }
            set { this.bsminutes = value; }
        }

        public int BCMinutes
        {
            get { return bcamount; }
            set { this.bcamount = value; }
        }
        public int BCAmount
        {
            get { return bcminutes; }
            set { this.bcminutes = value; }
        }

        public int BWCMinutes
        {
            get { return bwcamount; }
            set { this.bwcamount = value; }
        }
        public int BWCAmount
        {
            get { return bwcminutes; }
            set { this.bwcminutes = value; }
        }

        public int TEMinutes
        {
            get { return teamount; }
            set { this.teamount = value; }
        }
        public int TEAmount
        {
            get { return teminutes; }
            set { this.teminutes = value; }
        }

        public int WPMinutes
        {
            get { return wpamount; }
            set { this.wpamount = value; }
        }
        public int WPAmount
        {
            get { return wpminutes; }
            set { this.wpminutes = value; }
        }

        public int RunMinutes
        {
            get { return rundistance; }
            set { this.rundistance = value; }
        }
        public int RunDistance
        {
            get { return runminutes; }
            set { this.runminutes = value; }
        }

        public int WalkMinutes
        {
            get { return walkdistance; }
            set { this.walkdistance = value; }
        }
        public int WalkDistance
        {
            get { return walkminutes; }
            set { this.walkminutes = value; }
        }


        //Allows for property change needed for datagrid//
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
    }
}
