using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class TreeStudentData : INotifyPropertyChanged
    {
        int isGroup = 0;
        string name = string.Empty;
        string group = string.Empty;
        string mobileNo = string.Empty;
        string email = string.Empty;
        string groupName = string.Empty;
        string groupsGroup = string.Empty;

        public int IsGroup
        {
            get 
            { 
                return isGroup; 
            }
            set 
            { 
                isGroup = value;
                FirePropertyChanged("IsGroup");
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
        

        public string Group
        {
            get 
            { 
                return group; }
            set 
            { 
                group = value;
                FirePropertyChanged("Group");
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
        

        public string Email
        {
            get 
            { 
                return email;
            }
            set 
            { 
                email = value;
                FirePropertyChanged("Email");
            }
        }

        
        public string GroupName
        {
            get 
            { 
                return groupName; 
            }
            set 
            { 
                groupName = value;
                FirePropertyChanged("GroupName");
            }
        }

        

        public string GroupsGroup
        {
            get 
            { 
                return groupsGroup; 
            }
            set 
            { 
                groupsGroup = value;
                FirePropertyChanged("GroupsGroup");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
