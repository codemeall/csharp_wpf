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
    /// Interaction logic for FirstScreen.xaml
    /// </summary>
    public partial class FirstScreen : UserControl
    {
        public FirstScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            gdFirstScr.Children.Clear();
            gdFirstScr.Children.Add(new MasterWindow());
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            gdFirstScr.Children.Clear();
            gdFirstScr.Children.Add(new MasterReport());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            gdFirstScr.Children.Clear();
            gdFirstScr.Children.Add(new Login());
        }
    }
}
