using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.ViewModel.BuyDishGiving;
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

namespace IShow.ChooseDishes.View.BuyDishGiving
{
    /// <summary>
    /// BuyGivingSetting.xaml 的交互逻辑
    /// </summary>
    public partial class BuyGivingSetting : MetroWindow
    {
        GivingDishSettingViewModel GivingDishSetting;
        public BuyGivingSetting()
        {
            InitializeComponent();
            GivingDishSetting = this.DataContext as GivingDishSettingViewModel;
        }

        public void ShowDifferentStyleWin(int ation)
        {
            if (ation == 0) {//新增操作，不显示上下记录按钮
                this.Last.Visibility = Visibility.Collapsed;
                this.Next.Visibility = Visibility.Collapsed;
            }
            else if (ation == 1)//修改操作，显示上下记录按钮
            {
                this.Last.Visibility = Visibility.Visible;
                this.Next.Visibility = Visibility.Visible;
            }
        }

        private void Save_Ation(object sender, RoutedEventArgs e)
        {
            DishGivingModel _DishGivingModel = GivingDishSetting.DishGivingModel;
            this.Close();
        }
        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddGivingDishes GivingDishesWin = new AddGivingDishes();
            GivingDishesWin.ShowDialog();
        }
    }
}
