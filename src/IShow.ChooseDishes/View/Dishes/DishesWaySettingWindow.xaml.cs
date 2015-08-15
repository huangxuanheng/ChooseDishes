using IShow.ChooseDishes.ViewModel;
using MahApps.Metro.Controls;
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

namespace IShow.ChooseDishes.View.Dishes
{
    /// <summary>
    /// Interaction logic for DishesWayFrom.xaml
    /// </summary>
    public partial class DishesWaySettingWindow : MetroWindow
    {
        public static bool IsTextBoxTextChanged = false;
        public DishesWaySettingWindow()
        {
            //MessageBox.Show("弹出做法页面");
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DishesWayViewModel mm = this.DataContext as DishesWayViewModel;
            mm.CheckedTextChanged();
            this.Close();
            if (IsTextBoxTextChanged)
            {
                IsTextBoxTextChanged = false;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsActive)
            {
                IsTextBoxTextChanged = true;
            }
        }
    }
}
