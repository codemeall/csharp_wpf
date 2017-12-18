using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class RegistrationData : INotifyPropertyChanged
    {
        string userId = string.Empty;
        string firstName = string.Empty;
        string lastName = string.Empty;
        string fatherName = string.Empty;
        DateTime dob = DateTime.Now;
        string mobileNo = string.Empty;
        string email = string.Empty;
        string address = string.Empty;
        string filter = string.Empty;


        public string UserId
        {
            get 
            { 
                return userId;
            }
            set 
            { 
                userId = value;
                FirePropertyChanged("UserId");
            }
        }
        

        public string FirstName
        {
            get 
            { 
                return firstName; 
            }
            set 
            { 
                firstName = value;
                FirePropertyChanged("FirstName");
            }
        }

        

        public string LastName
        {
            get 
            { 
                return lastName;
            }
            set 
            { 
                lastName = value;
                FirePropertyChanged("LastName");
            }
        }
        

        public string FatherName
        {
            get 
            { 
                return fatherName; 
            }
            set 
            { 
                fatherName = value;
                FirePropertyChanged("FatherName");
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
        

        public string Address
        {
            get 
            { 
                return address;
            }
            set 
            { 
                address = value;
                FirePropertyChanged("Address");
            }
        }

        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                FirePropertyChanged("Filter");
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
