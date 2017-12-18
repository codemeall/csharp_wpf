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
    /// Interaction logic for AccountsUC.xaml
    /// </summary>
    public partial class AccountsUC : UserControl, IMaster
    {
        DataBaseConnection db;
        AccountsViewModel _viewmodel;
        ObservableCollection<AccountsData> adata;
        public AccountsUC()
        {
            InitializeComponent();
            _viewmodel = new AccountsViewModel();
            gdAccountsUC.DataContext = _viewmodel.ad;
            adata = new ObservableCollection<AccountsData>();
            adata.Add(new AccountsData());
            dgBody.ItemsSource = adata;
            db = new DataBaseConnection();
            comboTaxClass.ItemsSource = _viewmodel.TaxClass();
            dgColumnTaxClass.ItemsSource = _viewmodel.TaxClass();
            dgBody.LoadingRow +=new EventHandler<DataGridRowEventArgs>(dgBody_LoadingRow);
            dgBody.RowEditEnding += new EventHandler<DataGridRowEditEndingEventArgs>(dgBody_RowEditEnding);
        }

        #region RowAdding Process and Loading Row Process
        public bool RowAddingProcess()
        {
            bool isValid = false;
            foreach (AccountsData ad in adata)
            {
                if (!string.IsNullOrEmpty(ad.TaxClass))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;

        }

        void dgBody_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (RowAddingProcess())
            {
                adata.Add(new AccountsData());
            }
        }

        void dgBody_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        #endregion

        public void Save()
        {
            if (_viewmodel.HeaderValidations() && GridBodyValidation())
            {
                _viewmodel.Insert();
                
                BodyInsert();
                MessageBox.Show("Data is Saved");
                Clear();
            }
        }

        public void Clear()
        {
            _viewmodel.Clear();
            comboTaxClass.SelectedIndex = -1;
            adata.Clear();
            adata.Add(new AccountsData());
            tbSno.Focus();
        }

        public void Update()
        {
            if (_viewmodel.ValidtionDml())
            {
                _viewmodel.Update();
                BodyUpdate();
                MessageBox.Show("Data Updated Successfully");
                Clear();
            }
        }

        public void Delete()
        {
            if (_viewmodel.ValidtionDml())
            {
                BodyDelete();
                _viewmodel.Delete();
                MessageBox.Show("Data Deleted Successfully");
                Clear();
            }
        }

        public void Get()
        {
            if (_viewmodel.ValidtionDml())
            {
                _viewmodel.Get();
                BodyGet();
            }
        }

        public bool GridBodyValidation()
        {
            bool isvalid = false;
            if (adata != null && adata.Count > 0)
            {
                foreach (AccountsData ad in adata)
                {
                    if (ad.TaxClass != string.Empty)
                        isvalid = true;
                }
            }
            else
            {
                MessageBox.Show("Select TaxClass in the Body");
            }
            return isvalid;
        }

        public void BodyInsert()
        {
            XElement xele = new XElement("AccountsBody");
            
            foreach (AccountsData ad in adata)
            {
                if (ad.TaxClass != string.Empty)
                {
                    //string insert = "insert into AccountsBody values(" + _viewmodel.ad.Sno + ", '" + ad.TaxClass + "', '" + ad.TaxRate + "', '" + ad.Narration + "')";
                    //db.GetDBConnection(insert);
                    XElement x = new XElement("AccountsBodyData", new XAttribute("Sno", _viewmodel.ad.Sno),
                                                          new XAttribute("TaxClass", ad.TaxClass),
                                                          new XAttribute("TaxRate", ad.TaxRate),
                                                          new XAttribute("Narration", ad.Narration));
                    xele.Add(x);                    
                }
            }
            db.GetDBConection("USP_MULTITBL", xele, "Insert");
        }

        public void BodyUpdate()
        {
            XElement xele = new XElement("AccountsBody");            
            foreach (AccountsData ad in dgBody.ItemsSource)
            {
                if (_viewmodel.ad.Sno != string.Empty && ad.TaxClass != string.Empty)
                {
                    XElement x = new XElement("AccountsBodyData", new XAttribute("TaxClass", ad.TaxClass),
                                                                  new XAttribute("TaxRate", ad.TaxRate),
                                                                  new XAttribute("Narration", ad.Narration),
                                                                  new XAttribute("Sno", _viewmodel.ad.Sno));
                    xele.Add(x);
                    //string update = "update AccountsBody set TaxClass='" + ad.TaxClass + "', TaxRate=" + ad.TaxRate + ", Narration='" + ad.Narration + "' where Sno=" + _viewmodel.ad.Sno + "";
                    //db.GetMethod(update);
                }                
            }
            db.GetDBConection("USP_MULTITBL", xele, "Update");
        }

        public void BodyDelete()
        {
            XElement xele = new XElement("AccountsBody");            
            foreach (AccountsData ad in dgBody.ItemsSource)
            {
                if (_viewmodel.ad.Sno != string.Empty)
                {
                    //string delete = "delete from AccountsBody where Sno=" + _viewmodel.ad.Sno;
                    //db.GetMethod(delete);
                    XElement x = new XElement("AccountsBodyData", new XAttribute("Sno", _viewmodel.ad.Sno));
                    xele.Add(x);                    
                }
            }
            db.GetDBConection("USP_MULTITBL", xele, "Delete");
        }

        public void BodyGet()
        {
            adata = new ObservableCollection<AccountsData>();  
            List<XElement> l = _viewmodel.GridValidation();
            List<XElement> lst = l.Where(x => x.Attribute("Sno").Value.Equals(_viewmodel.ad.Sno)).ToList();
            if (lst != null && lst.Count != 0)
            {
                foreach (XElement x in lst)
                {
                    AccountsData ad = new AccountsData();
                    //ad.Sno = x.Attribute("Sno").Value;  removed the control from design
                    ad.TaxClass = x.Attribute("TaxClass").Value;
                    ad.TaxRate = decimal.Parse(x.Attribute("TaxRate").Value);
                    ad.Narration = x.Attribute("Narration").Value;
                    adata.Add(ad);
                }
            }
            else
            {
                Clear();
            }
            dgBody.ItemsSource = adata;
        }

        
    }
}
