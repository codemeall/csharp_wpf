using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows;


namespace FusilClassLib
{
    public class TabProjectViewModel
    {        
        string password = string.Empty;
        string filepath = string.Empty;
        public TabProjectData td;
        public List<string> combo = new List<string>();
        public TabProjectViewModel()
        {
            td = new TabProjectData();
            combo = GenderList();
        }

        public List<string> GenderList()
        {
            List<string> list = new List<string>();
            list.Add("Male");
            list.Add("Female");

            return list;
        }

        public void Clear()
        {
            td.Email = string.Empty;
            td.Firstname = string.Empty;
            td.Lastname = string.Empty;
            td.Password = string.Empty;
            td.Dob = DateTime.Now;
            td.Mobileno = string.Empty;            
            td.Name = string.Empty;
            td.Model = string.Empty;
            td.Rate = decimal.Zero;
            td.Tax = decimal.Zero;
            td.Acc = decimal.Zero;
            td.Total = decimal.Zero;
            td.Disc = decimal.Zero;
            td.DiscRate = decimal.Zero;
            td.Final = decimal.Zero;
        }


        public XElement Email()
        {

            XElement xe = new XElement("EmailData", new XAttribute("Email", td.Email),
                                                    new XAttribute("FirstName", td.Firstname),
                                                    new XAttribute("LastName", td.Lastname),
                                                    new XAttribute("Password", password),
                                                    new XAttribute("MobileNo", td.Mobileno),
                                                    new XAttribute("Gender", td.Gender),
                                                    new XAttribute("Dob", td.Dob.ToShortDateString()));
            return xe;
        }
        

        public XElement Vehicle()
        {
            XElement xv = new XElement("VehicleData", new XAttribute("Name", td.Name),
                                                    new XAttribute("Model", td.Model),
                                                    new XAttribute("Rate", td.Rate),
                                                    new XAttribute("Tax", td.Tax),
                                                    new XAttribute("Acc", td.Acc),
                                                    new XAttribute("Total", td.Total),
                                                    new XAttribute("Disc", td.Disc),
                                                    new XAttribute("DiscRate", td.DiscRate),
                                                    new XAttribute("Final", td.Final));
            return xv;
        }



        public XElement AddEmail()
        {
            XElement em = new XElement("Email");
            em.Add(Email());
            return em;
        }


        public XElement AddVehicle()
        {
            XElement ev = new XElement("Vehicle");
            ev.Add(Vehicle());
            return ev;
        }
        public bool EmailValidations()
        {
            if (!string.IsNullOrEmpty(td.Email) && !string.IsNullOrEmpty(td.Firstname))
            {
                return true; 
            }
            else if(!string.IsNullOrEmpty(td.Email) && string.IsNullOrEmpty(td.Firstname))
            {
                MessageBox.Show("Enter First Name");
            }
            else if (string.IsNullOrEmpty(td.Email) && !string.IsNullOrEmpty(td.Firstname))
            {
                MessageBox.Show("Enter Email field");
            }
            return false;
        }

        public bool VehicleValidations()
        {
            if (!string.IsNullOrEmpty(td.Name) && td.Rate > decimal.Zero)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(td.Name) && td.Rate > decimal.Zero)
            {
                MessageBox.Show("Name Field should not be empty");
            }
            else if (!string.IsNullOrEmpty(td.Name) && td.Rate <= decimal.Zero)
            {
                MessageBox.Show("Enter the Rate"); 
            }
            return false;
            
        }

        public void NewFile()
        {
            XElement xd = new XElement("Data");
            if (EmailValidations())
                xd.Add(AddEmail());
            if (VehicleValidations())
                xd.Add(AddVehicle());
            xd.Save(filepath);
            System.Windows.Forms.MessageBox.Show("New File Created");

        }

