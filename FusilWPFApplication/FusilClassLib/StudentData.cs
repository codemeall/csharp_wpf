using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class StudentData : INotifyPropertyChanged
    {
        string id = string.Empty;

        public string Id
        {
            get
            { 
                return id; 
            }
            set 
            {
                id = value;
                FirePropertyChange("Id");
            }
        }

        string name = string.Empty;

        public string Name
        {
            get 
            { 
                return name;
            }
            set 
            { 
                name = value;
                FirePropertyChange("Name");
            }
        }

        string classes = string.Empty;

        public string Classes
        {
            get 
            { 
                return classes;
            }
            set 
            { 
                classes = value;
                FirePropertyChange("Classes");
            }
        }

        string rollno = string.Empty;

        public string Rollno
        {
            get 
            { 
                return rollno; 
            }
            set 
            { 
                rollno = value;
                FirePropertyChange("Rollno");
            }
        }

        bool gender = false;

        public bool Gender
        {
            get 
            { 
                return gender; 
            }
            set 
            { 
                gender = value;
                FirePropertyChange("Gender");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChange(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                if (!string.IsNullOrEmpty(PropertyName))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
        }
    }
}
