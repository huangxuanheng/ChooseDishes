using IShow.ChooseDishes.ViewModel;
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

namespace IShow.ChooseDishes.View.TakeOut
{
    /// <summary>
    /// Interaction logic for TakeoutOrderWindow.xaml
    /// </summary>
    public partial class TakeoutOrderWindow : Window
    {
        private static TakeoutOrderWindow tow;
        public TakeoutOrderWindow()
        {
            InitializeComponent();
            tow = this;
        }

        private void Cancle(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public static  TakeoutOrderWindow getInstance()
        {
            return tow;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //调用model层方法查询数据库，如果查询到结果，则显示在界面上
            //TakeoutOrderViewModel model = this.DataContext as TakeoutOrderViewModel;
            //TreeNodeModel node = sender as TreeNodeModel;
            //model.SelectedItemChanged(e.NewValue as DishesWayTreeNode);
           // MessageBox.Show("文本发送改变了" + sender.Equals(OrderName));
        }
    }
}
