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

namespace IShow.ChooseDishes.View
{
    /// <summary>
    /// AddDishesMenuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddDishesMenuWindow : Window
    {
        public AddDishesMenuWindow()
        {
            InitializeComponent();
        }

        public string Code
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }


        private void btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            if (text_id.Text.Length <= 0 || text_id.Text.Length <= 0)
            {
                //做更多验证

                MessageBox.Show("菜牌编号不能为空！");
                return;
            }
            if (text_name.Text.Length <= 0 || text_name.Text.Length <= 0)
            {
                MessageBox.Show("菜牌名称不能为空！");
                return;
            }
            Code = text_id.Text;
            Name=text_name.Text;

            this.DialogResult = true;

            this.Close();

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
