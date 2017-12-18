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
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : UserControl, ImasterTree
    {
        TreeStudentViewModel _viewModel;
        public GroupWindow()
        {
            InitializeComponent();
            _viewModel = new TreeStudentViewModel();
            gdGroup.DataContext = _viewModel.td;
            comboGroup.ItemsSource = _viewModel.Treelist();            
        }

        public void Save()
        {
            _viewModel.Save();
            Clear();
        }

        public void Clear()
        {
            _viewModel.ClearGroup();
            comboGroup.SelectedIndex = -1;
        }
    }
}
