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

namespace IShow.ChooseDishes.View.Home
{
    /// <summary>
    /// Interaction logic for CustomPopupWindow.xaml
    /// </summary>
    public partial class CustomPopupWindow : Window
    {
        public CustomPopupWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.RaiseEvent(new RoutedEventArgs(CustomPopupWindow.ClosingRoutedEvent));
        }

        public static readonly RoutedEvent ClosingRoutedEvent =
            EventManager.RegisterRoutedEvent("Closing", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(CustomPopupWindow));
        public event RoutedEventHandler Closing
        {
            add { this.AddHandler(ClosingRoutedEvent, value); }
            remove { this.RemoveHandler(ClosingRoutedEvent, value); }
        }
    }
}
