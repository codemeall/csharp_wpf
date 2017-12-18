using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FusilDataBaseConnectionLib;
using System.Windows;
using System.Xml.Linq;

namespace FusilClassLib
{
    public class TreeStudentViewModel
    {
        public TreeStudentData td;
        DataBaseConnection db;
        public TreeStudentViewModel()
        {
            td = new TreeStudentData();
            db = new DataBaseConnection();
        }

        public void Clear()
        {
            td.Name = string.Empty;
            td.MobileNo = string.Empty;
            td.Email = string.Empty;
        }

        public void ClearGroup()
        {
            td.GroupName = string.Empty;
        }

        public bool FirstScreenValidations()
        {
            if (!string.IsNullOrEmpty(td.Name) && !string.IsNullOrEmpty(td.Group))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Name and Group is Mandatory");
                return false;
            }
        }

        public bool GroupValidations()
        {
            if (!string.IsNullOrEmpty(td.GroupName))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Name is Mandatory");
                return false; 
            }
        }
        public void Save()
        {
            if (GroupValidations())
            {
                string insert = "insert into Student (IsGroup, Name, GroupName) values(1, '" + td.GroupName + "', '" + td.GroupsGroup + "')";
                string s = db.GetMethod(insert);                
            }
        }

        public void MasterSave()
        {
            XElement xel = new XElement("Student");
            if (FirstScreenValidations())
            {
                XElement x = new XElement("StudentData", new XAttribute("IsGroup", "0"),
                                                         new XAttribute("Name", td.Name),
                                                         new XAttribute("GroupName", td.Group),
                                                         new XAttribute("MobileNo", td.MobileNo),
                                                         new XAttribute("Email", td.Email));
                xel.Add(x);
                //string insert = "insert into Student values(0, '" + td.Name + "', '" + td.Group + "', '" + td.MobileNo + "', '" + td.Email + "')";
                string s = db.GetDBConection("Student_sp", xel, "Insert"); 
                MessageBox.Show("Data Saved");
            }
        }

        public List<string> Treelist()
        {
            XElement xel = new XElement("Student");
            List<string> lst = new List<string>();
            //string select = "select Name from Student where IsGroup = 1 for xml raw('StudentData'), Root('Student')";
            string s = db.GetDBConection("dbo.USP_Student", xel, "Select");
            if (!string.IsNullOrEmpty(s))
            {
                XElement xe = XElement.Parse(s);
                List<XElement> xlst = xe.Elements().Where(x => x.Attribute("IsGroup").Value.Equals("1")).ToList();
                foreach (XElement x in xlst)
                {
                    string str = string.Empty;
                    str = x.Attribute("Name").Value.ToString();
                    lst.Add(str);
                }
            }
            return lst;
        }

        public List<string> TreeItem()
        {
            XElement xel = new XElement("Student");
            List<string> lst = new List<string>();
            //string select = "select Name from Student where IsGroup = 1 for xml raw('StudentData'), Root('Student')";
            string s = db.GetDBConection("dbo.USP_Student", xel, "Select");
            if (!string.IsNullOrEmpty(s))
            {
                XElement xe = XElement.Parse(s);
                List<XElement> xlst = xe.Elements().Where(x => x.Attribute("IsGroup").Value.Equals("0")).ToList();
                foreach (XElement x in xlst)
                {
                    string str = string.Empty;
                    str = x.Attribute("Name").Value.ToString();
                    lst.Add(str);
                }
            }
            return lst;
        }
    }
}
