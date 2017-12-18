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

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Vehicle : UserControl,IMaster
    {
        VehicleViewModel _ViewModel;
        public Vehicle()
        {            
            InitializeComponent();            
            _ViewModel = new VehicleViewModel();
            gdVehicle.DataContext = _ViewModel.vd;            
        }

        public void Clr()
        {
            _ViewModel.Clear();
            tbName.Focus();
        }

        public void Save()
        {
            if (_ViewModel.Insert())
            {
                MessageBox.Show("Data Saved");
                Clr();
            }

        }

        public void Clear()
        {
            Clr();
        }

        public void Update()
        {
            MessageBox.Show("Cannot Update");
        }

        public void Delete()
        {
            MessageBox.Show("Cannot Delete");
        }

        public void Get()
        {
            _ViewModel.Get();
        }
    }
}
