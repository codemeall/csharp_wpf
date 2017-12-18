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
    /// Interaction logic for AccountsBodyUC.xaml
    /// </summary>
    public partial class AccountsBodyUC : UserControl,IMaster
    {
        public AccountsBodyUC()
        {
            InitializeComponent();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }


        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}
