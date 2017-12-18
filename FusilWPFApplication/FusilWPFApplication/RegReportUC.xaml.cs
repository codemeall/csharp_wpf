using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FusilWPFApplication.Interfaces;
using FusilDataBaseConnectionLib;
using System.Collections.ObjectModel;
using FusilClassLib;
using System.Xml.Linq;

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for RegReportUC.xaml
    /// </summary>
    public partial class RegReportUC : UserControl, IMasterReport
    {
        DataBaseConnection db;
        ObservableCollection<RegistrationData> adata;
        RegistrationViewModel _viewModel;
        public RegReportUC()
        {
            InitializeComponent();
            db = new DataBaseConnection();
            adata = new ObservableCollection<RegistrationData>();
            _viewModel = new RegistrationViewModel();
            gdRegReport.DataContext = _viewModel.rd;
            adata.Add(new RegistrationData());
            dgRegReport.ItemsSource = adata;
            //comboFilter.ItemsSource = Filterlist();
            dgRegReport.LoadingRow += new EventHandler<DataGridRowEventArgs>(dgAccountsReport_LoadingRow);
        }

        void dgAccountsReport_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        public void View()
        {
            if (string.IsNullOrEmpty(_viewModel.rd.Filter))
            {
                adata = new ObservableCollection<RegistrationData>();
                List<XElement> lst = Validation();
                GetValue(lst);
            }
            else
            {
                FilterSelect(); 
            }
        }

        public void Clear()
        {
            adata.Clear();
            _viewModel.rd.Filter = string.Empty;
            tbFilter.Focus();
            adata.Add(new RegistrationData());
        }

        public List<XElement> Validation()
        {
            List<XElement> li = new List<XElement>();
            string str = "Select * from Registration for xml raw('RegistrationData'),root('Registration')";
            string s = db.GetMethod(str);
            if (s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                if (xe != null && xe.HasElements)
                {
                    li = xe.Elements().ToList();
                }
            }
            return li;
        }

        #region Combobox for filter get contents method
        public List<string> Filterlist()
        {
            List<string> slst = new List<string>();
            string s = "select UserId from Registration for xml Raw('RegistrationData'), Root('Registration')";
            string ss = db.GetMethod(s);
            if (ss != null && ss != string.Empty)
            {
                XElement xe = XElement.Parse(ss);
                List<XElement> lst = xe.Elements().ToList();
                foreach (XElement x in lst)
                {
                    string st = string.Empty;
                    st = x.Attribute("UserId").Value.ToString();
                    slst.Add(st);
                }
            }
            return slst;
        }
        
        public List<string> Filter()
        {
            List<string> stlst = Filterlist();
            return stlst;
        }
        #endregion

        public List<XElement> FilterGet()
        {
            List<XElement> lst = new List<XElement>();
            string select = "select * from Registration where  UserId Like '%" + _viewModel.rd.Filter + "%' for xml Raw('RegistrationData'), root('Registration')";
            string s = db.GetMethod(select);
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                lst = xe.Elements().ToList();
            }
            return lst;
        }

        #region ComboBox selectedChange Event Method
        public void FilterSelect()
        {           
            adata = new ObservableCollection<RegistrationData>();
            List<XElement> lst = FilterGet();
            GetValue(lst);
        }
        #endregion
        
        public void GetValue(List<XElement> l)
        {
            if (l != null && l.Count > 0)
            {
                foreach (XElement x in l)
                {
                    RegistrationData rd = new RegistrationData();
                    rd.UserId = x.Attribute("UserId").Value;
                    rd.FirstName = x.Attribute("FirstName").Value;
                    rd.LastName = x.Attribute("LastName").Value;
                    rd.FatherName = x.Attribute("FatherName").Value;
                    rd.Dob = DateTime.Parse(x.Attribute("Dob").Value);
                    rd.MobileNo = x.Attribute("MobileNo").Value;
                    rd.Email = x.Attribute("Email").Value;
                    rd.Address = x.Attribute("Adress").Value;
                    adata.Add(rd);
                }
            }
            dgRegReport.ItemsSource = adata;
        }

    }
}
