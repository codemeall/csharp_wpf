using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace FusilControlLib
{
    public class CustomButtons : Button
    {
        ResourceDictionary MyStyle = new ResourceDictionary();
        public CustomButtons()
        {
            MyStyle.Source = new Uri("pack://application:,,,/FusilResourcesLib;component/ButtonStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)MyStyle["ButtonStyle"];
            Height = 25;
            Width = 60;
        }
    }
}
