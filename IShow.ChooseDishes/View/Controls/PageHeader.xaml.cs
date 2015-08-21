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

namespace IShow.ChooseDishes.View.Controls
{
    /// <summary>
    /// Interaction logic for PageHeader.xaml
    /// </summary>
    public partial class PageHeader : UserControl
    {
        public PageHeader()
        {
            InitializeComponent();
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            this.RaiseEvent(new RoutedEventArgs(PageHeader.ClosingRoutedEvent));
        }

        public static readonly RoutedEvent ClosingRoutedEvent =
            EventManager.RegisterRoutedEvent("Closing", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(PageHeader));
        public event RoutedEventHandler Closing
        {
            add { this.AddHandler(ClosingRoutedEvent, value); }
            remove { this.RemoveHandler(ClosingRoutedEvent, value); }
        }
    }
}
