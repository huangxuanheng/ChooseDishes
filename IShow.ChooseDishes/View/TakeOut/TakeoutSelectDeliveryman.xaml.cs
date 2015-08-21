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
    /// Interaction logic for TakeoutSelectDeliverman.xaml
    /// </summary>
    public partial class TakeoutSelectDeliverman : Window
    {
        public static TakeoutSelectDeliverman ts;
        TakeoutOrderViewModel model;
        public TakeoutSelectDeliverman()
        {
            InitializeComponent();
            ts = this;
            model = this.DataContext as TakeoutOrderViewModel;
            model.loaderAllPersonnel();
        }
        public void initGrid()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    var btn = new Button();
                    btn.Click += btn_Click;
                    //rb.Background = new BitmapImage(new Uri());
                    btn.Content = x + "-" + y;
                    if (x % 2 == 1 && y % 2 == 1)
                    {
                        Grid.SetRow(btn, x);
                        Grid.SetColumn(btn, y);
                        DeliverySelected.Children.Add(btn);
                    }
                }
            } 
        }
        private void btn_Click(object sender, EventArgs e)
        {
            var btn =(Button) sender;
            //MessageBox.Show("点击了button=="+btn.Content);
            //DeliveryMan
            model.DeliveryMan = btn.Content.ToString();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TakeoutOrderViewModel model = this.DataContext as TakeoutOrderViewModel;
            //每输入一个编号，就访问一次数据库
            model.LoaderPersonnelByInputNumber();
        }
        public static TakeoutSelectDeliverman getInstance()
        {
            return ts;
        }
    }
}
