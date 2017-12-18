using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows;
using FusilDataBaseConnectionLib;

namespace FusilClassLib
{
   
    public class AccountsViewModel
    {        
        public XElement hx2;
        string filepath; //"C:\\Users\\FUSILUSER10\\Desktop\\Header.xml";
        public AccountsData ad;
        DataBaseConnection db;
        public AccountsViewModel()
        {            
            ad = new AccountsData();
            filepath = AppDomain.CurrentDomain.BaseDirectory + " Header.xml";
            db = new DataBaseConnection();
        }

        #region TaxClass List
        public List<string> TaxClass()
        {
            List<string> Tclass = new List<string>();
            Tclass.Add("VAT 5%");
            Tclass.Add("VAT 10%");
            Tclass.Add("VAT 15%");           

            return Tclass;
        }
        #endregion

        #region Clear Method
        public void Clear()
        {
            ad.Sno = string.Empty;
            ad.Name = string.Empty;
            ad.Code = string.Empty;
            ad.Desc = string.Empty;
            ad.TaxRate = decimal.Zero;
            ad.Narration = string.Empty;            
        }
        #endregion

        #region First Saving Method Of Header
        public XElement Save1()
        {
            XElement hx1 = new XElement("HeaderData", new XAttribute("Name", ad.Name),
                                                      new XAttribute("TaxClass", ad.TaxClass),
                                                      new XAttribute("Code", ad.Code),
                                                      new XAttribute("Desc", ad.Desc));

            return hx1;
        }
        #endregion

        #region Second Savind Method of Header
        public bool Save2()
        {
            hx2 = new XElement("Header");
            if (HeaderValidations())
            {
                hx2.Add(Save1());
                //hx2.Save(filepath);
                return true;
            }
            return false;
        }
        #endregion

        #region Validation Method
        public bool HeaderValidations()
        {
            bool isvalid = true;
            if (string.IsNullOrEmpty(ad.Sno) && string.IsNullOrEmpty(ad.Name))
            {
                MessageBox.Show("Please Select Mandatory Fields");
                isvalid = false; 
            }
            else if (!string.IsNullOrEmpty(ad.Name) && string.IsNullOrEmpty(ad.Sno))
            {
                MessageBox.Show("Please Select Sno");
                isvalid = false;
            }
            else if (string.IsNullOrEmpty(ad.Name) && !string.IsNullOrEmpty(ad.TaxClass))
            {
                MessageBox.Show("Please Select Name");
                isvalid = false;
            }
            return isvalid;
        }
        #endregion

        public bool ValidtionDml()
        {
            if (!string.IsNullOrEmpty(ad.Sno))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Enter Sno");
                return false;
            } 
        }

        public void Insert()
        {
            XElement xele = new XElement("AccountsHeader");
            XElement x = new XElement("AccountsHeaderData", new XAttribute("Sno", ad.Sno),
                                                            new XAttribute("Name", ad.Name),
                                                            new XAttribute("TaxClass", ad.TaxClass),
                                                            new XAttribute("Code", ad.Code),
                                                            new XAttribute("Descr", ad.Desc));
            xele.Add(x);
            List<XElement> lst = TableValidation();
            if (lst != null && lst.Count == 0)
            {
                //string Insert = "insert into AccountsHeader values(" + ad.Sno + ",'" + ad.Name + "', '" + ad.TaxClass + "', '" + ad.Code + "' , '" + ad.Desc + "')";
                //db.GetMethod(Insert);              //db.DML(save);       //db.GetDBConnection(save);
                db.GetDBConection("USP_MULTITBL", xele, "Insert");
            }
            else
            {
                MessageBox.Show(ad.Sno + "  Already Exist Try Another one");
            }     
        }

        public void Update()
        {
            XElement xele = new XElement("AccountsHeader");
            List<XElement> lst = TableValidation();
            if (lst != null && lst.Count != 0)
            {
                //string update = "update AccountsHeader set Name = '" + ad.Name + "', TaxClass = '" + ad.TaxClass + "', Code='" + ad.Code + "', Descr='" + ad.Desc + "' where Sno = '" + ad.Sno + "'";
                //db.GetMethod(update);
                XElement x = new XElement("AccountsHeaderData", new XAttribute("Sno", ad.Sno),
                                                                new XAttribute("Name", ad.Name),
                                                                new XAttribute("TaxClass", ad.TaxClass),
                                                                new XAttribute("Code", ad.Code),
                                                                new XAttribute("Descr", ad.Desc));
                xele.Add(x);
                db.GetDBConection("USP_MULTITBL", xele, "Update");                                                       
            }
            else
            {
                MessageBox.Show("Entered Name Does not exist");
            }             
        }

        public void Delete()
        {
            XElement xele = new XElement("AccountsHeader");
            XElement x = new XElement("AccountsHeaderData", new XAttribute("Sno", ad.Sno));
            xele.Add(x);
            List<XElement> lst = TableValidation();
            if (lst != null && lst.Count != 0)
            {
                //string delete = "Delete from AccountsHeader where Sno=" + ad.Sno;
                //db.GetMethod(delete);
                db.GetDBConection("USP_MULTITBL", xele,"Delete");
            }
            else
            {
                MessageBox.Show("Entered Name Does not exist");
            }
        }

        public List<XElement> TableValidation()
        {
            XElement xele = new XElement("AccountsHeader");
            List<XElement> l = new List<XElement>();
            //string get = "Select * from AccountsHeader where Sno='"+ad.Sno+"' for xml raw('HeaderData'), root('Header')";
            string s = db.GetDBConection("USP_MULTITBL", xele, "Select");
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                l = xe.Elements().Where(x => x.Attribute("Sno").Value.Equals(ad.Sno)).ToList();
            }
            return l;
        }

        public void Get()
        {
            List<XElement> lst = TableValidation();
            if (lst != null && lst.Count == 1)
            {
                ad.Sno = lst[0].Attribute("Sno").Value;
                ad.Name = lst[0].Attribute("Name").Value;
                ad.TaxClass = lst[0].Attribute("TaxClass").Value;
                ad.Code = lst[0].Attribute("Code").Value;
                ad.Desc = lst[0].Attribute("Descr").Value;
            }
            else
            {
                MessageBox.Show("Entered Name Doesn't Exist");
            }                 
        }

        public List<XElement> GridValidation()
        {
            XElement xele = new XElement("AccountsBody");
            List<XElement> l = new List<XElement>();            
            //string get = "Select * from AccountsBody where Sno="+ad.Sno+" for xml raw('HeaderData'), root('Header')";
            //string s = db.GetMethod(get);
            string s = db.GetDBConection("USP_MULTITBL", xele, "Select");
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                l = xe.Elements().Elements().ToList();
            }
            return l; 
        }
    }
}
