using IShow.ChooseDishes.View.BargainDish;
using IShow.ChooseDishes.View.CashWindow;
using IShow.ChooseDishes.View.Discount;
using IShow.ChooseDishes.View.Dishes;
using IShow.ChooseDishes.View.PromotionsDish;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.View.Home.Pages
{
    /// <summary>
    /// Interaction logic for BaseContentPage.xaml
    /// </summary>
    public partial class BaseContentPage : Page
    {
        public BaseContentPage()
        {
            InitializeComponent();
        }

        private void BaseContentBtn_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new BaseContentPage());
        }

        private void ForeMgrBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new QianTaiGuanLiPage());
        }

        private void TableCenterBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BaoBiaoZhongXinPage());
        }

        private void SysSettingBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new XiTongSheZhiPage());
        }

        private void OnClosingWindow(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomPopupWindow cpw = new CustomPopupWindow();
            cpw.Show();
        }

        private void Button_DishPackages(object sender, RoutedEventArgs e)
        {
            DishPackages pack = new DishPackages();
            pack.ShowDialog();
        }

        private void Button_DiscountView(object sender, RoutedEventArgs e)
        {
            DiscountView discount = new DiscountView();
            discount.ShowDialog();
        }

        private void OpenCashWin(object sender, RoutedEventArgs e)
        {
            CashWin _CashWin = new CashWin();
            _CashWin.ShowDialog();
        }

        private void OpenDishesMenuWindow(object sender, RoutedEventArgs e)
        {
            DishesMenuWindow _DishesMenuWindow = new DishesMenuWindow();
            _DishesMenuWindow.ShowDialog();
        }

        private void OpenBargainDishWin(object sender, RoutedEventArgs e)
        {
            BargainDishWin _BargainDishWin = new BargainDishWin();
            _BargainDishWin.ShowDialog();
        }

        private void OpenPromotionsDishWin(object sender, RoutedEventArgs e)
        {
            PromotionsDishWin _PromotionsDishWin = new PromotionsDishWin();
            _PromotionsDishWin.ShowDialog();
        }
    }
}
