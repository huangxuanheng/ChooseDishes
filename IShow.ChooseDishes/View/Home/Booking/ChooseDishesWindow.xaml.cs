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
using IShow.ChooseDishes.ViewModel.Booking;
using MahApps.Metro.Controls;
using IShow.ChooseDishes.Model;
using System.Collections.ObjectModel;

namespace IShow.ChooseDishes.View.Home.Booking
{
    /// <summary>
    /// ChooseDishesWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseDishesWindow : MetroWindow
    {
        ChooseDishesViewModel ChooseDishes;
        public ChooseDishesWindow()
        {
            InitializeComponent();
            //this.DataContext = new ChooseDishesViewModel();
            ChooseDishes = this.DataContext as ChooseDishesViewModel;
        }


        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            NumericTabItem.IsSelected = true;
        }

        private void GroupDishesButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseDishesTabControl.IsSelected = true;
        }

        private void HoldonButton_Click(object sender, RoutedEventArgs e)
        {
            HoldonTabItem.IsSelected = true;

        }

        private void HandupButton_Click(object sender, RoutedEventArgs e)
        {
            HandupTabItem.IsSelected = true;
        }

        private void FirstCategorys_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            int id = (int)radioBtn.Tag;
            if (id > 0)
            {
                ChooseDishes.SelectedItemFirstCategory(id);
            }
        }

        private void SecondCategorys_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            int id = (int)radioBtn.Tag;
            if (id > 0)
            {
                ChooseDishes.SelectedItemSecondCategory(id);
            }
        }
            private void SubmitOrders_Click(object sender, RoutedEventArgs e)
        {
            //DishBeanUtil a = (DishBeanUtil)this.DishesRecordsListBox.SelectedItem;
            //ObservableCollection<DishBeanUtil> dishList = (ObservableCollection<DishBeanUtil>)this.DishesRecordsListBox.SelectedItems;
            System.Collections.IList items = (System.Collections.IList)this.DishesRecordsListBox.SelectedItems;
            var collection = items.Cast<DishBeanUtil>();
            List<DishBeanUtil> list = collection.ToList();
            ChooseDishes.SubmitOrders_Ation(list);
        }

            private void DishesRecordsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                System.Collections.IList items = (System.Collections.IList)this.DishesRecordsListBox.SelectedItems;
                var collection = items.Cast<DishBeanUtil>();
                List<DishBeanUtil> list = collection.ToList();
                ChooseDishes.SubmitOrders_Ation(list);
            }
    }
}
