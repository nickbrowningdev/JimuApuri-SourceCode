using System.Collections.ObjectModel;
using System.ComponentModel;
using JimuApuri.Models;

namespace JimuApuri.ViewModels
{
    public class LogbookViewModel : INotifyPropertyChanged
    {
        //declares variables//
        private BookDataLoad BookDatas;
        private ObservableCollection<BookData> bookData;

        //======================================
        //Reference P7: personal assistance
        //Purpose: need colelcted data to be sent to the pages
        //Date: 18/10/2019
        //Source: online chat with Balasubramani Sundaram
        //Assistence: explains how i collect and send the data
        //Helped out in data the most
        //======================================

        //Viewmodel used to hold data for pages//
        public LogbookViewModel()
        {
            BookDatas = new BookDataLoad();
            GenerateRows();
        }

        //gets bookdata and sets it//
        public ObservableCollection<BookData> data
        {
            get { return bookData; }
            set
            {
                bookData = value;
                RaisePropertyChanged("BookData");
            }
        }

        //Used to define how many rows will be created//
        private void GenerateRows()
        {
            bookData = BookDatas.CollectData(6);
        }

        //======================================
        //End reference P7
        //======================================

        //Allows for property change needed for datagrid/
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }
    }
}
