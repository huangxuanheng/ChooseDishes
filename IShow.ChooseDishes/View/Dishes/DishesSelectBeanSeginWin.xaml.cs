﻿using IShow.ChooseDishes.ViewModel;
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
    /// Interaction logic for DishesSelectBeanSeginWin.xaml
    /// </summary>
    public partial class DishesSelectBeanSeginWin : Window
    {
        DishesSelectBeanViewModel dsbm;
        public DishesSelectBeanSeginWin()
        {
            InitializeComponent();
            dsbm = this.DataContext as DishesSelectBeanViewModel;
            dsbm.Init();
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ResetSelectValue_Fun(object sender, RoutedEventArgs e)
        {
            this.MoFuTiaoJian.Text = null;
            this.DishTypeBigComBoBoxBase.SelectedValue = null;
            this.DishTypeSmailComBoBoxBase.SelectedValue = null;
        }

        private void OkSelect_FUN(object sender, RoutedEventArgs e)
        {
            dsbm.OkSelectSegin_Fun();
            this.Close();
        }
    }
}
