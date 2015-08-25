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
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.View.Controls;
using IShow.ChooseDishes.ViewModel.Booking;

namespace IShow.ChooseDishes.View.Home.Booking
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {



        public HomePage()
        {
            InitializeComponent();
            //this.DataContext = new HomePageViewModel();
        }

        private void SysMgtButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.HorizontalOffset = 0;
            button.ContextMenu.VerticalOffset = button.ActualHeight;
            button.ContextMenu.IsOpen = true;
        }

        private void ServerMgt_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.HorizontalOffset = 0;
            button.ContextMenu.VerticalOffset = button.ActualHeight;
            button.ContextMenu.IsOpen = true;
        }

        private void TableMgt_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.HorizontalOffset = 0;
            button.ContextMenu.VerticalOffset = button.ActualHeight;
            button.ContextMenu.IsOpen = true;
        }

        private void TableItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ViewModel = DataContext as HomePageViewModel;
            ViewModel.TableSelectionChanged();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new TableLockWindow().ShowDialog();
        }

        private void TypeItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("sdsd");
            var ViewModel = DataContext as HomePageViewModel;
            ViewModel.TypeItemSelectionChanged();
        }

        private void TableStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ViewModel = DataContext as HomePageViewModel;
            ViewModel.TableStatusSelectionChanged();
        }
        /// <summary>
        /// 餐桌定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableLocation_Click(object sender, RoutedEventArgs e)
        {
            var ViewModel = DataContext as HomePageViewModel;
            ViewModel.InitTableLocation();
        }
        /// <summary>
        /// 加台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTable_Click(object sender, RoutedEventArgs e)
        {
            
            var ViewModel = DataContext as HomePageViewModel;
            ViewModel.InitAddTable();
        }
        /// <summary>
        /// 并台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Merge_Click(object sender, RoutedEventArgs e)
        {
            var ViewModel = DataContext as HomePageViewModel;
            ViewModel.MergeTable();
        }
        /// <summary>
        /// 搭台/拆台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JoinOrTear_Click(object sender, RoutedEventArgs e)
        {
            var ViewModel = DataContext as HomePageViewModel;
            ViewModel.OpenJoinOrTear();
        }

       
    }
}
