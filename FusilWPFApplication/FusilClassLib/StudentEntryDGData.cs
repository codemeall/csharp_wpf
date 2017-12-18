using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class StudentEntryDGData : INotifyPropertyChanged
    {
        string id = string.Empty;
        string name = string.Empty;
        string gender = string.Empty;
        string mobileNo = string.Empty;
        string classs = string.Empty;

        public string Id
        {
            get 
            { 
                return id; 
            }
            set 
            {
                id = value;
                FirePropertyChanged("Id");
            }
        }
        

        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            {
                name = value;
                FirePropertyChanged("Name");
            }
        }
        

        public string Gender
        {
            get 
            { 
                return gender; 
            }
            set 
            {
                gender = value;
                FirePropertyChanged("Gender");
            }
        }
        

        public string MobileNo
        {
            get 
            { 
                return mobileNo; 
            }
            set 
            { 
                mobileNo = value;
                FirePropertyChanged("MobileNo");
            }
        }
        

        public string Classs
        {
            get
            {
                return classs;
            }
            set 
            { 
                classs = value;
                FirePropertyChanged("Classs");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void FirePropertyChanged( string PropertyName )
        {
            if (PropertyChanged != null)
            {
                if(!string.IsNullOrEmpty(PropertyName))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
 
        }
    }
}
