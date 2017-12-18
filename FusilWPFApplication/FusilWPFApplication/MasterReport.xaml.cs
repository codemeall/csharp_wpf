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
using System.Xml.Linq;
using FusilClassLib;

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for MasterReport.xaml
    /// </summary>
    public partial class MasterReport : UserControl
    {
        private IMasterReport _Imaster;
        public MasterReport()
        {
            InitializeComponent();            
            gdReportChild.Children.Add(new Logo());            
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            gdReportChild.Children.Clear();
            AccountsReportUC ar = new AccountsReportUC();

            _Imaster = ar;            
            gdReportChild.Children.Add(ar); 
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_Imaster != null)
            {
                _Imaster.Clear();
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            gdReport.Children.Clear();
            FirstScreen fs = new FirstScreen();
            gdReport.Children.Add(fs);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (_Imaster != null)
            {
                _Imaster.View();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            gdReportChild.Children.Clear();
            RegReportUC rr = new RegReportUC();
            _Imaster = rr;
            gdReportChild.Children.Add(rr);
        }

        private void btnVehicle_Click(object sender, RoutedEventArgs e)
        {
            gdReportChild.Children.Clear();
            VehicleReport vr = new VehicleReport();
            _Imaster = vr;
            gdReportChild.Children.Add(vr);
        }

    }
}
