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
using System.Windows.Shapes;

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for Fusil.xaml
    /// </summary>
    public partial class Fusil : Window
    {
        public Fusil()
        {
            InitializeComponent();
            gdFusil.Children.Add(new Login());
        }
    }
}
