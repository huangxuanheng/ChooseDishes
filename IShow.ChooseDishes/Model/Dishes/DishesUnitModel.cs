using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class DishesUnitModel : ObservableObject, IEditableObject
    {
        public int _DishUnitId;
        public int DishUnitId
        {
            get
            {
                return _DishUnitId;
            }
            set
            {
                Set("DishUnitId", ref _DishUnitId, value);
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

        public int _SaleType;
        public int SaleType
        {
            get
            {
                return _SaleType;
            }
            set
            {
                Set("SaleType", ref _SaleType, value);
            }
        }

        public double _OrderNum;
        public double OrderNum
        {
            get
            {
                return _OrderNum;
            }
            set
            {
                Set("OrderNum", ref _OrderNum, value);
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


        //SaleTypeName
        public string _SaleTypeName;
        public string SaleTypeName
        {
            get
            {
                _SaleTypeName = SaleType == 1 ? "整数" : "小数";
                return _SaleTypeName;
            }
            set
            {
                Set("Status", ref _SaleTypeName, value);
            }
        }


        public DishesUnitModel CreateDishUnitBean(DishUnit bean)
        {
            this.DishUnitId = bean.DishUnitId;
            this.Name = bean.Name;
            this.SaleType = bean.SaleType;
            this.OrderNum = bean.OrderNum;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;

        }
        public DishUnit CreateDishUnit(DishesUnitModel bean)
        {
            DishUnit beanBack = new DishUnit();
            beanBack.DishUnitId = bean.DishUnitId;
            beanBack.Name = bean.Name;
            beanBack.SaleType = bean.SaleType;
            beanBack.OrderNum = bean.OrderNum;
            beanBack.CreateDatetime = bean.CreateDatetime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.Deleted = bean.Deleted;
            beanBack.Status = bean.Status;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            return beanBack;

        }
        public bool IsModify { get; set; }
        public void BeginEdit()
        {
            IsModify = true;
        }

        public void CancelEdit()
        {
            IsModify = false;
        }

        public void EndEdit()
        {
            IsModify = true;
        }

    }
}
