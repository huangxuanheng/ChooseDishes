
using IShow.ChooseDishes.ViewModel;
using System;

namespace IShow.ChooseDishes.Model
{
    public class HistoryRecord : IShowModelBase
    {
        #region public
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (Set<string>(ref _id, value))
                {
                    CustomRaisePropertyChanged("Id");
                }
            }
        }
        public string DeviceName
        {
            get
            {
                return _deviceName;
            }
            set
            {
                if (Set<string>(ref _deviceName, value))
                {
                    CustomRaisePropertyChanged("DeviceName");
                }
            }
        }
        public long ItemSize
        {
            get
            {
                return _itemSize;
            }
            set
            {
                if (Set<long>(ref _itemSize, value))
                {
                    CustomRaisePropertyChanged("ItemSize");
                }
            }
        }
        public string ItemFullPath
        {
            get
            {
                return _itemFullPath;
            }
            set
            {
                if (Set<string>(ref _itemFullPath, value))
                {
                    CustomRaisePropertyChanged("ItemFullPath");
                }
            }
        }

        public string ItemName
        {
            get
            {
                string name = ItemFullPath;
                try
                {
                    int pos = ItemFullPath.LastIndexOf("\\");
                    if (pos != -1)
                    {
                        name = ItemFullPath.Substring(pos + 1, ItemFullPath.Length - pos - 1);
                    }
                }
                catch
                { }
                return name;
            }
        }
        public uint Count
        {
            set
            {
                if (Set<uint>(ref _count, value))
                {
                    CustomRaisePropertyChanged("Count");
                }
            }
            get
            {
                return _count;
            }
        }
        #endregion

        #region private
        private string _id = "";
        private string _deviceName = "";
        private long _itemSize = 0;
        private string _itemFullPath = "";
        private uint _count = 0;
        #endregion
    }
}
