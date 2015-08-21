using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IShow.ChooseDishes.ViewModel.Home
{
    public class ListWindowViewModel : ViewModelBase
    {

        public CollectionViewSource RecordsViewSource
        {
            get;
            set;
        }

        public ObservableCollection<HistoryRecord> Records
        {
            get;
            set;
        }

        #region private
        private void _Initialize()
        {
            try
            {
                Records = new ObservableCollection<HistoryRecord>();
                RecordsViewSource = new CollectionViewSource();
                RecordsViewSource.Source = Records;


                HistoryRecord hr = new HistoryRecord();
                hr.Id = "123";
                hr.ItemFullPath = "c:\\file.txt";
                hr.Count = 1;
                hr.DeviceName = "user1";
                hr.ItemSize = 100;
                Records.Add(hr);

                hr = new HistoryRecord();
                hr.Id = "123";
                hr.ItemFullPath = "c:\\HAHA.txt";
                hr.Count = 2;
                hr.DeviceName = "user1";
                hr.ItemSize = 100;
                Records.Add(hr);

                

                
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion

        public ListWindowViewModel(IMessenger messenger)
            : base(messenger)
        {
            _Initialize();
        }
    }
}
