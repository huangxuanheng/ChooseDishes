using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class PromotionsDishBean : ObservableObject, IEditableObject
    {

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
        //TradeNo
        public string _TradeNo;
        public string TradeNo
        {
            get
            {
                return _TradeNo;
            }
            set
            {
                Set("TradeNo", ref _TradeNo, value);
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
                IsModify = true;
                Set("DishId", ref _DishId, value);
            }
        }

        public int _MarketTypeId;
        public int MarketTypeId
        {
            get
            {
                return _MarketTypeId;
            }
            set
            {
                IsModify = true;
                Set("MarketTypeId", ref _MarketTypeId, value);
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

        public double _Price;
        public double Price
        {
            get
            {
                return _Price;
            }
            set
            {
                IsModify = true;
                Set("Price", ref _Price, value);
            }
        }

        public string _StartTime= "00:00";
        public string StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                IsModify = true;
                Set("StartTime", ref _StartTime, value);
            }
        }

        public string  _EndTime = "23:59";
        public string EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                IsModify = true;
                Set("EndTime", ref _EndTime, value);
            }
        }

        public System.DateTime _StartDate = DateTime.Now ;
        public System.DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                IsModify = true;
                Set("StartDate", ref _StartDate, value);
            }
        }

        public System.DateTime _EndDate = DateTime.Now;
        public System.DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                IsModify = true;
                Set("EndDate", ref _EndDate, value);
            }
        }

        public int _Week_1=1;
        public int Week_1
        {
            get
            {
                return _Week_1;
            }
            set
            {
                IsModify = true;
                Set("Week_1", ref _Week_1, value);
            }
        }

        public int _Week_2=1;
        public int Week_2
        {
            get
            {
                return _Week_2;
            }
            set
            {
                IsModify = true;
                Set("Week_2", ref _Week_2, value);
            }
        }

        public int _Week_3=1;
        public int Week_3
        {
            get
            {
                return _Week_3;
            }
            set
            {
                IsModify = true;
                Set("Week_3", ref _Week_3, value);
            }
        }

        public int _Week_4=1;
        public int Week_4
        {
            get
            {
                return _Week_4;
            }
            set
            {
                IsModify = true;
                Set("Week_4", ref _Week_4, value);
            }
        }

        public int _Week_5=1;
        public int Week_5
        {
            get
            {
                return _Week_5;
            }
            set
            {
                IsModify = true;
                Set("Week_5", ref _Week_5, value);
            }
        }

        public int _Week_6=1;
        public int Week_6
        {
            get
            {
                return _Week_6;
            }
            set
            {
                IsModify = true;
                Set("Week_6", ref _Week_6, value);
            }
        }

        public int _Week_0=1;
        public int Week_0
        {
            get
            {
                return _Week_0;
            }
            set
            {
                IsModify = true;
                Set("Week_0", ref _Week_0, value);
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

        public int _Usering;
        public int Usering
        {
            get
            {
                return _Usering;
            }
            set
            {
                IsModify = true;
                Set("Usering", ref _Usering, value);
            }
        }

        public System.DateTime _CreateDatetime = DateTime.Now;
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
        public String _CreateDatetimeString = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        public String CreateDatetimeString
        {
            get
            {
                return _CreateDatetimeString;
            }
            set
            {
                Set("CreateDatetimeString", ref _CreateDatetimeString, value);
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

        public  Dish Dish;


        public  ICollection<PromotionsDishDetail> PromotionsDishDetail =new HashSet<PromotionsDishDetail>();

        //菜品名字 DishName
        public string _DishName;
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
        //菜品编号
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
        //状态名称
        string _StatusName;
        public string StatusName
        {
            get
            {
                _StatusName = Status == 1 ? "未审核" : Status == 2 ? "已审核" : "已作废";
                return _StatusName;
            }
            set
            {
                Set("StatusName", ref _StatusName, value);
            }
        }
        //是否停用 UseingStatus
        string _UseingStatus;
        public string UseingStatus
        {
            get
            {
                _UseingStatus = Usering == 0 ? "启用" : "停用";
                return _UseingStatus;
            }
            set
            {
                Set("UseingStatus", ref _UseingStatus, value);
            }
        }
        //市别名称
        string _MarketTypeName;
        public string MarketTypeName
        {
            get
            {
                return _MarketTypeName;
            }
            set
            {
                Set("MarketTypeName", ref _MarketTypeName, value);
            }
        }

        public static string TimeToString(DateTime time) {
            return time.Hour + ":" + time.Minute;
        }
        public static DateTime StringToTime(string value)
        {
            
            string[] s = value.Split(':');
            DateTime dateTime = DateTime.Now;
            return dateTime;
        }


        public PromotionsDishBean CreatePromotionsDishBean(PromotionsDish bean)
        {
            this.PromotionsDishId = bean.PromotionsDishId;
            this.TradeNo = bean.TradeNo;
            this.DishId = bean.DishId??0;
            this.MarketTypeId = bean.MarketTypeId;
            this.DishFormat = bean.DishFormat;
            this.Price = bean.Price;
            this.StartTime = bean.StartTime;
            this.EndTime = bean.EndTime;
            this.StartDate = bean.StartDate;
            this.EndDate = bean.EndDate;
            this.Week_1 = bean.Week_1;
            this.Week_2 = bean.Week_2;
            this.Week_3 = bean.Week_3;
            this.Week_4 = bean.Week_4;
            this.Week_5 = bean.Week_5;
            this.Week_6 = bean.Week_6;
            this.Week_0 = bean.Week_0;
            this.Status = bean.Status;
            this.Usering = bean.Usering;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            this.Dish = bean.Dish;
            this.PromotionsDishDetail = bean.PromotionsDishDetail;
            return this;

        }
        public PromotionsDish CreatePromotionsDish(PromotionsDishBean bean)
        {
            PromotionsDish beanBack = new PromotionsDish();
            beanBack.PromotionsDishId = bean.PromotionsDishId;
            beanBack.TradeNo = bean.TradeNo;
            beanBack.DishId = bean.DishId;
            beanBack.MarketTypeId = bean.MarketTypeId;
            beanBack.DishFormat = bean.DishFormat;
            beanBack.Price = bean.Price;
            beanBack.StartTime = bean.StartTime;
            beanBack.EndTime = bean.EndTime;
            beanBack.StartDate = bean.StartDate;
            beanBack.EndDate = bean.EndDate;
            beanBack.Week_1 = bean.Week_1;
            beanBack.Week_2 = bean.Week_2;
            beanBack.Week_3 = bean.Week_3;
            beanBack.Week_4 = bean.Week_4;
            beanBack.Week_5 = bean.Week_5;
            beanBack.Week_6 = bean.Week_6;
            beanBack.Week_0 = bean.Week_0;
            beanBack.Status = bean.Status;
            beanBack.Usering = bean.Usering;
            beanBack.CreateDatetime = bean.CreateDatetime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.Deleted = bean.Deleted;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            beanBack.Dish = bean.Dish;
            beanBack.PromotionsDishDetail = bean.PromotionsDishDetail;
            return beanBack;

        }
        public  PromotionsDish CreatePromotionsDishObject(PromotionsDishDetailBean[] promotionsDishDetailBean)
        {
            PromotionsDish beanBack = CreatePromotionsDish(this);
            beanBack.Status = 1;
            beanBack.PromotionsDishDetail.Clear();
            if (promotionsDishDetailBean != null && promotionsDishDetailBean.Length > 0) {
                foreach (var element in promotionsDishDetailBean) {
                    element.CreateBy = SubjectUtils.GetAuthenticationId();
                    element.CreateDatetime = DateTime.Now;
                    element.Status = 1;
                    beanBack.PromotionsDishDetail.Add(element.CreatePromotionsDishDetail(element));
                }
            }

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
