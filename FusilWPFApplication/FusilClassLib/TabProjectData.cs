using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class TabProjectData : INotifyPropertyChanged
    {
        string email = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;
        string password = string.Empty;
        string mobileno = string.Empty;
        string gender = string.Empty;
        DateTime dob = DateTime.Now;
        string browse = string.Empty;
        string name = string.Empty;
        string model = string.Empty;
        decimal rate = decimal.Zero;
        decimal tax = decimal.Zero;
        decimal acc = decimal.Zero;
        decimal total = decimal.Zero;
        decimal disc = decimal.Zero;
        decimal discRate = decimal.Zero;
        decimal final = decimal.Zero;

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
        

        public string Model
        {
            get 
            { 
                return model; 
            }
            set 
            { 
                model = value;
                FirePropertyChanged("Model");
            }
        }
        

        public decimal Rate
        {
            get 
            { 
                return rate;
            }
            set 
            { 
                rate = value;
                FirePropertyChanged("Rate");
            }
        }
        

        public decimal Tax
        {
            get 
            { 
                return tax;
            }
            set 
            { 
                tax = value;
                FirePropertyChanged("Tax");
            }
        }
        

        public decimal Acc
        {
            get 
            { 
                return acc;
            }
            set 
            { 
                acc = value;
                FirePropertyChanged("Acc");
            }
        }
        

        public decimal Total
        {
            get 
            {
                return total;
            }
            set 
            { 
                total = value;
                FirePropertyChanged("Total");
            }
        }
        

        public decimal Disc
        {
            get 
            { 
                return disc;
            }
            set 
            { 
                disc = value;
                FirePropertyChanged("Disc");
            }
        }
        

        public decimal DiscRate
        {
            get 
            { 
                return discRate;
            }
            set 
            { 
                discRate = value;
                FirePropertyChanged("DiscRate");
            }
        }
        

        public decimal Final
        {
            get 
            { 
                return final; 
            }
            set 
            { 
                final = value;
                FirePropertyChanged("Final");
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
                    if (PropertyName.Equals("Rate"))
                    {
                        Calculation();
                    }
                    if (PropertyName == "Tax")
                    {
                        Calculation();
                    }
                    if (PropertyName == "Acc")
                    {
                        Calculation();
                    }
                    if (PropertyName == "Disc")
                    {
                        Calculation();
                    }
                }
            }

        }

        public void Calculation()
        {
            Total = Rate + Tax + Acc;
            if (Disc > 0)
            {
                DiscRate = Total * Disc / 100;
            }
            Final = Total - DiscRate;
        }
    }
}