        public bool Save()
        {
            XElement Data = new XElement("Data");
            filepath = td.Browse + "\\Data.xml";
            if (File.Exists(filepath))
            {
                string str = File.ReadAllText(filepath);
                XElement ele = XElement.Parse(str);
                if (ele != null && ele.HasElements)
                {
                    XElement Emailx = ele.Element("Email");
                    XElement Vehiclex = ele.Element("Vehicle");
                    
                    if (Emailx != null && Emailx.HasElements)
                    {
                        List<XElement> elist = Emailx.Elements().ToList();
                        List<XElement> elist1 = elist.Where(x => x.Attribute("Email").Value.Equals(td.Email)).ToList();
                        if (elist1 != null && elist1.Count == 0)
                        {
                            if (EmailValidations())
                                Emailx.Add(Email());
                        }
                        else
                        {
                            MessageBox.Show("Email Id Already Exist Try another one");
                            td.Email = string.Empty;
                            return false;
                        }
                    }
                    else
                    {
                        if (EmailValidations())
                        if (Emailx == null)
                        {
                            Data.Add(AddEmail());
                        }
                        else 
                        {
                            Emailx.Add(Email());
                        }
                    }

                    if (Vehiclex != null && Vehiclex.HasElements)
                    {
                        if (VehicleValidations())
                            Vehiclex.Add(Vehicle());
                    }
                    else
                    {
                        if (VehicleValidations())
                        if (Vehiclex == null)
                        {
                            Data.Add(AddVehicle());
                        }
                        else if (Vehiclex.HasElements == false)
                        {
                            Vehiclex.Add(Vehicle());
                        }
                    }
                    if ((td.Email != string.Empty && td.Firstname != string.Empty) || (td.Name != string.Empty && td.Rate > decimal.Zero))
                    {
                                                
                        MessageBoxResult result = MessageBox.Show("Do You Want to replace the File", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.No)
                        {
                            Data.Add(Emailx);
                            Data.Add(Vehiclex);
                            Data.Save(filepath);
                            MessageBox.Show("Data Saved Successfully");
                            return true;
                        }
                        else
                        {
                            NewFile();
                           
                            //if (EmailValidations())
                            //{
                            //   Emailx = AddEmail();
                            //}
                            //if (VehicleValidations())
                            //{
                            //    Vehiclex = AddVehicle();                     
                            //}
                            //XElement d = new XElement("Data");
                            //d.Add(Emailx);
                            //d.Add(Vehiclex);
                            //d.Save(filepath);
                            //MessageBox.Show("File Updated");
                        } 
                    }
                }
                else
                {
                    NewFile();
                }
            }
            else
            {
                NewFile();
                return true;
            }
            return false;
        }

        public bool SaveWin()
        {
            if (td.Browse != string.Empty)
            {
                if (EmailValidations() || VehicleValidations())
                {
                    if(Save())
                     return true;
                }
            }
            else
            {
                MessageBox.Show("Please Select File Path");
            }
            return false;
        }
        public void Password(string pass)
        {
            password = pass;
        }
        




        #region Add(Self)
        public XElement Add()
        {
            List<XElement> listx = new List<XElement>();
            XElement epresent = AddEmail();
            XElement vpresent = AddVehicle();
            if (!string.IsNullOrEmpty(td.Email))
            {
                if (!string.IsNullOrEmpty(td.Firstname))
                {
                    listx.Add(AddEmail());
                }
                else
                {
                    if (string.IsNullOrEmpty(td.Firstname))
                        MessageBox.Show("Enter First Name");
                }
            }
            if (!string.IsNullOrEmpty(td.Name))
            {
                if (td.Rate != decimal.Zero)
                {
                    listx.Add(AddVehicle());
                }
                else
                {
                    if (td.Rate == decimal.Zero)
                        MessageBox.Show("Enter Rate");
                } 
            }

            XElement x3 = new XElement("Data");
            if (td.Email != string.Empty || td.Name != string.Empty)
            {
                if (td.Firstname != string.Empty || td.Rate != decimal.Zero)
                {
                    x3.Add(listx);
                    x3.Save(filepath);
                    MessageBox.Show("Data Saved");
                    Clear();
                }

            }
            else
            {
                MessageBox.Show("Enter Details");
            }
            return x3;
        }
#endregion

