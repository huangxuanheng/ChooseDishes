using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Model.Booking;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Forms;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Api;
using System.Collections.ObjectModel;

namespace IShow.ChooseDishes.ViewModel.Booking
{
    public class TableLockViewModel : ViewModelBase
    {
        ITableItemService _DataService;
        public TableItemModel _SelectedItem;
        public TableItemModel SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                Set("SelectedItem", ref _SelectedItem, value);
            }
        }
        public ObservableCollection<TableItemModel> _Items;
        public ObservableCollection<TableItemModel> Items
        {
            get
            {
                return _Items ?? (_Items = new ObservableCollection<TableItemModel>());
            }
            set
            {
                Set("Items", ref _Items, value);
            }
        }
        public TableLockViewModel(ITableItemService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            InitTableData();
        }
        private List<TableItem> tts;
        private void InitTableData()
        {
            //for (int i = 0; i < 20; i++)
            //{
            //    Items.Add(new TableItemModel("一楼" + i, "112桌" + i, 2003, TableStatus.IDLE));
            //}
            tts = _DataService.GetAll();
            Items.Clear();
            if (tts != null)
            {
                foreach (var tt in tts)
                {
                    Table t = tt.Table;
                    if (tt.Status != 0)
                    {
                        Items.Add(new TableItemModel(tt.TableId+"", t.Name, TableStatus.Using));
                    }
                }
            }
        }
        public void SelectedItemChange()
        {
            DialogResult result=MessageBox.Show("您确定要锁定该桌台吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("该桌台已锁定");
            }
        }

        public void SearchByTableCode(string text)
        {
                if (tts != null)
                {
                    Items.Clear();
                    foreach (var tt in tts)
                    {
                        Table t = tt.Table;
                        if (t.Code.Contains(text))
                        {
                            if (tt.Status != 0)
                            {
                                Items.Add(new TableItemModel(tt.TableId + "", t.Name, TableStatus.Using));
                            }
                            
                        }
                    }
                }
        }
    }
}
