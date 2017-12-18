using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace FusilControlLib
{
    public class CustomComboBox : ComboBox
    {
        ResourceDictionary MyStyle = new ResourceDictionary();
        public CustomComboBox()
        {
            MyStyle.Source = new Uri("pack://application:,,,/FusilResourcesLib;component/CustomStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)MyStyle["ComboBoxStyle"];            
            Height = 25;
            Width = 150;
        }
    }
}
