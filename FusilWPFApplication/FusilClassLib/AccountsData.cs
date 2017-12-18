using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FusilClassLib
{
    public class AccountsData : INotifyPropertyChanged
    {
        string sno = string.Empty;
        string name = string.Empty;
        string taxClass = string.Empty;
        string code = string.Empty;
        string desc = string.Empty;
        decimal taxRate = decimal.Zero;
        string narration = string.Empty;
        string filter = string.Empty;
        
        public string Sno
        {
            get 
            { 
                return sno; 
            }
            set 
            { 
                sno = value;
                FirePropertyChanged("Sno");
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
        

        public string TaxClass
        {
            get 
            { 
                return taxClass; 
            }
            set 
            { 
                taxClass = value;
                FirePropertyChanged("TaxClass");
            }
        }
        

        public string Code
        {
            get 
            { 
                return code; 
            }
            set 
            { 
                code = value;
                FirePropertyChanged("Code");
            }
        }
        

        public string Desc
        {
            get 
            { 
                return desc; 
            }
            set 
            { 
                desc = value;
                FirePropertyChanged("Desc");
            }
        }
        

        public decimal TaxRate
        {
            get 
            { 
                return taxRate; 
            }
            set 
            { 
                taxRate = value;
                FirePropertyChanged("TaxRate");
            }
        }
        

        public string Narration
        {
            get 
            {
                return narration;
            }
            set 
            { 
                narration = value;
                FirePropertyChanged("Narration");
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

        public void FirePropertyChanged(string PropertyName)
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
