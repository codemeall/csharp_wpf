using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows;

namespace FusilClassLib
{    
    public class EmailViewModel
    {
        string dir = string.Empty;
        string filepath = string.Empty;        
        //string filepath = "C:\\Users\\FUSILUSER10\\Desktop\\Email.xml";
        public EmailData ed;
        public List<string> combolst = new List<string>();
        public EmailViewModel()
        {
            ed = new EmailData();
            combolst = Gender();
        }

        public List<string> Gender()
        {
            List<string> gend = new List<string>();
            gend.Add(string.Empty);
            gend.Add("Male");
            gend.Add("Female");
            return gend;
        }

        public void Clear()
        {
            ed.Email = string.Empty;
            ed.Firstname = string.Empty;
            ed.Lastname = string.Empty;            
            ed.Password = string.Empty;
            ed.Dob = DateTime.Now;
            ed.Mobileno = string.Empty;
            ed.Browse = string.Empty;
        }
        public XElement Save()
        {            
            
            XElement xs = new XElement("EmailData", new XAttribute("Email", ed.Email),
                                                    new XAttribute("FirstName", ed.Firstname),
                                                    new XAttribute("LastName", ed.Lastname),
                                                    new XAttribute("Password", ed.Password),
                                                    new XAttribute("MobileNo", ed.Mobileno),
                                                    new XAttribute("Gender", ed.Gender),
                                                    new XAttribute("Dob", ed.Dob.ToShortDateString()));
            return xs; 
        }
        public XElement SaveAdd()
        {
            XElement xsa = new XElement("Email");
            xsa.Add(Save());
            xsa.Save(filepath);
            return xsa;
        }
        public bool Submit()
        {
            if (!string.IsNullOrEmpty(ed.Email) && !string.IsNullOrEmpty(ed.Firstname))
            {
                if (!string.IsNullOrEmpty(ed.Browse))
                {
                    filepath = ed.Browse + "\\Email.xml";
                    //DirectoryInfo i = new DirectoryInfo(dir);
                    //if (!i.Exists)
                    //{
                    //    i.Create();
                    //    MessageBox.Show("Folder Created");
                    //}
                    //if (Directory.Exists(dir))
                    //{
                    if (File.Exists(filepath))
                    {
                        string fp = File.ReadAllText(filepath);
                        XElement xfp = XElement.Parse(fp);
                        int count = xfp.Elements().Count();
                        if (count > 0)
                        //if (xfp != null && xfp.HasElements)
                        {
                            List<XElement> list = xfp.Elements().ToList();
                            if (list != null && list.Count > 0)
                            {
                                List<XElement> list1 = list.Where(x => x.Attribute("Email").Value.Equals(ed.Email)).ToList();// for duplicate
                                if (list1 != null && list1.Count == 0)
                                {
                                    XElement xele = Save();
                                    list.Add(xele);
                                    XElement xnew = new XElement("Email");
                                    xnew.Add(list);
                                    xnew.Save(filepath);
                                    MessageBox.Show("Data Saved Successfully");
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Email Id Exist already, Try unique Email Id");
                                    ed.Email = string.Empty;
                                    return true;

                                }
                            }
                            else
                            {
                                SaveAdd();
                                MessageBox.Show("Data Saved Successfully");
                                return true;
                            }
                        }
                        else
                        {
                            SaveAdd();
                            MessageBox.Show("Data Saved Successfully");
                            return true;
                        }
                    }
                    else
                    {
                        SaveAdd();
                        MessageBox.Show("New File Created and Data Saved");
                        return true;
                    }
                    //}
                    //else
                    //{
                    //    Directory.CreateDirectory(dir);
                    //    SaveAdd();
                    //    MessageBox.Show("New Folder Created and Data Saved");
                    //}
                }
                else
                {
                    MessageBox.Show("Path Field should not be Empty");
                }
            }
             else
             {
                if (string.IsNullOrEmpty(ed.Email) && string.IsNullOrEmpty(ed.Firstname))
                {
                    MessageBox.Show("Email and First Name should not be emlpty");
                }
                else if (string.IsNullOrEmpty(ed.Email))
                {
                    MessageBox.Show("Email field should not be empty");
                }
                else if (string.IsNullOrEmpty(ed.Firstname))
                {
                    MessageBox.Show("First Name should not be empty");
                }
            }
            return false;
        }
    }
}
