using IShow.ChooseDishes.Data;
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

namespace IShow.ChooseDishes.View.OrgTable
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class addLocation : Window
    {
        public addLocation()
        {
            InitializeComponent();
            Location = new Location();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        Location _location;
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txt_No.Text.Length <= 0 || txt_Name.Text.Length <= 0)
            {
                //做更多验证

                MessageBox.Show("字段不能为空！");
                return;
            }

            _location.Name = txt_No.Text;
            _location.Code = txt_Name.Text;

            this.DialogResult = true;

            this.Close();
        }
    }
}
