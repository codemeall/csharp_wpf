using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class EmailData : INotifyPropertyChanged
    {
        string emailId = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;
        string password = string.Empty;
        string mobileno = string.Empty;
        string gender = string.Empty;
        DateTime dob = DateTime.Now;
        string browse = string.Empty;

        public string Email
        {
            get 
            { 
                return emailId; 
            }
            set 
            { 
                emailId = value;
                FirePropertyChanged("Email");
            }
        }
        

        public string Firstname
        {
            get 
            { 
                return firstname; 
            }
            set 
            { 
                firstname = value;
                FirePropertyChanged("Firstname");
            }
        }
        

        public string Lastname
        {
            get 
            { 
                return lastname; 
            }
            set 
            { 
                lastname = value;
                FirePropertyChanged("Lastname");
            }
        }
        

        public string Password
        {
            get
            { 
                return password;
            }
            set
            { 
                password = value;
                FirePropertyChanged("Password");
            }
        }
        

        public string Mobileno
        {
            get 
            { 
                return mobileno;
            }
            set 
            { 
                mobileno = value;
                FirePropertyChanged("Mobileno");
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
        
        
        public DateTime Dob
        {
            get 
            { 
                return dob;
            }
            set 
            {
                dob = value;
                FirePropertyChanged("Dob");
            }
        }

        public string Browse
        {
            get 
            {
                return browse;
            }
            set
            {
                browse = value;
                FirePropertyChanged("Browse");
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
