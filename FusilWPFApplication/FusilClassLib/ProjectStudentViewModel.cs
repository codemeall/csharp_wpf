using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows;
using System.IO;

namespace FusilClassLib
{
    public class ProjectStudentViewModel
    {
        public List<string> combolist = new List<string>();
        string filepath = "C:\\Users\\FUSILUSER10\\Desktop\\AzizProject.xml";
        public ProjectStudentData psd;
        public ProjectStudentViewModel()
        {
            psd = new ProjectStudentData();
            psd.Male = true;
            combolist = GetList();
        }

        #region Comobox ItemList
        public List<string> GetList()
        {
            List<string> list = new List<string>();
            list.Add("1st Class");
            list.Add("2nd Class");
            list.Add("3rd Class");
            list.Add("4th Class");
            list.Add("5th Class");
            list.Add("5th Class");
            list.Add("7th Class");
            list.Add("8th Class");
            list.Add("9th Class");
            list.Add("10th Class");
            return list;
        }
        #endregion

        #region Save Methods
        public XElement Save()
        {
            string str = string.Empty;
            if (psd.Male == true)
                str = "Male";
            else
                str = "Female";

            XElement xsv = new XElement("StudentData", new XAttribute("StudentId", psd.Id),
                                                       new XAttribute("Name", psd.Name),
                                                       new XAttribute("Class", psd.Classes),
                                                       new XAttribute("RollNo", psd.Rollno),
                                                       new XAttribute("Gender", str));
            return xsv;
        }

        public XElement Save2()
        {
            XElement xsv2 = new XElement("Student");
            xsv2.Add(Save());            
            return xsv2;
        }

        public void SaveMethod()
        {
            if(File.Exists(filepath))
            {
                string fp = File.ReadAllText(filepath);
                XElement sd = XElement.Parse(fp);                
                    if (sd != null && sd.HasElements)
                    {
                        List<XElement> list = sd.Elements().ToList();
                        if (list != null && list.Count > 0)
                        {
                            List<XElement> List1 = list.Where(x => x.Attribute("Name").Value.Equals(psd.Name)).ToList();
                            List<XElement> List2 = list.Where(x => x.Attribute("StudentId").Value.Equals(psd.Id)).ToList();
                            if (List1 != null && List1.Count == 0)
                            {
                                if (List2 != null && List2.Count == 0)
                                {
                                    XElement sv = Save();
                                    list.Add(sv);
                                    XElement sva = new XElement("Student");
                                    sva.Add(list);                                    
                                    sva.Save(filepath);
                                    MessageBox.Show("Your Data Saved Successfully");
                                    Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Id Already Exist, Please Enter Unique Id");
                                    psd.Id = string.Empty;
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Name Already Exist, Please Enter Unique Id");
                                psd.Name = string.Empty;   
                            }
                        }
                        else
                        {
                            XElement s = Save2();
                            s.Save(filepath);
                        }
                    }
                    else
                    {
                        XElement xe = Save2();
                        xe.Save(filepath);
                    }                
            }           
            else
            {
                XElement xe = new XElement("Student");
                xe.Add(Save());
                xe.Save(filepath);
                MessageBox.Show("File Creaded and data saved");
            }
        }
        #endregion 

        #region Clear Method

        public void Clear()
        {
            psd.Id = string.Empty;
            psd.Name = string.Empty;
            psd.Rollno = string.Empty;
            psd.Male = true;
            psd.Female = false;
            
        }

        #endregion 

        #region Get Method.
        public void Get()
        {
            if (File.Exists(filepath))
            {
                string str = File.ReadAllText(filepath);
                XElement gxele = XElement.Parse(str);
                if (gxele != null && gxele.HasElements)
                {
                    List<XElement> xlist = gxele.Elements().Where(x => x.Attribute("StudentId").Value.Equals(psd.Id)).ToList();
                    if (xlist != null && xlist.Count > 0)
                    {
                        psd.Id = xlist[0].Attribute("StudentId").Value;
                        psd.Name = xlist[0].Attribute("Name").Value;
                        psd.Classes = xlist[0].Attribute("Class").Value;
                        psd.Rollno = xlist[0].Attribute("RollNo").Value;
                        string g = xlist[0].Attribute("Gender").Value;
                        if (g == "Male")
                        {
                            psd.Male = true;
                            psd.Female = false;
                        }
                        else
                        {
                            psd.Female = true;
                            psd.Male = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data Not Exist");
                    }
                }
            }
            else
            {
                MessageBox.Show("File is missing");
            }
        }        
        #endregion

        #region Update
        public void Update()
        {
            
            string ustr = File.ReadAllText(filepath);
            XElement uxe = XElement.Parse(ustr);
            if (uxe != null && uxe.HasElements)
            {
                List<XElement> ulist = uxe.Elements().Where(x => x.Attribute("StudentId").Value != psd.Id).ToList();
                List<XElement> list1 = uxe.Elements().Where(x => x.Attribute("StudentId").Value.Equals(psd.Id)).ToList();

                if (ulist != null && ulist.Count > 0)
                {
                    string gr = string.Empty;
                    if (psd.Male == true)
                    {
                        gr = "Male";
                    }
                    else
                    {
                        gr = "Female";
                    }
                    list1[0].Attribute("StudentId").Value = psd.Id;
                    list1[0].Attribute("Name").Value = psd.Name;
                    list1[0].Attribute("Class").Value = psd.Classes;
                    list1[0].Attribute("RollNo").Value = psd.Rollno;
                    list1[0].Attribute("Gender").Value = gr;
                                      
                    XElement us = new XElement("Student"); 
                    us.Add(ulist);
                     us.Add(list1);
                    us.Save(filepath);
                    MessageBox.Show("Data Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Select and item to update");
                }
            }
            else
            {
                MessageBox.Show("No data to update");
            }
        }
        #endregion

        #region Delete
        public void Delete()
        {
            string ustr = File.ReadAllText(filepath);
            XElement uxe = XElement.Parse(ustr);
            if (uxe != null && uxe.HasElements)
            {
                //List<XElement> ulist = uxe.Elements().ToList();
                List<XElement> list1 = uxe.Elements().Where(x => x.Attribute("StudentId").Value != psd.Id).ToList();
               // List<XElement> list2 = ulist.Where(x => x.Attribute("StudentId").Value == psd.Id).ToList();
                //if (list1 != null && list1.Count > 0)
                //{
                //    string gr = string.Empty;
                //    if (psd.Male == true)
                //    {
                //        gr = "Male";
                //    }
                //    else
                //    {
                //        gr = "Female";
                //    }
                //    psd.Id = list1[0].Attribute("StudentId").Value;
                //    psd.Name = list1[0].Attribute("Name").Value;
                //    psd.Classes = list1[0].Attribute("Class").Value;
                //    psd.Rollno = list1[0].Attribute("RollNo").Value;
                //    gr = list1[0].Attribute("Gender").Value;

                    XElement us = new XElement("Student");
                    us.Add(list1);
                    us.Save(filepath);
                    MessageBox.Show("Data Deleted Successfully");
                //}
                //else
                //{
                //    MessageBox.Show("Select and item to Delete");
                //}
            }
            else
            {
                MessageBox.Show("No data to Delete");
            }
        }
        #endregion
    }
}
