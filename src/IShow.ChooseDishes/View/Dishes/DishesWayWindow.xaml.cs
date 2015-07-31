using IShow.ChooseDishes.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IShow.ChooseDishes.View.dischesWayView
{
    /// <summary>
    /// Interaction logic for DischesWayWindow.xaml
    /// </summary>
    public partial class DischesWayWindow : Window
    {
        public DischesWayWindow()
        {
            InitializeComponent();
        }
       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
