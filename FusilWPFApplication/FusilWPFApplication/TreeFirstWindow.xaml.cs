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
    /// Interaction logic for TreeFirstWindow.xaml
    /// </summary>
    public partial class TreeFirstWindow : UserControl, ImasterTree
    {
        TreeStudentViewModel _viewModel;
        public TreeFirstWindow()
        {            
            InitializeComponent();
            _viewModel = new TreeStudentViewModel();
            gdFirstWindow.DataContext = _viewModel.td;
            comboGroup.ItemsSource = _viewModel.Treelist();
            
        }

        public void Save()
        {
            _viewModel.MasterSave();
            Clear();
        }

        public void Clear()
        {
            _viewModel.Clear();
            comboGroup.SelectedIndex = -1;
            tbName.Focus(); 
        }
    }
}
