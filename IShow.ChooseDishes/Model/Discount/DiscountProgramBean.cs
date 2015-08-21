using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.Discount
{
    public class DiscountProgramBean : ObservableObject
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

        public string _Name;
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

        public int _ByDish;
        public int ByDish
        {
            get
            {
                return _ByDish;
            }
            set
            {
                Set("ByDish", ref _ByDish, value);
            }
        }

        public double _Rate;
        public double Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                Set("Rate", ref _Rate, value);
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



        public DiscountProgramBean CreateDiscountProgramBean(DiscountProgram bean)
        {
            this.DiscountId = bean.DiscountId;
            this.Code = bean.Code;
            this.Name = bean.Name;
            this.ByDish = bean.ByDish;
            this.Rate = bean.Rate;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;

        }
        public DiscountProgram CreateDiscountProgram(DiscountProgramBean bean)
        {
            DiscountProgram beanBack = new DiscountProgram();
            beanBack.DiscountId = bean.DiscountId;
            beanBack.Code = bean.Code;
            beanBack.Name = bean.Name;
            beanBack.ByDish = bean.ByDish;
            beanBack.Rate = bean.Rate;
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
