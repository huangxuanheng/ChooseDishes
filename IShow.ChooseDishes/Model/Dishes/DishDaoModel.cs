using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class DishDaoBean : ObservableObject 
    {

       

      

        bool _Change=false;
        public bool Change
        {
            get
            {
                return _Change;
            }
            set
            {
                Set("Change", ref _Change, value);
            }
        }

        public Nullable<int> _OptionalNumber;
        public Nullable<int> OptionalNumber
        {
            get
            {
                return _OptionalNumber;
            }
            set
            {
                if (OptionalNumber != null && !OptionalNumber.Equals(value))
                {
                    Change = true;
                }
                if (DishDaoId == 0 && value != 1)
                {
                    Change = true;
                }
                Set("OptionalNumber", ref _OptionalNumber, value);
            }
        }
        public int _DishDaoId;
        public int DishDaoId
        {
            get
            {
                return _DishDaoId;
            }
            set
            {
                 Set("DishDaoId", ref _DishDaoId, value);
            }
        }

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

        public Nullable<int> _DishId;
        public Nullable<int> DishId
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

        public string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if ( Name != null&&!Name.Equals(value)) {
                    Change = true;
                }
                if (DishDaoId == 0 && value!=null)
                {

                    Change = true;
                }
                Set("Name", ref _Name, value);
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

        //DefaultName
        string _DefaultName;
        public string DefaultName
        {
            get
            {
                return _DefaultName;
            }
            set
            {
                Set("DefaultName", ref _DefaultName, value);
            }
        }

        //DefaultPrice
        double _DefaultPrice;
        public double DefaultPrice
        {
            get
            {
                return _DefaultPrice;
            }
            set
            {
                Set("DefaultPrice", ref _DefaultPrice, value);
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

        //Code
        string _Code;
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



        public DishDaoBean CreateDishDaoBean(DishDao bean)
        {
            this.DishDaoId = bean.DishDaoId;
            this.DishId = bean.DishId;
            this.Name = bean.Name;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            this.OptionalNumber = bean.OptionalNumber;
            this.Change = false;
            return this;

        }
        public DishDao CreateDishDao(DishDaoBean bean)
        {
            DishDao beanBack = new DishDao();
            beanBack.DishDaoId = bean.DishDaoId;
            beanBack.DishId = bean.DishId;
            beanBack.Name = bean.Name;
            beanBack.CreateDatetime = bean.CreateDatetime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.Deleted = bean.Deleted;
            beanBack.Status = bean.Status;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            beanBack.OptionalNumber = bean.OptionalNumber;
            return beanBack;

        }

    }
}
