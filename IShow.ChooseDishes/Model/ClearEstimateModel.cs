using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public partial class ClearEstimateModel : ViewModelBase
    {
        int _Id;//id
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
        int _DishCode;//品码
        public int DishCode
        {
            get
            {
                return _DishCode;
            }
            set
            {
                Set("DishCode", ref _DishCode, value);
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
        int _Num = 0;//估清数量
        public int Num
        {
            get
            {
                return _Num;
            }
            set
            {
                Set("Num", ref _Num, value);
            }
        }
        int _WarnNum = 0;//提醒数量
        public int WarnNum
        {
            get
            {
                return _WarnNum;
            }
            set
            {
                Set("WarnNum", ref _WarnNum, value);
            }
        }
        int _SaleNum = 0;//已售数量
        public int SaleNum
        {
            get
            {
                return _SaleNum;
            }
            set
            {
                Set("SaleNum", ref _SaleNum, value);
            }
        }
        int _LastNum = 0;//剩余数量
        public int LastNum
        {
            get
            {
                return _LastNum;
            }
            set
            {
                Set("LastNum", ref _LastNum, value);
            }
        }
        System.DateTime _StartTime = DateTime.Now;//估清开始时间
        public System.DateTime StartTime
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
        string _Operator = "system";//估清人
        public string Operator
        {
            get
            {
                return _Operator;
            }
            set
            {
                Set("Operator", ref _Operator, value);
            }
        }
        System.DateTime _EndTime = DateTime.Now;//估清结束时间
        public System.DateTime EndTime
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
        string _CancleMan;//取消人
        public string CancleMan
        {
            get
            {
                return _CancleMan;
            }
            set
            {
                Set("CancleMan", ref _CancleMan, value);
            }
        }
        Nullable<System.DateTime> _CancleTime = DateTime.Now;//取消时间
        public Nullable<System.DateTime> CancleTime
        {
            get
            {
                return _CancleTime;
            }
            set
            {
                Set("CancleTime", ref _CancleTime, value);
            }
        }
        int _MidwayCancle;//中途取消
        public int MidwayCancle
        {
            get
            {
                return _MidwayCancle;
            }
            set
            {
                Set("MidwayCancle", ref _MidwayCancle, value);
            }
        }
        string _Reason = "估清原因";//取消原因
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                Set("Reason", ref _Reason, value);
            }
        }
        System.DateTime _MarkTime = DateTime.Now;
        public System.DateTime MarkTime
        {
            get
            {
                return _MarkTime;
            }
            set
            {
                Set("MarkTime", ref _MarkTime, value);
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
        System.DateTime _CreateDatetime = DateTime.Now;
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
        Nullable<System.DateTime> _UpdateDatetime = DateTime.Now;
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

        public ClearEstimateModel SaveDishDetail(DishBeanUtil dish)
        {
            this.DishCode = int.Parse(dish.Code);
            this.DishName = dish.DishName;
            this.DishFormat = dish.DishFormat;
            this.DishUnitName = dish.DishUnitName;
            return this;
        }

        //public ClearEstimateModel CreateClearEstimateDish()
        //{
        //    return this;
        //}
        public ClearEstimateModel CreateClearEstimateDishModel(ClearEstimate CE)
        {
            this.Id = CE.Id;
            this.DishCode = CE.DishCode;
            this.Num = CE.Num;
            this.LastNum = CE.LastNum;
            this.SaleNum = CE.SaleNum;
            this.WarnNum = CE.WarnNum;
            this.StartTime = CE.StartTime;
            this.Operator = CE.Operator;
            this.EndTime = CE.EndTime;
            this.CancleTime = CE.CancleTime;
            this.CancleMan = CE.CancleMan;
            this.MidwayCancle = CE.MidwayCancle;
            this.Reason = CE.Reason;
            this.MarkTime = CE.MarkTime;
            this.Status = CE.Status;
            this.CreateDatetime = CE.CreateDatetime;
            this.CreateBy = CE.CreateBy;
            this.Deleted = CE.Deleted;
            this.UpdateDatetime = CE.UpdateDatetime;
            this.UpdateBy = CE.UpdateBy;
            return this;
        }

        public ClearEstimate CreateClearEstimateDish(ClearEstimateModel model)
        {
            ClearEstimate clearEstimate = new ClearEstimate();
            clearEstimate.Id = model.Id;
            clearEstimate.DishCode = model.DishCode;
            clearEstimate.Num = model.Num;
            clearEstimate.LastNum = model.LastNum;
            clearEstimate.SaleNum = model.SaleNum;
            clearEstimate.WarnNum = model.WarnNum;
            clearEstimate.StartTime = model.StartTime;
            clearEstimate.Operator = model.Operator;
            clearEstimate.EndTime = model.EndTime;
            clearEstimate.CancleTime = model.CancleTime;
            clearEstimate.CancleMan = model.CancleMan;
            clearEstimate.MidwayCancle = model.MidwayCancle;
            clearEstimate.Reason = model.Reason;
            clearEstimate.MarkTime = model.MarkTime;
            clearEstimate.Status = model.Status;
            clearEstimate.CreateDatetime = model.CreateDatetime;
            clearEstimate.CreateBy = model.CreateBy;
            clearEstimate.Deleted = model.Deleted;
            clearEstimate.UpdateDatetime = model.UpdateDatetime;
            clearEstimate.UpdateBy = model.UpdateBy;
            return clearEstimate;
        }

        public ClearEstimate CreateClearEstimateDishObject(ClearEstimateModel model)
        {
            ClearEstimate clearEstimateDish = CreateClearEstimateDish(model);
            clearEstimateDish.Status = 1;
            clearEstimateDish.CreateBy = SubjectUtils.GetAuthenticationId();
            clearEstimateDish.CreateDatetime = DateTime.Now;

            return clearEstimateDish;
        }
    }
}
