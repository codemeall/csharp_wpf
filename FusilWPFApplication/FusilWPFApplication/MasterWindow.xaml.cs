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

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : UserControl
    {
        private IMaster _imaster;
        public MasterWindow()
        {
            InitializeComponent();
            //AccountsUC ac = new AccountsUC();
            //_imaster = ac;
            //gdChild.Children.Add(ac);   
            gdChild.Children.Add(new Logo());
        }
        
        private void btnHeader_Click(object sender, RoutedEventArgs e)
        {
            gdChild.Children.Clear();
            AccountsUC ac = new AccountsUC();
            _imaster = ac;
            gdChild.Children.Add(ac);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_imaster != null)
            {
                _imaster.Save();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_imaster != null)
            {
                _imaster.Clear();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_imaster != null)
            {
                _imaster.Update();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_imaster != null)
            {
                _imaster.Delete();
            }
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            if (_imaster != null)
            {
                _imaster.Get();
            }
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            gdChild.Children.Clear();
            RegUI rg = new RegUI();
            _imaster = rg;
            gdChild.Children.Add(rg);

        }

        private void btnVehicle_Click(object sender, RoutedEventArgs e)
        {
            gdChild.Children.Clear();
            Vehicle v = new Vehicle();
            _imaster = v;
            gdChild.Children.Add(v);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            gdmaster.Children.Clear();
            FirstScreen fs = new FirstScreen();
            gdmaster.Children.Add(fs);

        }

    }
}
