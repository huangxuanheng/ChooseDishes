using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace IShow.ChooseDishes.Model.Booking
{
    /// <summary>
    /// 餐桌状态数据模型
    /// </summary>
    public class TableItemModel : ViewModelBase
    {

        /// <summary>
        /// 餐桌编号
        /// </summary>
        public string _Id;
        /// <summary>
        /// 餐桌名称
        /// </summary>
        public string _Name;

        /// <summary>
        /// 总计消费
        /// </summary>
        public double _Money;

        /// <summary>
        /// 入座人数
        /// </summary>
        public int _DefaultSeats;

        /// <summary>
        /// 餐桌状态
        /// </summary>
        public TableStatus _Status;

        /// <summary>
        /// 就餐人数
        /// </summary>
        public int _DiningNumber;

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime _StartTime;

        //结束时间
        public DateTime _EndTime;

        public bool _Locked;

        public TableItemModel(string _id, string _name, double _totalPrice, TableStatus _status, int _defaultSeats, int _diningNumber,bool _locked)
        {
            this.Id = _id;
            this.Name = _name;
            this.Money = _totalPrice;
            this.Status = _status;
            this.DefaultSeats = _defaultSeats;
            this.DiningNumber = _diningNumber;
            this.StartTime = DateTime.Now;
            this.Locked=_locked;
        }
        public TableItemModel(string _id, string _name, bool _locked)
        {
            this.Id = _id;
            this.Name = _name;
            this.Locked = _locked;
        }
        public TableItemModel(string _id, string _name, double _totalPrice, TableStatus _status)
        {
            this.Id = _id;
            this.Name = _name;
            this.Money = _totalPrice;
            this.Status = _status;
        }

        public TableItemModel(string _id, string _name, TableStatus _status)
        {
            this.Id = _id;
            this.Name = _name;
            this.Status = _status;
        }
        public string Id
        {
            get { return _Id; }
            set { Set("Id", ref _Id, value); }
        }

        public string Name
        {
            get { return _Name; }
            set { Set("Name", ref _Name, value); }
        }

        public double Money
        {
            set { Set("Money", ref _Money, value); }
            get
            {
                return _Money;
            }
        }

        public TableStatus Status
        {
            get { return _Status; }
            set { Set("Status", ref _Status, value); }
        }


        /// <summary>
        /// 入座人数
        /// </summary>
        public int DefaultSeats
        {
            get { return _DefaultSeats; }
            set { Set("DefaultSeats", ref _DefaultSeats, value); }
        }


        /// <summary>
        /// 就餐人数
        /// </summary>
        public  int DiningNumber
        {

            get { return _DiningNumber; }
            set { Set("DiningNumber", ref _DiningNumber, value); }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { Set("StartTime", ref _StartTime, value); }
        }



        //结束时间
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { Set("DateTime", ref _EndTime, value); }
        }

        public bool Locked{
            get {
                return _Locked;
            }
            set {

                Set("Locked", ref _Locked, value);
            }
        }


    }



}
