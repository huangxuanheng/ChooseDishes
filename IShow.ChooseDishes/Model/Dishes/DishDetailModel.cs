using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class DishDetailBean : ObservableObject 
    {
        public Action<object> CheckedInvoke { get; set; }
        //DishName
        bool _Change = false;
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
        //菜品规格
        public string _DishFormatName;
        public string DishFormatName
        {
            get
            {
                return _DishFormatName;
            }
            set
            {
                Set("DishFormatName", ref _DishFormatName, value);
            }
        }
        //菜品单位名字 
        public string _DishUnitName;
        public string DishUnitName
        {
            get
            {
                return _DishUnitName;
            }
            set
            {
                Set("DishUnitName", ref _DishUnitName, value);
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

        public int _DishDetailId;
        public int DishDetailId
        {
            get
            {
                return _DishDetailId;
            }
            set
            {
                Set("DishDetailId", ref _DishDetailId, value);
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

        public int _Num;
        public int Num
        {
            get
            {
                return _Num;
            }
            set
            {
                if (Num != 0 && !Num.Equals(value))
                {
                    Change = true;
                }
                if (DishDetailId == 0 && value != 0)
                {
                    Change = true;
                }

                Set("Num", ref _Num, value);
                
            }
        }

        public Nullable<int> _IsMain;
        public Nullable<int> IsMain
        {
            get
            {
                return _IsMain;
            }
            set
            {
                if (IsMain != null && !IsMain.Equals(value))
                {
                    Change = true;
                }
                if (DishDetailId == 0 && value != null)
                {
                    Change = true;
                }
                Set("IsMain", ref _IsMain, value);
            }
        }

        public Nullable<int> _Type;
        public Nullable<int> Type
        {
            get
            {
                return _Type;
            }
            set
            {
                Set("Type", ref _Type, value);
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



        public DishDetailBean CreateDishDetailBean(DishDetail bean)
        {
            this.DishDetailId = bean.DishDetailId;
            this.DishId = bean.DishId;
            this.DishDaoId = bean.DishDaoId;
            this.Num = bean.Num;
            this.IsMain = bean.IsMain;
            this.Type = bean.Type;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;

        }
        public DishDetail CreateDishDetail(DishDetailBean bean)
        {
            DishDetail beanBack = new DishDetail();
            beanBack.DishDetailId = bean.DishDetailId;
            beanBack.DishId = bean.DishId;
            beanBack.DishDaoId = bean.DishDaoId;
            beanBack.Num = bean.Num;
            beanBack.IsMain = bean.IsMain;
            beanBack.Type = bean.Type;
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
