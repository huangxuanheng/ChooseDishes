﻿using MahApps.Metro.Controls;
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
    /// Interaction logic for SystemLogDetail.xaml
    /// </summary>
    public partial class SystemLogDetail : MetroWindow
    {
        public SystemLogDetail()
        {
            InitializeComponent();
        }

        private void Exit_Win(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
