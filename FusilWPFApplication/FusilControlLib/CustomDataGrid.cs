using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace FusilControlLib
{
    public class CustomDataGrid : DataGrid
    {
        ResourceDictionary MyStyle = new ResourceDictionary();
        public CustomDataGrid()
        {
            MyStyle.Source = new Uri("pack://application:,,,/FusilResourcesLib;component/CustomStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)MyStyle["CustomDataGridStyle"]; 
        }
    }
}
