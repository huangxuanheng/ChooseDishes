using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.Discount
{
    public class DiscountDetailBean : ObservableObject
    {
        public int _LineNumber;
        public int LineNumber
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
        public string _Code;
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                Set("Code", ref _Code, value);
            }
        }

        public string _SmallType;
        public string SmallType
        {
            get
            {
                return _SmallType;
            }
            set
            {
                Set("SmallType", ref _SmallType, value);
            }
        }
        public string _BigType;
        public string BigType
        {
            get
            {
                return _BigType;
            }
            set
            {
                Set("BigType", ref _BigType, value);
            }
        }

        public int _Id;
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

        public int _DishId;
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

        public int _DiscountId;
        public int DiscountId
        {
            get
            {
                return _DiscountId;
            }
            set
            {
                Set("DiscountId", ref _DiscountId, value);
            }
        }

        public double _DiscountValue;
        public double DiscountValue
        {
            get
            {
                return _DiscountValue;
            }
            set
            {
                Set("DiscountValue", ref _DiscountValue, value);
            }
        }

        public System.DateTime _CreateDatetime;
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

        public int _CreateBy;
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

        public int _Deleted;
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

        public int _Status;
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

        public Nullable<System.DateTime> _UpdateDatetime;
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

        public Nullable<int> _UpdateBy;
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



        public DiscountDetailBean CreateDiscountDetailBean(DiscountDetail bean)
        {
            this.Id = bean.Id;
            this.DishId = bean.DishId;
            this.DiscountId = bean.DiscountId;
            this.DiscountValue = bean.DiscountValue;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;

        }
        public DiscountDetail CreateDiscountDetail(DiscountDetailBean bean)
        {
            DiscountDetail beanBack = new DiscountDetail();
            beanBack.Id = bean.Id;
            beanBack.DishId = bean.DishId;
            beanBack.DiscountId = bean.DiscountId;
            beanBack.DiscountValue = bean.DiscountValue;
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
