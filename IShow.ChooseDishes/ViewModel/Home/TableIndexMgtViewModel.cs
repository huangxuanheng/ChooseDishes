using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IShow.ChooseDishes.Model.EnumSet;

namespace IShow.ChooseDishes.ViewModel.Home
{
    /// <summary>
    /// 餐桌主页面
    /// </summary>
    class TableIndexMgtViewModel:ViewModelBase
    {
        ObservableCollection<TableStatusItem> _TableStatusItems;
        ObservableCollection<TableStatusItem> _TableTypes;
        ObservableCollection<TableStatusItem> _MenuItems;
        public ObservableCollection<TableStatusItem> MenuItems
        {
            get
            {
                return _MenuItems ?? (_MenuItems = new ObservableCollection<TableStatusItem>());
            }
            set
            {
                Set("MenuItems", ref _MenuItems, value);
            }


        }
        public RelayCommand<object> _SelectCommand;

        private bool _IsOpen;

        public bool IsOpen {
            get {
                return _IsOpen;
            }
            set {
                Set("IsOpen", ref _IsOpen, value);
            }
        }
        RelayCommand _SystemMenuPopupShowCommand;
        public RelayCommand SystemMenuPopupShowCommand {
            get {
                return _SystemMenuPopupShowCommand ?? (_SystemMenuPopupShowCommand = new RelayCommand(() => {
                    IsOpen = !IsOpen;
                }));

            }
            set
            {
                Set("SystemMenuPopupShowCommand", ref _SystemMenuPopupShowCommand, value);

            }
        }

        public RelayCommand<object> SelectCommand {
            get {
                return _SelectCommand ?? (_SelectCommand = new RelayCommand<object>((id) =>
                {
                    MessageBox.Show("hello"+id);
                }));
            }
            set {
                Set("SelectCommand", ref _SelectCommand, value);
            }
        
        }

        public ObservableCollection<TableStatusItem> TableStatusItems
        {
            get
            {
                return _TableStatusItems ?? (_TableStatusItems = new ObservableCollection<TableStatusItem>());
            }
            set {
                Set("TableStatusItems", ref _TableStatusItems, value);
            }
           

        }


        public ObservableCollection<TableStatusItem> TableTypes {
            get
            {
                return _TableTypes ?? (_TableTypes = new ObservableCollection<TableStatusItem>());
            }
            set
            {
                Set("TableTypes", ref _TableTypes, value);
            }
        
        }

        public TableIndexMgtViewModel(){
            for (int i = 0; i < 100; i++)
            {
                TableStatusItems.Add(new TableStatusItem("id" + i, "name" + i, (i + 5) % 20, i,i%2==0?TableStatus.FREE:TableStatus.LOCKED));
            }

            TableTypes.Add(new TableStatusItem("allTypes", "全部桌类", 5, 3,TableStatus.LOCKED));
            for (int i = 0; i < 5; i++)
            {
                TableTypes.Add(new TableStatusItem("id" + i, "name" + i, (i + 5) % 20, i,TableStatus.LOCKED));
            }
            for (int i = 0; i < 5; i++)
            {
                MenuItems.Add(new TableStatusItem("id" + i, "name" + i, (i + 5) % 20, i, TableStatus.LOCKED));
            }
        }




    }

    public class TableStatusItem {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Seats{get;set;}

        public double Total{get;set;}

        public TableStatus Status
        {
            get;
            set;
        }

        public TableStatusItem(string id, string name, int seats, double total,TableStatus status)
        {
            this.Id = id;
            this.Name = name;
            this.Seats = seats;
            this.Total = total;
            this.Status = status;
        }
    
    }
}
