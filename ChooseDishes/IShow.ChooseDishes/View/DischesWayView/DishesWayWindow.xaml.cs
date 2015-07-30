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
            ObservableCollection<DishesWayItemBean> dwib = new ObservableCollection<DishesWayItemBean>();
            dwib.Add(new DishesWayItemBean()
            {
                DischesWayId = 1
            });
            dwib.Add(new DishesWayItemBean()
            {

            });
            dwib.Add(new DishesWayItemBean()
            {

            });
            dwib.Add(new DishesWayItemBean()
            {

            });
            DishesWayItem.DataContext = dwib;
           
        }
        public class DishesWayItemBean
        {
            public int DischesWayId { get; set; }
            public int DischesWayNameId { get; set; }
            public int Code { get; set; }
            public string Name { get; set; }
            public string WayDetail { get; set; }
            public string PingYing { get; set; }
            public double AddPrice { get; set; }
            public int AddPriceByNum { get; set; }
            public System.DateTime CreateDatetime { get; set; }
            public int CreateBy { get; set; }
            public int Deleted { get; set; }
            public int Status { get; set; }
            public Nullable<System.DateTime> UpdateDatetime { get; set; }
            public Nullable<int> UpdateBy { get; set; }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
