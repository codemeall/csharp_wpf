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

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for RegUI.xaml
    /// </summary>
    public partial class RegUI : UserControl,IMaster
    {
        DataBaseConnection db;
        RegistrationViewModel _ViewModel;
        public RegUI()
        {
            InitializeComponent();
            db = new DataBaseConnection();
            _ViewModel = new RegistrationViewModel();
            gdRegistration.DataContext = _ViewModel.rd;
        }

        public void Save()
        {
            _ViewModel.Save();
            Clear();
        }

        public void Clear()
        {
            _ViewModel.Clear();
            tbUserId.Focus();
        }

        public void Update()
        {
            _ViewModel.Update();
            Clear();
        }

        public void Delete()
        {
            _ViewModel.Delete();
            Clear();
        }

        public void Get()
        {
            _ViewModel.Get();
        }
    }
}
