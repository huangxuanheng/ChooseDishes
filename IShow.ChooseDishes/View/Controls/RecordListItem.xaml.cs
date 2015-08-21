using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.ViewModel.Home;
using Microsoft.Practices.ServiceLocation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IShow.ChooseDishes.ViewModel;

namespace IShow.ChooseDishes.View.Controls
{
    /// <summary>
    /// Interaction logic for RecordListItem.xaml
    /// </summary>
    public partial class RecordListItem : UserControl
    {
        public RecordListItem()
        {
            InitializeComponent();
        }


        private void _OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            try
            {
              //  _UpdateContextMenuItemsStatus(sender as Button);
            }
            catch
            { }
        }

        private void _OnItemOperateButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                button.ContextMenu.PlacementTarget = button;
                button.ContextMenu.HorizontalOffset = button.ActualWidth / 2;
                button.ContextMenu.VerticalOffset = button.ActualHeight / 2;
                button.ContextMenu.IsOpen = true;
            }
            catch
            { }
        }

        private void _OnOpenMenuItemClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Open: " + _Record.ItemFullPath);
            }
            catch
            { }
        }
        private void _OnOpenLocationMenuItemClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("OpenLocation");
            }
            catch
            { }
        }
        private void _OnDeleteRecordMenuItemClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("DeleteRecord");
            }
            catch
            { }
        }
        private HistoryRecord _Record
        {
            get
            {
                return this.DataContext as HistoryRecord;
            }
        }
        private ListWindowViewModel _HistoryViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListWindowViewModel>();
            }
        }
    }
}