        #region Submit Method(Self)
        public void Submit()
        {
            if (!string.IsNullOrEmpty(td.Browse))
            {
                filepath = td.Browse + "\\Data.xml";
                if (File.Exists(filepath))
                {
                    
                    XElement data = new XElement("Data");
                    string str = File.ReadAllText(filepath);
                    XElement Xele = XElement.Parse(str);
                    if (Xele != null && Xele.HasElements)
                    {
                          XElement EmailDataXele = Xele.Element("Email");
                            if (EmailDataXele != null && EmailDataXele.HasElements)
                            {
                                if (!string.IsNullOrEmpty(td.Email))
                                {
                                    if (!string.IsNullOrEmpty(td.Firstname))
                                    {
                                        EmailDataXele.Add(Email());
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(td.Email))
                                            MessageBox.Show("Enter Email field");
                                        else if (string.IsNullOrEmpty(td.Firstname))
                                            MessageBox.Show("Enter First Name field");
                                    }
                                }
                            }
                            else
                            {
                                if (EmailDataXele == null)
                                {
                                    if (!string.IsNullOrEmpty(td.Email))
                                    {
                                        if (!string.IsNullOrEmpty(td.Firstname))
                                        {
                                            data.Add(AddEmail());
                                        }
                                        else
                                        {
                                            MessageBox.Show("Enter First Name field");
                                        }
                                    }
                                }
                                else if (EmailDataXele.HasElements == false)
                                {
                                    if (td.Email != string.Empty)
                                    {
                                        if (td.Firstname != string.Empty)
                                        {
                                            EmailDataXele.Add(Email());
                                        }
                                        else
                                        {
                                            MessageBox.Show("Enter the First Name");
                                        }
                                    }
                                }
                            }
                            XElement VehicleDataXele = Xele.Element("Vehicle");
                            if (VehicleDataXele != null && VehicleDataXele.HasElements)
                            {
                                if (!string.IsNullOrEmpty(td.Name))
                                {
                                    if (td.Rate != decimal.Zero)
                                    {
                                        VehicleDataXele.Add(Vehicle());
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(td.Name))
                                            MessageBox.Show("Enter Name ");
                                        else if (td.Rate == decimal.Zero)
                                            MessageBox.Show("Enter Rate");
                                    }
                                }
                            }
                            else
                            {
                                if (VehicleDataXele == null)
                                {
                                    if (!string.IsNullOrEmpty(td.Name))
                                    {
                                        if (td.Rate != decimal.Zero)
                                        {
                                            data.Add(AddVehicle());
                                        }
                                        else
                                        {
                                            MessageBox.Show("Enter Rate Field");
                                            return;
                                        }
                                    }
                                }

                                else if (VehicleDataXele.HasElements == false)
                                {
                                    if (td.Name != null)
                                    {
                                        if (td.Rate != decimal.Zero)
                                        {
                                            VehicleDataXele.Add(Vehicle());
                                        }
                                        else
                                        {
                                            MessageBox.Show("Enter The Rate");
                                        }
                                    }
                                }
                            }

                            if (td.Email != string.Empty || td.Name != string.Empty)
                            {
                                if (td.Firstname != string.Empty || td.Rate != decimal.Zero)
                                {
                                    data.Add(EmailDataXele);
                                    data.Add(VehicleDataXele);
                                    if (!string.IsNullOrEmpty(td.Email) || !string.IsNullOrEmpty(td.Name))
                                    {
                                        MessageBoxResult result = MessageBox.Show("Do You Want to Replace ?", "coonfirmation", MessageBoxButton.YesNo);
                                        if (result == MessageBoxResult.No)
                                        {
                                            data.Save(filepath);
                                            MessageBox.Show("File Saved Successfully");
                                            Clear();
                                        }
                                        else
                                        {
                                            Add();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Data Is selected");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter the fields");
                            }
                        }
                        else
                        {
                            Add();
                            
                        }                   
                }
                else
                {
                    Add();
                    
                }
            }
            else
                MessageBox.Show("Select File Path");
        }
        #endregion

        #region ForEach Save Method
        public void SaveForEach()
        {
            filepath = td.Browse + "\\Data.xml";
            if (File.Exists(filepath))
            {
                string str = File.ReadAllText(filepath);
                XElement Xele = XElement.Parse(str);
                XElement email = new XElement("Email");
                XElement vehicle = new XElement("Vehicle");
                if (Xele != null && Xele.HasElements)
                {
                    List<XElement> list = new List<XElement>();
                    foreach (XElement ex in Xele.Elements())
                    {
                        if (ex.Name == "Email")
                        {
                            ex.Add(Email());
                            list.Add(ex);

                        }
                        if (ex.Name == "Vehicle")
                        {
                            ex.Add(Vehicle());
                            list.Add(ex);
                        }
                    }
                    XElement data = new XElement("Data");
                    data.Add(list);
                    data.Save(filepath);
                    MessageBox.Show("Data Saved");
                }
            }
            else
            {
                Add();
                MessageBox.Show("New File Created and Data Saved");
            }
        }
        #endregion

    }
}
