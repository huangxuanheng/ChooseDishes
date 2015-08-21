using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public partial class DishGivingModel : ViewModelBase
    {
        //行号
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
        //品码
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
        //DishName品名
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
        //菜品规格
        string _DishFormat;
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
        //菜品单位ID
        int? _DishUnitId;
        public int? DishUnitId
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
        //赠送品码
        string _Code_Giving;
        public string Code_Giving
        {
            get
            {
                return _Code_Giving;
            }
            set
            {
                Set("Code_Giving", ref _Code_Giving, value);
            }
        }
        //赠送品名
        string _DishName_Giving;
        public string DishName_Giving
        {
            get
            {
                return _DishName_Giving;
            }
            set
            {
                Set("DishName_Giving", ref _DishName_Giving, value);
            }
        }
        //赠送菜品规格
        string _DishFormat_Giving;
        public string DishFormat_Giving
        {
            get
            {
                return _DishFormat_Giving;
            }
            set
            {
                Set("DishFormat_Giving", ref _DishFormat_Giving, value);
            }
        }
        //赠送菜品单位ID
        int? _DishUnitId_Giving;
        public int? DishUnitId_Giving
        {
            get
            {
                return _DishUnitId_Giving;
            }
            set
            {
                Set("DishUnitId_Giving", ref _DishUnitId_Giving, value);
            }
        }
        //赠送菜品单位名字 
        public string _DishUnitName_Giving;
        public string DishUnitName_Giving
        {
            get
            {
                return _DishUnitName_Giving;
            }
            set
            {
                Set("DishUnitName_Giving", ref _DishUnitName_Giving, value);
            }
        }
        //消费基数
        public string _ConsumeCount = "1.00";
        public string ConsumeCount {
            get
            {
                return _ConsumeCount;
            }
            set
            {
                Set("ConsumeCount", ref _ConsumeCount, value);
            }
        }
        //赠送数量
        public string _GivingCount = "1.00";
        public string GivingCount
        {
            get
            {
                return _GivingCount;
            }
            set
            {
                Set("_GivingCount", ref _GivingCount, value);
            }
        }
        //开始时间
        public string _StartTime = "00:00";
        public string StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                Set("StartTime", ref _StartTime, value);
            }
        }
        //结束时间
        public string _EndTime = "23:59";
        public string EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                Set("EndTime", ref _EndTime, value);
            }
        }
        //开始日期
        public System.DateTime _StartDate = DateTime.Now;
        public System.DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                Set("StartDate", ref _StartDate, value);
            }
        }
        //结束日期
        public System.DateTime _EndDate = DateTime.Now;
        public System.DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                Set("EndDate", ref _EndDate, value);
            }
        }

        public DishGivingModel SaveDishDetail(DishBeanUtil dish)
        {
            this.Code = dish.Code;
            this.DishName = dish.DishName;
            this.DishFormat = dish.DishFormat;
            this.DishUnitName = dish.DishUnitName;
            return this;
        }

        public DishGivingModel SaveGivingDishDetail(DishBeanUtil givingDish)
        {
            this.Code_Giving = givingDish.Code;
            this.DishName_Giving = givingDish.DishName;
            this.DishFormat_Giving = givingDish.DishFormat;
            this.DishUnitName_Giving = givingDish.DishUnitName;
            return this;
        }
    }
}
