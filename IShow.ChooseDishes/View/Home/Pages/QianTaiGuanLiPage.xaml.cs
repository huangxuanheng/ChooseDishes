﻿using IShow.ChooseDishes.View.Home.Booking;
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
    /// Interaction logic for QianTaiGuanLiPage.xaml
    /// </summary>
    public partial class QianTaiGuanLiPage : Page
    {
        public QianTaiGuanLiPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void BaseContentBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BaseContentPage());
        }

        private void ForeMgrBtn_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new QianTaiGuanLiPage());
        }

        private void TableCenterBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BaoBiaoZhongXinPage());
        }

        private void SysSettingBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new XiTongSheZhiPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }

        private void OnClosingWindow(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).Close();
        }
    }
}
