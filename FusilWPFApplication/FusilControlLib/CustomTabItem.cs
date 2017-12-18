using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace FusilControlLib
{
    public class CustomTabItem : TabItem
    {
        ResourceDictionary MyStyle = new ResourceDictionary();
        public CustomTabItem()
        {
            MyStyle.Source = new Uri("pack://application:,,,/FusilResourcesLib;component/ButtonStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)MyStyle["TabItemStyle"];
            Width = 80;
            Height = 25;
        }
    }
}
