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
using FusilClassLib;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using FusilDataBaseConnectionLib;

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for AccountsReportUC.xaml
    /// </summary>
    public partial class AccountsReportUC : UserControl, IMasterReport
    {
        DataBaseConnection db;
        ObservableCollection<AccountsData> adata;
        AccountsViewModel _viewmodel;
        public AccountsReportUC()
        {
            InitializeComponent();
            db = new DataBaseConnection();
            _viewmodel = new AccountsViewModel();
            gdAccountsReport.DataContext = _viewmodel.ad;
            adata = new ObservableCollection<AccountsData>();
            adata.Add(new AccountsData());
            dgAccountsReport.ItemsSource = adata;
            dgColumnTaxClass.ItemsSource = _viewmodel.TaxClass();            
            dgAccountsReport.LoadingRow += new EventHandler<DataGridRowEventArgs>(dgAccountsReport_LoadingRow);
            //comboFilter.ItemsSource = Filterlist();
        }

        void dgAccountsReport_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        public void View()
        {
            if (string.IsNullOrEmpty(_viewmodel.ad.Filter))
            {
                Get();
            }
            else
            {
                FilterSelect();
            }
        }

        public void Clear()
        {   
            adata.Clear();
            _viewmodel.ad.Filter = string.Empty;
            tbFilter.Focus();
            adata.Add(new AccountsData());
        }

        public List<XElement> GridHeader()
        {
            List<XElement> l = new List<XElement>();
            string getHeader = "select h.Sno,h.TaxClass, Name, Code, Descr,b.TaxRate, Narration from AccountsHeader h , AccountsBody b where h.Sno = b.Sno for xml raw('AccountsData'), root('Accounts')";            
            string sh = db.GetMethod(getHeader);            
            if (sh != null && sh != string.Empty) 
            {
                XElement xe = XElement.Parse(sh);                
                l = xe.Elements().ToList();
            }
            return l;
        }

        public void Get()
        {
            adata = new ObservableCollection<AccountsData>();
            List<XElement> lst = GridHeader();
            if (lst != null && lst.Count > 0)
            GetValue(lst); 
        }

        #region Filter list for ComboBox
        public List<string> Filterlist()
        {
            
            List<string> slst = new List<string>();
            string s = "select Name from AccountsHeader for xml Raw('AccountsData'), Root('Accounts')";
            string ss = db.GetMethod(s);
            if (ss != null && ss != string.Empty)
            {
                XElement xe = XElement.Parse(ss);
                List<XElement> lst = xe.Elements().ToList();
                foreach (XElement x in lst)
                {
                    string st = string.Empty;
                    st = x.Attribute("Name").Value.ToString();
                    slst.Add(st);                    
                }
            }
            return slst;
        }
        public List<string> Filter()
        {
            List<string> strlist = Filterlist();
            return strlist;
        }
        #endregion

        public List<XElement> FilterGet()
        {
            List<XElement> lst = new List<XElement>();
            string select = "select h.Sno,h.TaxClass, Name, Code, Descr,b.TaxRate, Narration from AccountsHeader h , AccountsBody b where h.Sno like '%"+_viewmodel.ad.Filter+"%' and b.Sno like '%"+_viewmodel.ad.Filter+"%' for xml Raw('AccountsData'), root('Accounts')";
            string s = db.GetMethod(select);
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                lst = xe.Elements().ToList();
            }
            return lst;
        }

        public void FilterSelect()
        {
            adata = new ObservableCollection<AccountsData>();
            List<XElement> lst = FilterGet();
            GetValue(lst);
        }

        public void GetValue(List<XElement> l)
        {
            if (l != null && l.Count > 0)
            {
                foreach (XElement x in l)
                {
                    AccountsData ad = new AccountsData();
                    ad.Sno = x.Attribute("Sno").Value;
                    ad.Name = x.Attribute("Name").Value;
                    ad.TaxClass = x.Attribute("TaxClass").Value;
                    ad.Code = x.Attribute("Code").Value;
                    ad.Desc = x.Attribute("Descr").Value;
                    ad.TaxRate = decimal.Parse(x.Attribute("TaxRate").Value);
                    ad.Narration = x.Attribute("Narration").Value;
                    adata.Add(ad);
                }
            }
            dgAccountsReport.ItemsSource = adata; 
        }
    }
}
