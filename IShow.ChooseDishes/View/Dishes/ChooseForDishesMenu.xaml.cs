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
    /// ChooseForDishesMenu.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseForDishesMenu : Window
    {
        public ChooseForDishesMenu()
        {
            InitializeComponent();
        }

        private void pageControl_PreviewPageChange(object sender, PageChangedEventArgs args)
        {
            List<Object> items = pageControl.ItemsSource.ToList();
            int count = items.Count;
        }

        private void pageControl_PageChanged(object sender, PageChangedEventArgs args)
        {
            List<Object> items = pageControl.ItemsSource.ToList();
            int count = items.Count;
        }
    }
}
