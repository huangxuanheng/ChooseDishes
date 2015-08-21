using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Model.Booking;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Data;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel.Booking
{
    public class HomePageViewModel:ViewModelBase
    {
        ITableService _TableService;
        #region 餐桌类型
        private string _TypeSelectedItem;
        public string TypeSelectedItem
        {
            get {
                return _TypeSelectedItem;
            }
            set {
                Set("TypeSelectedItem", ref _TypeSelectedItem, value);
            }
        }
        ObservableCollection<string> _TypeItems;
        public ObservableCollection<string> TypeItems
        {
            get {
                return _TypeItems ?? (_TypeItems = new ObservableCollection<string>());
            }
            set {
                Set("TypeItems", ref _TypeItems, value);
            }
        }
        #endregion

        #region 餐台状态
        private TableItemModel _TableSelectedItem;
        public TableItemModel TableSelectedItem
        {
            get
            {
                return _TableSelectedItem;
            }
            set
            {
                Set("TableSelectedItem", ref _TableSelectedItem, value);
            }
        }
        private ObservableCollection<TableItemModel> _TableItems;
        public ObservableCollection<TableItemModel> TableItems
        {
            get
            {
                return _TableItems ?? (_TableItems = new ObservableCollection<TableItemModel>());
            }
            set
            {
                Set("TableItems", ref _TableItems, value);
            }
        }
        #endregion 

        public HomePageViewModel(ITableService _Service, IMessenger messenger)
        {
            _TableService = _Service;
            InitTableData();
        }

        private void InitTableData()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    TableItems.Add(new TableItemModel(i * 10 + "00" + 1, "1000", 88.322, TableStatus.Using, 9, 0, true));
            //    TableItems.Add(new TableItemModel(i * 10 + "00" + 2, "1000", 88.322, TableStatus.Idle, 5, 4, true));
            //    TableItems.Add(new TableItemModel(i * 10 + "00" + 2, "1000", 88.322, TableStatus.Using, 5, 4, true));
            //    TableItems.Add(new TableItemModel(i * 10 + "00" + 3, "1000", 887.54, TableStatus.Using, 10, 3, true));
            //    TableItems.Add(new TableItemModel(i * 10 + "00" + 4, "1000", i % 2 == 0 ? 0 : 20.00, TableStatus.Waiting, 2, 4, true));
            //}
            TypeItems.Add("所有桌台");
            List<TableType>types=_TableService.GetAllTypes();
            TableItems.Clear();
            if(types!=null&&types.Count>0)
            foreach (var type in types)
            {
                TypeItems.Add("桌台"+type.Name);
                ICollection<Table>tables=type.Table;
                if (tables != null && tables.Count > 0)
                {
                    foreach (var table in tables)
                    {
                        ICollection<TableItem>items=table.TableItem;
                        if (items != null && items.Count > 0)
                        {
                            foreach (var item in items)
                            {
                                if (item.Status == 0)
                                {
                                    TableItems.Add(new TableItemModel(item.Id + "", table.Name,0, TableStatus.Idle,9,0,false));
                                }
                                if (item.Status == 1)
                                {
                                    TableItems.Add(new TableItemModel(item.Id + "", table.Name,100, TableStatus.Using,18,20,true));
                                }
                                if (item.Status == 2)
                                {
                                    TableItems.Add(new TableItemModel(item.Id + "", table.Name, TableStatus.Waiting));
                                }
                            }
                        }
                    }
                }
            }
        }



        public  void TableSelectionChanged()
        {
            ///TODO 开台或者点菜
            MessageBox.Show("确定要对" + TableSelectedItem.Name+"进行开台吗？","提示",MessageBoxButton.YesNo);
        }
    }
}
