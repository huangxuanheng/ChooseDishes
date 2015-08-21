using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.ViewModel;
using IShow.ChooseDishes.ViewModel.ClearEstimateM;
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

namespace IShow.ChooseDishes.View.ClearEstimate
{
    /// <summary>
    /// ClearEstimateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ClearEstimateWindow : MetroWindow
    {
        ClearEstimateViewModel clearEstimateViewModel;
        public ClearEstimateWindow()
        {
            InitializeComponent();
            clearEstimateViewModel = this.DataContext as ClearEstimateViewModel;
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdataClearEstimate(object sender, RoutedEventArgs e)
        {
            ClearEstimateModel a = (ClearEstimateModel)this.dataGrid.SelectedItem;
            if (a != null)
            {
                ViewModelDeliver.Set(a);
                //BuyGivingDishes.OkSelect_Dish();
                ClearEstimateSettingWindow clearEstimateSettingWin = new ClearEstimateSettingWindow();
                clearEstimateSettingWin.ShowDifferentStyleWin(1);//修改操作，显示上下记录按钮
                clearEstimateSettingWin.ShowDialog();
            }
        }

        private void MidwayCancleClearEstimate(object sender, RoutedEventArgs e)
        {
            ClearEstimateModel a = (ClearEstimateModel)this.dataGrid.SelectedItem;
            if (a != null)
            {
                if (a.MidwayCancle == 0) { a.MidwayCancle = 1; } else if (a.MidwayCancle == 1) { a.MidwayCancle = 0; }
                clearEstimateViewModel.MidwayCancleClearEstimate(a);
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ZhiDingPriceButtom.IsChecked ?? false)
            {
                //BargainDishViewModel model = this.DataContext as BargainDishViewModel;
                //model.SelectedItemChanged(this.DatePickerMyDate.SelectedDate ?? DateTime.Now);
            }
        }
    }
}
