using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace FusilControlLib
{
    public class CustomGroupBox : GroupBox
    {
        ResourceDictionary MyStyle = new ResourceDictionary();
        public CustomGroupBox()
        {
            MyStyle.Source = new Uri("pack://application:,,,/FusilResourcesLib;component/ButtonStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)MyStyle["GroupBoxStyle"];
        }
    }
}
