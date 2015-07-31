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
    /// Interaction logic for editLocation.xaml
    /// </summary>
    public partial class editLocation : Window
    {
        public editLocation(Location p)
        {
            InitializeComponent();

            txt_No.Text = p.Code;


            txt_Name.Text = p.Name;

            Location = p;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
