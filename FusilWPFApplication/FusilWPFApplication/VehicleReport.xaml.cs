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
using FusilClassLib;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for VehicleReport.xaml
    /// </summary>
    public partial class VehicleReport : UserControl, IMasterReport
    {
        DataBaseConnection db;
        VehicleViewModel _viewModel;
        ObservableCollection<VehicleData> adata;
        public VehicleReport()
        {
            InitializeComponent();
            db = new DataBaseConnection();
            _viewModel = new VehicleViewModel();
            gdVehicleReport.DataContext = _viewModel.vd;
            adata = new ObservableCollection<VehicleData>();
            adata.Add(new VehicleData());
            dgVehicleReport.ItemsSource = adata;
            //comboFilter.ItemsSource = Filterlist();
        }

        public void View()
        {
            if (string.IsNullOrEmpty(_viewModel.vd.Filter))
            {
                adata = new ObservableCollection<VehicleData>();
                List<XElement> lst = List();
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
            _viewModel.vd.Filter = string.Empty;
            tbFilter.Focus();
            adata.Add(new VehicleData());
        }

        public List<XElement> List()
        {
            List<XElement> lst = new List<XElement>();
            string select = "Select * from Vehicle for xml Raw('VehicleData'), root('Vehicle')";
            string s = db.GetMethod(select);
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                lst = xe.Elements().ToList();
            }
            return lst;
        }

        #region Filter List For ComboBox
        public List<string> Filterlist()
        {
            List<string> slst = new List<string>();
            string s = "select Name from Vehicle for xml Raw('VehicleData'), Root('Vehicle')";
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
            List<string> stlst = Filterlist();
            return stlst;
        }
        #endregion

        public void FilterSelect()
        {
            adata = new ObservableCollection<VehicleData>();
            List<XElement> lst = FilterGet();
            GetValue(lst);
        }

        public void GetValue(List<XElement> l)
        {
            if (l != null && l.Count > 0)
            {
                foreach (XElement x in l)
                {
                    VehicleData vd = new VehicleData();
                    vd.Name = x.Attribute("Name").Value;
                    vd.Model = x.Attribute("Model").Value;
                    vd.Rate = decimal.Parse(x.Attribute("Rate").Value);
                    vd.Tax = decimal.Parse(x.Attribute("Tax").Value);
                    vd.Acc = decimal.Parse(x.Attribute("Acc").Value);
                    vd.Total = decimal.Parse(x.Attribute("Total").Value);
                    vd.Disc = decimal.Parse(x.Attribute("Disc").Value);
                    vd.DiscRate = decimal.Parse(x.Attribute("DiscRate").Value);
                    vd.Final = decimal.Parse(x.Attribute("FinalTotal").Value);
                    adata.Add(vd);
                }
            }
            dgVehicleReport.ItemsSource = adata; 
        }

        public List<XElement> FilterGet()
        {
            List<XElement> lst = new List<XElement>();
            string select = "select * from Vehicle where  Name Like '%" + _viewModel.vd.Filter + "%' for xml Raw('VehicleData'), root('Vehicle')";
            string s = db.GetMethod(select);
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                lst = xe.Elements().ToList();
            }
            return lst; 
        }
    }
}
