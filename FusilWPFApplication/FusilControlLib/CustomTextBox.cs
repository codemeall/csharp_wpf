using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace FusilControlLib
{
    public class CustomTextBox : TextBox
    {
        ResourceDictionary MyStyle = new ResourceDictionary();
        public CustomTextBox()
        {
            MyStyle.Source = new Uri("pack://application:,,,/FusilResourcesLib;component/ButtonStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)MyStyle["TextBoxStyle"];
            Height = 25;
            Width = 150;
        }
    }
}
