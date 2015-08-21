using IShow.ChooseDishes.Model.EnumSet;
using IShow.ChooseDishes.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MarketTypeSetView.xaml
    /// </summary>
    public partial class MarketTypeSetView :MetroWindow
    {
        public bool IsTextBoxTextChanged = false;
        public MarketTypeSetView()
        {
           
            InitializeComponent();
            
        }

        private void Exit_Win(object sender, RoutedEventArgs e)
        {
            MarketTypeViewModel mm=this.DataContext as MarketTypeViewModel;
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
