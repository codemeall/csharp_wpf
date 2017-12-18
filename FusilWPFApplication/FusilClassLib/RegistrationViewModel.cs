using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using FusilDataBaseConnectionLib;

namespace FusilClassLib
{
    public class RegistrationViewModel
    {
        DataBaseConnection db;
        public RegistrationData rd;
        public RegistrationViewModel()
        {
            rd = new RegistrationData();
            db = new DataBaseConnection();
            
        }

        public void Clear()
        {
            rd.UserId = string.Empty;
            rd.FirstName = string.Empty;
            rd.LastName = string.Empty;
            rd.FatherName = string.Empty;
            rd.Dob = DateTime.Now;
            rd.MobileNo = string.Empty;
            rd.Email = string.Empty;
            rd.Address = string.Empty;
        }

        public List<XElement> Validation()
        {
            XElement xele = new XElement("Registration");
            List<XElement> li = new List<XElement>();
            //string str = "Select * from Registration for xml raw('RegistrationData'),root('Registration')";
            //string s = db.GetMethod(str);
            string s = db.GetDBConection("USP_Registration", xele, "Select");
            if (s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                if (xe != null && xe.HasElements)
                {
                    li = xe.Elements().Where(x => x.Attribute("UserId").Value.Equals(rd.UserId)).ToList();
                }
            }
            return li;
        }

        public bool Delete()
        {
            XElement xele = new XElement("Registration");
            if (!string.IsNullOrEmpty(rd.UserId))
            {
                List<XElement> vlist = Validation();
                if (vlist != null && vlist.Count == 1)
                {
                    //string delete = "delete from Registration where UserId = " + rd.UserId;
                    //db.DML(delete);
                    //db.GetMethod(delete);
                    XElement x = new XElement("RegistrationData", new XAttribute("UserId", rd.UserId));
                    xele.Add(x);
                    db.GetDBConection("USP_Registration", xele, "Delete");
                    MessageBox.Show("Data Deleted");
                    return true;
                }
                else
                {
                    MessageBox.Show("UserId not Exist");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Enter UserId");
                return false;
            }            
        }

        public bool Update()
        {
            XElement xele = new XElement("Registration");
            if (!string.IsNullOrEmpty(rd.UserId))
            {
                List<XElement> vlist = Validation();
                if (vlist != null && vlist.Count == 1)
                {
                    XElement x = new XElement("RegistrationData", new XAttribute("UserId", rd.UserId),
                                                                  new XAttribute("FirstName", rd.FirstName),
                                                                  new XAttribute("LastName", rd.LastName),
                                                                  new XAttribute("FatherName", rd.FatherName),
                                                                  new XAttribute("Dob", rd.Dob.ToShortDateString()),
                                                                  new XAttribute("MobileNo", rd.MobileNo),
                                                                  new XAttribute("Email", rd.Email),
                                                                  new XAttribute("Adress", rd.Address));
                    xele.Add(x);
                    db.GetDBConection("USP_Registration", xele, "Update");                                                         
                    //string update = string.Format("update Registration set FirstName='{1}', LastName='{2}', FatherName='{3}', Dob='{4}', MobileNo='{5}', Email='{6}', Adress='{7}' where UserId={0}", rd.UserId, rd.FirstName, rd.LastName, rd.FatherName, rd.Dob.ToString("yyyy-MM-dd"), rd.MobileNo, rd.Email, rd.Address);
                    //db.GetMethod(update);
                    MessageBox.Show("Data Updated");
                    return true;
                }
                else
                {
                    MessageBox.Show("UserId not Exist");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Enter UserId");
                return false;
            }           
        }

        public bool Save()
        {
            if (!string.IsNullOrEmpty(rd.UserId) && !string.IsNullOrEmpty(rd.FirstName))
            {
                XElement xel = new XElement("Registration");
                List<XElement> vlist = Validation();
                if (vlist != null && vlist.Count == 0)
                {
                    //string Insert = "insert into Registration values(" + rd.UserId + ",'" + rd.FirstName + "','" + rd.LastName + "','" + rd.FatherName + "','" + rd.Dob.ToString("yyyy-MM-dd") + "', '" + rd.MobileNo + "','" + rd.Email + "','" + rd.Address + "')";
                    //db.DML(Insert);
                    //db.GetMethod(Insert);
                    XElement x = new XElement("RegistrationData", new XAttribute("UserId", rd.UserId),
                                                                  new XAttribute("FirstName", rd.FirstName),
                                                                  new XAttribute("LastName", rd.LastName),
                                                                  new XAttribute("FatherName", rd.FatherName),
                                                                  new XAttribute("Dob", rd.Dob.ToShortDateString()),
                                                                  new XAttribute("MobileNo", rd.MobileNo),
                                                                  new XAttribute("Email", rd.Email),
                                                                  new XAttribute("Adress", rd.Address));
                    xel.Add(x);

                    string s = db.GetDBConection("USP_Registration", xel, "Insert");
                    MessageBox.Show("Data Saved");
                    return true;
                }
                else
                {
                    MessageBox.Show("UserId already Exists");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("UserId and first name is Mandatory");
                return false;
            }
        }

        public bool Get()
        {
            if (!string.IsNullOrEmpty(rd.UserId))
            {
                List<XElement> vlist = Validation();
                if (vlist != null && vlist.Count == 1)
                {
                    //string select = "Select * from Registration where UserId = " + _ViewModel.rd.UserId + " for xml raw('RegistrationData'), root('Registration')";
                    //string s = db.GetMethod(select);
                    //XElement xele = XElement.Parse(s);
                    //List<XElement> lst = xele.Elements().ToList();
                    rd.UserId = vlist[0].Attribute("UserId").Value;
                    rd.FirstName = vlist[0].Attribute("FirstName").Value;
                    rd.LastName = vlist[0].Attribute("LastName").Value;
                    rd.FatherName = vlist[0].Attribute("FatherName").Value;
                    rd.Dob = DateTime.Parse(vlist[0].Attribute("Dob").Value);
                    rd.MobileNo = vlist[0].Attribute("MobileNo").Value;
                    rd.Email = vlist[0].Attribute("Email").Value;
                    rd.Address = vlist[0].Attribute("Adress").Value;
                    return true;
                }
                else
                {
                    MessageBox.Show("UserId not Exist");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Enter UserId");
                return false;
            }
        }
    }
}
