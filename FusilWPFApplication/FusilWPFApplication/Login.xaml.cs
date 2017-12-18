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
using FusilDataBaseConnectionLib;
using System.Xml.Linq;

namespace FusilWPFApplication
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        DataBaseConnection db;
        public Login()
        {
            db = new DataBaseConnection();
            InitializeComponent();
            tbUserName.Text = "admin";
            Password.Password = "a";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbUserName.Text = string.Empty;
            Password.Password = string.Empty;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoginClick())
            {
                gdLogin.Children.Clear();
                gdLogin.Children.Add(new MainWindow());
            }
            else
                MessageBox.Show("Enter Correct UserId & Password.");
            //List<XElement> lst = LogList();
            //if (lst != null && lst.Count != 0)
            //{
            //    gdLogin.Children.Clear();
            //    gdLogin.Children.Add(new MainWindow());
            //}
            //else
            //{
            //    MessageBox.Show("Incorrect Details");
            //}
           
        }

        public bool LoginClick()
        {
            string select = "select * from LoginDetail where UserId='"+tbUserName.Text+"' and Password='"+Password.Password+"'";
            string s = db.GetMethod(select);
            if (s != null & s != string.Empty)
            {
                return true;
            }
            else
                return false;
        }

        #region Login Dynamic UserName 
        public List<XElement> LogList()
        {
            List<XElement> lst = new List<XElement>();
            string select = "select * from LoginDetail for xml raw('LoginData'), Root('Login')";
            string s = db.GetMethod(select);
            if (s != null && s != string.Empty)
            {
                XElement xe = XElement.Parse(s);
                if (xe != null && xe.HasElements)
                {
                    lst = xe.Elements().Where(x => x.Attribute("UserId").Value.Equals(tbUserName.Text)).ToList();
                    //lst = lst.Where(x => x.Attribute("UserId").Equals(tbUserName.Text)).ToList();
                }
            }
            return lst;
        }
        #endregion
    }
}
