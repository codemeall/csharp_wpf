using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class ProjectStudentData : INotifyPropertyChanged
    {
        #region Attribute Declaration
        string id = string.Empty;
        string name = string.Empty;
        string classes = string.Empty;
        string rollno = string.Empty;
        bool male = false;
        bool female = false;
        #endregion

        #region Setting Properties of Attributes
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
        
        public string Classes
        {
            get 
            { 
                return classes; 
            }
            set 
            { 
                classes = value;
                FirePropertyChanged("Classes");
            }
        }

        public string Rollno
        {
            get 
            { 
                return rollno;
            }
            set 
            { 
                rollno = value;
                FirePropertyChanged("Rollno");
            }
        }
        
        public bool Male
        {
            get 
            { 
                return male;
            }
            set 
            { 
                male = value;
                FirePropertyChanged("Male");
            }
        }

        public bool Female
        {
            get 
            {
                return female;
            }
            set 
            { 
                female = value;
                FirePropertyChanged("Female");
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Event Method
        private void FirePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                if (!string.IsNullOrEmpty(PropertyName))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }

        }
        #endregion

    }
}
