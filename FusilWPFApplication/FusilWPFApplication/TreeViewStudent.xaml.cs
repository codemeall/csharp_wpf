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
using FusilClassLib;
using FusilWPFApplication.Interfaces;
using FusilDataBaseConnectionLib;
using System.Xml.Linq;

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for TreeViewStudent.xaml
    /// </summary>
    public partial class TreeViewStudent : Window
    {
        ImasterTree _Imaster;
        DataBaseConnection db;
        TreeStudentViewModel _viewModel;
        TreeViewItem ti;
        public TreeViewStudent()
        {
            InitializeComponent();
            db = new DataBaseConnection();
            _viewModel = new TreeStudentViewModel();
            TreeFirstWindow tv = new TreeFirstWindow();
            _Imaster = tv;
            gdChild.Children.Add(tv);
            //treeControl.ItemsSource = _viewModel.Treelist();
            //treeControl.Items.Add(_viewModel.TreeItem());
            ti = new TreeViewItem();
            ti.ItemsSource = _viewModel.Treelist();
            //treeControl.ItemsSource = ti.Items;
            treeControl.Items.Add(ti);
        }

        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {
            gdChild.Children.Clear();
            GroupWindow gw = new GroupWindow();
            _Imaster = gw;
            gdChild.Children.Add(gw);
        }

        private void btnMaster_Click(object sender, RoutedEventArgs e)
        {
            gdChild.Children.Clear();
            TreeFirstWindow tf = new TreeFirstWindow();
            _Imaster = tf;
            gdChild.Children.Add(tf);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_Imaster != null)
            {
                _Imaster.Clear();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_Imaster != null)
            {
                _Imaster.Save();
                treeControl.ItemsSource = _viewModel.Treelist();
            }
        }

        private void treeControl_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
        //    TreeViewItem ti = new TreeViewItem();
        //    //treeControl.Items.Add(_viewModel.TreeItem());
        //    ti.Items.Add(_viewModel.TreeItem());
        }

    }
}
