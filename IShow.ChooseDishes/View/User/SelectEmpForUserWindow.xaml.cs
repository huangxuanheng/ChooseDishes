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
using IShow.ChooseDishes.ViewModel;
using IShow.ChooseDishes.ViewModel.User;
using MahApps.Metro.Controls;

namespace IShow.ChooseDishes.View.User
{
    /// <summary>
    /// SelectEmpForUserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelectEmpForUserWindow : MetroWindow
    {
        public SelectEmpForUserWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            var s = this.DataContext as SelectEmpForUserViewModel;
            if (s.SelectedEmployee == null)
            {
                MessageBox.Show("请选择员工！");
                return;
            }
            else
            {
                ViewModelDeliver.Set(s.SelectedEmployee);
                this.DialogResult = true;
                this.Close();
            }
        }
   
    }
}
