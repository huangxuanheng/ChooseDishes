using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.ViewModel.Common;

namespace IShow.ChooseDishes.ViewModel.Dishes
{
    public class ChooseForDishesMenuViewModel : ViewModelBase, IPagingControlContract
    {

        private ObservableCollection<object> _ItemSource;


        #region paging
        public uint GetTotalCount()
        {
            return 1000;
        }
        public ICollection<object> GetRecordsBy(uint StartingIndex, uint NumberOfRecords, object FilterTag)
        {
            List<object> result = new List<object>();
            int i = 0;
            while (i < NumberOfRecords)
            {
                Hashtable table = new Hashtable();
                table["Code"] = "code" + StartingIndex;
                table["Name"] = "Name" + StartingIndex;
                table["Unit"] = "Unit" + StartingIndex;
                table["Type"] = "Type" + StartingIndex;
                i++;
                result.Add(table);
            }
            return result;
        }
        #endregion paging

        public ObservableCollection<object> ItemSource {
            get {
                return _ItemSource ?? (_ItemSource=new ObservableCollection<object>());
            }
            set {
                Set("ItemSource", ref _ItemSource, value);
            }

        }
    }
}
