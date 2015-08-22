using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using IShow.Common.Log;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.Model
{
    [DataContract(Namespace = "www.IShow.com", IsReference = true)]
    public class MarketTypeBean : ObservableObject
    {
        string _CurrentScaleText;
        public string CurrentScaleText
        {
            get
            {
                return _CurrentScaleText;
            }
            set
            {
                Set("CurrentScaleText", ref _CurrentScaleText, value);
            }
        }
        int _LineNumber;
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
        int _Id;
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

        string _Name;
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
        System.DateTime _StartTime;
        public System.DateTime StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                ShowStartTime = value.ToShortTimeString();
                Set("StartTime", ref _StartTime, value);
            }
        }
        string _ShowStartTime;
        public string ShowStartTime
        {
            get
            {
                return _ShowStartTime;
            }
            set
            {
                Set("ShowStartTime", ref _ShowStartTime, value);
            }
        }
        System.DateTime _CreateDatetime=DateTime.Now;
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
        int _CreateBy=SubjectUtils.GetAuthenticationId();
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
        Nullable<System.DateTime> _UpdateDatetime;
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

        public MarketTypeBean CreateMarketTypeBean(MarketType bean)
        {
            this.Id = bean.Id;
            this.Name = bean.Name;
            this.StartTime = bean.StartTime;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;
        }
        public MarketTypeBean CreateMarketTypeBean(MarketTypeBean bean)
        {
            MarketTypeBean mt = new MarketTypeBean();
            mt.Id = bean.Id;
            mt.Code = bean.Code;
            mt.Name = bean.Name;
            mt.StartTime = bean.StartTime;
            mt.CreateDatetime = bean.CreateDatetime;
            mt.CreateBy = bean.CreateBy;
            mt.Deleted = bean.Deleted;
            mt.Status = bean.Status;
            mt.UpdateDatetime = bean.UpdateDatetime;
            mt.UpdateBy = bean.UpdateBy;
            return mt;
        }
        public MarketType CreateMarketType(MarketTypeBean bean)
        {
            MarketType beanBack = new MarketType();
            beanBack.Id = bean.Id;
            beanBack.Name = bean.Name;
            beanBack.StartTime = Convert.ToDateTime(bean.ShowStartTime);
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
