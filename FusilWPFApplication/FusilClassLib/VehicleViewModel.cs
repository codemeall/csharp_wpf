using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows;
using FusilDataBaseConnectionLib;

namespace FusilClassLib
{
    public class VehicleViewModel
    {
        DataBaseConnection db;
        string filepath = string.Empty;
        public VehicleData vd;
        public VehicleViewModel()
        {
            vd = new VehicleData();
            db = new DataBaseConnection();
        }

        public void Clear()
        {
            vd.Name = string.Empty;
            vd.Model = string.Empty;
            vd.Rate = decimal.Zero;
            vd.Tax = decimal.Zero;
            vd.Acc = decimal.Zero;
            vd.Total = decimal.Zero;
            vd.Disc = decimal.Zero;
            vd.DiscRate = decimal.Zero;
            vd.Final = decimal.Zero;
        }

        public XElement Save()
        {
            XElement xs = new XElement("VehicleData", new XAttribute("Name", vd.Name),
                                                    new XAttribute("Model", vd.Model),
                                                    new XAttribute("Rate", vd.Rate),
                                                    new XAttribute("Tax", vd.Tax),
                                                    new XAttribute("Acc", vd.Acc),
                                                    new XAttribute("Total", vd.Total),
                                                    new XAttribute("Disc", vd.Disc),
                                                    new XAttribute("DiscRate", vd.DiscRate),
                                                    new XAttribute("Final", vd.Final));
                                          

            return xs;
        }
        public XElement SaveAdd()
        {
            XElement xsa = new XElement("Vehicle");
            xsa.Add(Save());
            xsa.Save(filepath);
            return xsa;
        }
        public bool Submit()
        {
            if (!string.IsNullOrEmpty(vd.Name) && vd.Rate > 0)
            {
                if (!string.IsNullOrEmpty(vd.Browse))
                {
                    filepath = vd.Browse + "\\Vehicle.xml";
                    if (File.Exists(filepath))
                    {
                        string fp = File.ReadAllText(filepath);
                        XElement xfp = XElement.Parse(fp);
                        if (xfp != null && xfp.HasElements)
                        {
                            List<XElement> list = xfp.Elements().ToList();
                            if (list != null && list.Count > 0)
                            {
                                XElement xele = Save();
                                list.Add(xele);
                                XElement xnew = new XElement("Vehicle");
                                xnew.Add(list);
                                xnew.Save(filepath);
                                MessageBox.Show("Data Saved Successfully");
                                return true;

                            }
                            else
                            {
                                SaveAdd();
                                MessageBox.Show("Data Saved Successfully");
                                return true;
                            }
                        }
                    }
                    else
                    {
                        SaveAdd();
                        MessageBox.Show("New File Created and Data Saved");
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Path Field should not be Empty");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(vd.Name) && vd.Rate == 0)
                {
                    MessageBox.Show("Name and Rate fields should not be empty");
                }
                else if(string.IsNullOrEmpty(vd.Name))
                {
                    MessageBox.Show("Name Field Should not be Empty");
                }
                else if(vd.Rate == 0)
                {
                    MessageBox.Show("Please Enter the Rate");
                }                
            }
            return false;
        }

        public bool Validations()
        {
            bool Isvalid = false;
            if (!string.IsNullOrEmpty(vd.Name) && vd.Rate > 0)
            {
                Isvalid = true; 
            }
            else if (string.IsNullOrEmpty(vd.Name) && vd.Rate > 0)
            {
                MessageBox.Show("Name Should Not be Empty");
                Isvalid = false;
            }
            else if (!string.IsNullOrEmpty(vd.Name) && vd.Rate == 0)
            {
                MessageBox.Show("Rate should not be Zero");
                Isvalid = false;
            }
            return Isvalid; 
        }

        public bool Validation1()
        {
            if (!string.IsNullOrEmpty(vd.Name))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Enter Name");
                return false;
            }
        }

        public List<XElement> TableValidation()
        {
            XElement xel = new XElement("Vehicle");
            //XElement xee = new XElement("VehicleData", new XAttribute("Name", vd.Name)); // instead of using lamda expression below we can manage the selected data using this method from sql query.
            //xel.Add(xee);
            List<XElement> l = new List<XElement>();
            //string get = "Select * from Vehicle where Name='" + vd.Name + "' for xml raw('VehicleData'), root('Vehicle')";
            //string s = db.GetMethod(get);
            string s = db.GetDBConection("USP_Vehicle", xel, "Select");                        
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                if (xe != null && xe.HasElements)
                {
                    l = xe.Elements().Where(x => x.Attribute("Name").Value.Equals(vd.Name)).ToList();
                }
            }
            return l;
        }

        public bool Insert()
        {
            XElement xele = new XElement("Vehicle");
            XElement x = new XElement("VehicleData", new XAttribute("Name", vd.Name),   // mistakenly wrote this pattern
                                                     new XAttribute("Model", vd.Model),
                                                     new XAttribute("Rate", vd.Rate),
                                                     new XAttribute("Tax", vd.Tax),
                                                     new XAttribute("Acc", vd.Acc),
                                                     new XAttribute("Total", vd.Total),
                                                     new XAttribute("Disc", vd.Disc),
                                                     new XAttribute("DiscRate", vd.DiscRate),
                                                     new XAttribute("FinalTotal", vd.Final));
            
            xele.Add(x);
            if (Validations())
            {
                List<XElement> lst = TableValidation();
                if (lst != null && lst.Count == 0)
                {
                    //string insert = "insert into Vehicle values('" + vd.Name + "', '" + vd.Model + "', " + vd.Rate + ", " + vd.Tax + ", " + vd.Acc + ", " + vd.Total + ", " + vd.Disc + ", " + vd.DiscRate + ", " + vd.Final + ")"; ;
                    //db.GetMethod(insert);
                    db.GetDBConection("USP_Vehicle", xele, "Insert");
                    return true;
                }
                else
                {
                    MessageBox.Show("Name Already Exist Try another one");
                    return false;
                }
            }
            return false; 
        }

        public void Get()
        {
            if (Validation1())
            {
                List<XElement> lst = TableValidation();
                if (lst != null && lst.Count > 0)
                {
                    vd.Name = lst[0].Attribute("Name").Value;
                    vd.Model = lst[0].Attribute("Model").Value;
                    vd.Rate = decimal.Parse(lst[0].Attribute("Rate").Value);                    
                    vd.Tax = decimal.Parse(lst[0].Attribute("Tax").Value);
                    vd.Acc = decimal.Parse(lst[0].Attribute("Acc").Value);
                    vd.Total = decimal.Parse(lst[0].Attribute("Total").Value);
                    vd.Disc = decimal.Parse(lst[0].Attribute("Disc").Value);
                    vd.DiscRate = decimal.Parse(lst[0].Attribute("DiscRate").Value);
                    vd.Final = decimal.Parse(lst[0].Attribute("FinalTotal").Value);                    
                }
            }
        }
    }
}
