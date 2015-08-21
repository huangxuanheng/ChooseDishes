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
    public class PromotionsDishDetailBean : ObservableObject, IEditableObject
    {

        public decimal _Id;
        public decimal Id
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

        public int _PromotionsDishId;
        public int PromotionsDishId
        {
            get
            {
                return _PromotionsDishId;
            }
            set
            {
                Set("PromotionsDishId", ref _PromotionsDishId, value);
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

        public int _DishNumber;
        public int DishNumber
        {
            get
            {
                return _DishNumber;
            }
            set
            {
                IsModify = true;
                Set("DishNumber", ref _DishNumber, value);
            }
        }

        public string _DishFormat;
        public string DishFormat
        {
            get
            {
                return _DishFormat;
            }
            set
            {
                Set("DishFormat", ref _DishFormat, value);
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

        public  PromotionsDish PromotionsDish;

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
        //DishName
        string _DishName;
        public string DishName
        {
            get
            {
                return _DishName;
            }
            set
            {
                Set("DishName", ref _DishName, value);
            }
        }


        public PromotionsDishDetailBean CreatePromotionsDishDetailBean(PromotionsDishDetail bean)
        {
            this.Id = bean.Id;
            this.PromotionsDishId = bean.PromotionsDishId;
            this.DishId = bean.DishId;
            this.DishNumber = bean.DishNumber;
            this.DishFormat = bean.DishFormat;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            this.PromotionsDish = bean.PromotionsDish;
            return this;

        }
        public PromotionsDishDetail CreatePromotionsDishDetail(PromotionsDishDetailBean bean)
        {
            PromotionsDishDetail beanBack = new PromotionsDishDetail();
            beanBack.Id = bean.Id;
            beanBack.PromotionsDishId = bean.PromotionsDishId;
            beanBack.DishId = bean.DishId;
            beanBack.DishNumber = bean.DishNumber;
            beanBack.DishFormat = bean.DishFormat;
            beanBack.CreateDatetime = bean.CreateDatetime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.Deleted = bean.Deleted;
            beanBack.Status = bean.Status;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            beanBack.PromotionsDish = bean.PromotionsDish;
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

        public  PromotionsDishDetailBean CreatePromotionsDishDetailBeanByDishBeanUtil(DishBeanUtil element)
        {
            this.Code = element.Code;
            this.DishName = element.DishName;
            this.DishFormat = element.DishFormat;
            this.DishId = element.DishId;
            this.DishNumber = 1;

            return this;
        }
    }
}
