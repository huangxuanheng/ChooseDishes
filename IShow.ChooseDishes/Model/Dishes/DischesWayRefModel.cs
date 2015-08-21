using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class DischesWayRefModel : ObservableObject
    {
        int _LineNumber;
        public int LineNumber   //行号
        {
            get
            {
                return _LineNumber;
            }
            set
            {
                Set("LineNumber", ref _LineNumber, value);
            }
        }
        int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                Set("Id", ref _Id, value);
            }
        }

        int _DishId;
        public int DishId
        {
            get
            {
                return _DishId;
            }
            set
            {
                Set("DishId", ref _DishId, value);
            }
        }

        int _DischesWayId;
        public int DischesWayId
        {
            get
            {
                return _DischesWayId;
            }
            set
            {
                Set("DischesWayId", ref _DischesWayId, value);
            }
        }

        double _Price;
        public double Price
        {
            get
            {
                return _Price;
            }
            set
            {
                Set("Price", ref _Price, value);
            }
        }

        System.DateTime _CreateDatetime;
        public System.DateTime CreateDatetime
        {
            get
            {
                return _CreateDatetime;
            }
            set
            {
                Set("CreateDatetime", ref _CreateDatetime, value);
            }
        }

        int _CreateBy;
        public int CreateBy
        {
            get
            {
                return _CreateBy;
            }
            set
            {
                Set("CreateBy", ref _CreateBy, value);
            }
        }

        int _Deleted;
        public int Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                Set("Deleted", ref _Deleted, value);
            }
        }

        int _Status;
        public int Status
        {
            get
            {
                return _Status;
            }
            set
            {
                Set("Status", ref _Status, value);
            }
        }

        Nullable<System.DateTime> _UpdateDatetime;
        public Nullable<System.DateTime> UpdateDatetime
        {
            get
            {
                return _UpdateDatetime;
            }
            set
            {
                Set("UpdateDatetime", ref _UpdateDatetime, value);
            }
        }

        Nullable<int> _UpdateBy;
        public Nullable<int> UpdateBy
        {
            get
            {
                return _UpdateBy;
            }
            set
            {
                Set("UpdateBy", ref _UpdateBy, value);
            }
        }
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Set("Name", ref _Name, value);
            }
        }
        public DischesWayRefModel CreateDischesWayRefModel(DischesWayRef bean)
        {
            this.Id = bean.Id;
            this.DishId = bean.DishId;
            this.DischesWayId = bean.DischesWayId;
            this.Price = bean.Price;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            this.Name = bean.DischesWay.Name;
            return this;

        }
        public DischesWayRef CreateDischesWayRef(DischesWayRefModel bean)
        {
            DischesWayRef beanBack = new DischesWayRef();
            beanBack.Id = bean.Id;
            beanBack.DishId = bean.DishId;
            beanBack.DischesWayId = bean.DischesWayId;
            beanBack.Price = bean.Price;
            beanBack.CreateDatetime = bean.CreateDatetime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.Deleted = bean.Deleted;
            beanBack.Status = bean.Status;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            return beanBack;

        }

    }
}
