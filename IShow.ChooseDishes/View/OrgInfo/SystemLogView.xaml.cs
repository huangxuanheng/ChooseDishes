﻿using IShow.ChooseDishes.ViewModel;
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

namespace IShow.ChooseDishes.View.OrgInfo
{
    /// <summary>
    /// Interaction logic for SystemLog.xaml
    /// </summary>
    public partial class SystemLogView : MetroWindow
    {
        public SystemLogView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SystemLogViewModel svm = this.DataContext as SystemLogViewModel;
            if (svm != null)
            {
                svm.ShowDetail();
            }
            
        }

    }
}
