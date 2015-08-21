using IShow.ChooseDishes.Model.EnumSet;
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

namespace IShow.ChooseDishes.View.Table
{
    /// <summary>
    /// UpdateTableType.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateTableType : Window
    {
        public UpdateTableType()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ServerFeeModeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ServerFeeMode!=null&&this.ServerFeeMode.SelectedValue != null)
            {
                if ((int)this.ServerFeeMode.SelectedValue == (int)ServerfreeMode.NOTHANDLE)
                { //服务费模式，不处理

                    this.StartUnit.IsEnabled = false;
                    this.StartMoney.IsEnabled = false;
                    this.StartGetMoneyTime.IsEnabled = false;
                    this.OutTime.IsEnabled = false;
                    this.OutMoney.IsEnabled = false;
                    this.OutTimeFree.IsEnabled = false;

                    this.ServerfreeNum.IsEnabled = false;
                    this.Rate.IsEnabled = false;
                    this.ServerfreeAccountType.IsEnabled = false;
                }
                else if ((int)this.ServerFeeMode.SelectedValue == (int)ServerfreeMode.TIMEUNIT) //时间单位
                {
                    this.StartUnit.IsEnabled = true;
                    this.StartMoney.IsEnabled = true;
                    this.StartGetMoneyTime.IsEnabled = true;
                    this.OutTime.IsEnabled = true;
                    this.OutMoney.IsEnabled = true;
                    this.OutTimeFree.IsEnabled = true;

                    this.ServerfreeNum.IsEnabled = false;
                    this.Rate.IsEnabled = false;
                    this.ServerfreeAccountType.IsEnabled = false;
                }
                else if ((int)this.ServerFeeMode.SelectedValue == (int)ServerfreeMode.CONSSERVERFEERATE)//消费额服务费率
                {
                    this.StartUnit.IsEnabled = false;
                    this.StartMoney.IsEnabled = false;
                    this.StartGetMoneyTime.IsEnabled = false;
                    this.OutTime.IsEnabled = false;
                    this.OutMoney.IsEnabled = false;
                    this.OutTimeFree.IsEnabled = false;

                    this.ServerfreeNum.IsEnabled = false;
                    this.Rate.IsEnabled = true;
                    this.ServerfreeAccountType.IsEnabled = true;
                }
                else if ((int)this.ServerFeeMode.SelectedValue == (int)ServerfreeMode.TABLEFEE)//餐桌定额
                {
                    this.StartUnit.IsEnabled = false;
                    this.StartMoney.IsEnabled = false;
                    this.StartGetMoneyTime.IsEnabled = false;
                    this.OutTime.IsEnabled = false;
                    this.OutMoney.IsEnabled = false;
                    this.OutTimeFree.IsEnabled = false;

                    this.ServerfreeNum.IsEnabled = true;
                    this.Rate.IsEnabled = false;
                    this.ServerfreeAccountType.IsEnabled = false;
                }
                else if ((int)this.ServerFeeMode.SelectedValue == (int)ServerfreeMode.DISHSERVERFEERATE)//菜品消费服务费率
                {
                    this.StartUnit.IsEnabled = false;
                    this.StartMoney.IsEnabled = false;
                    this.StartGetMoneyTime.IsEnabled = false;
                    this.OutTime.IsEnabled = false;
                    this.OutMoney.IsEnabled = false;
                    this.OutTimeFree.IsEnabled = false;

                    this.ServerfreeNum.IsEnabled = false;
                    this.Rate.IsEnabled = true;
                    this.ServerfreeAccountType.IsEnabled = true;
                }
            }
        }
    }
}
