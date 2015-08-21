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
    public class BargainDishPriceBean : ObservableObject, IEditableObject
    {
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

        public int _BargainDishId;
        public int BargainDishId
        {
            get
            {
                return _BargainDishId;
            }
            set
            {
                Set("BargainDishId", ref _BargainDishId, value);
            }
        }

        public string _DishSpecification;
        public string DishSpecification
        {
            get
            {
                return _DishSpecification;
            }
            set
            {
                Set("DishSpecification", ref _DishSpecification, value);
            }
        }

        public double _Price1;
        public double Price1
        {
            get
            {
                return _Price1;
            }
            set
            {
                Set("Price1", ref _Price1, value);
            }
        }

        public double _Price2;
        public double Price2
        {
            get
            {
                return _Price2;
            }
            set
            {
                Set("Price2", ref _Price2, value);
            }
        }

        public double _Price3;
        public double Price3
        {
            get
            {
                return _Price3;
            }
            set
            {
                Set("Price3", ref _Price3, value);
            }
        }

        public double _MemberPrice3;
        public double MemberPrice3
        {
            get
            {
                return _MemberPrice3;
            }
            set
            {
                Set("MemberPrice3", ref _MemberPrice3, value);
            }
        }

        public double _MemberPrice2;
        public double MemberPrice2
        {
            get
            {
                return _MemberPrice2;
            }
            set
            {
                Set("MemberPrice2", ref _MemberPrice2, value);
            }
        }

        public double _MemberPrice1;
        public double MemberPrice1
        {
            get
            {
                return _MemberPrice1;
            }
            set
            {
                Set("MemberPrice1", ref _MemberPrice1, value);
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

        public System.DateTime _CreateTime;
        public System.DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                Set("CreateTime", ref _CreateTime, value);
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

        public Nullable<System.DateTime> _UpdateTime;
        public Nullable<System.DateTime> UpdateTime
        {
            get
            {
                return _UpdateTime;
            }
            set
            {
                Set("UpdateTime", ref _UpdateTime, value);
            }
        }

        public Nullable<int> _Update_by;
        public Nullable<int> Update_by
        {
            get
            {
                return _Update_by;
            }
            set
            {
                Set("Update_by", ref _Update_by, value);
            }
        }



        public BargainDishPriceBean CreateBargainDishPriceBean(BargainDishPrice bean)
        {
            this.Id = bean.Id;
            this.BargainDishId = bean.BargainDishId;
            this.DishSpecification = bean.DishSpecification;
            this.Price1 = bean.Price1;
            this.Price2 = bean.Price2;
            this.Price3 = bean.Price3;
            this.MemberPrice3 = bean.MemberPrice3;
            this.MemberPrice2 = bean.MemberPrice2;
            this.MemberPrice1 = bean.MemberPrice1;
            this.CreateBy = bean.CreateBy;
            this.CreateTime = bean.CreateTime;
            this.Deleted = bean.Deleted;
            this.UpdateTime = bean.UpdateTime;
            this.Update_by = bean.Update_by;
            return this;

        }
        public BargainDishPrice CreateBargainDishPrice(BargainDishPriceBean bean)
        {
            BargainDishPrice beanBack = new BargainDishPrice();
            beanBack.Id = bean.Id;
            beanBack.BargainDishId = bean.BargainDishId;
            beanBack.DishSpecification = bean.DishSpecification;
            beanBack.Price1 = bean.Price1;
            beanBack.Price2 = bean.Price2;
            beanBack.Price3 = bean.Price3;
            beanBack.MemberPrice3 = bean.MemberPrice3;
            beanBack.MemberPrice2 = bean.MemberPrice2;
            beanBack.MemberPrice1 = bean.MemberPrice1;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.CreateTime = bean.CreateTime;
            beanBack.Deleted = bean.Deleted;
            beanBack.UpdateTime = bean.UpdateTime;
            beanBack.Update_by = bean.Update_by;
            return beanBack;

        }

        public BargainDishPriceBean CreateBargainDishPriceBean(DishBean bean)
        {
            this.DishSpecification = bean.DishFormat;
            this.Price1 = bean.Price1;
            this.Price2 = bean.Price2;
            this.Price3 = bean.Price3;
            this.MemberPrice3 = bean.MemberPrice3;
            this.MemberPrice2 = bean.MemberPrice2;
            this.MemberPrice1 = bean.MemberPrice1;
            this.CreateTime = DateTime.Now;
            this.Deleted = 0;
            return this;

        }
    }
}
