using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    [DataContract(Namespace = "www.IShow.com", IsReference = true)]
    public class DishesWayBean : ObservableObject
    {

        string _CurrentScaleText;
        public string CurrentScaleText   //显示当前位置和总体
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
        public int LineNumber   //行号
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
        int _DischesWayId;
        public int DischesWayId    //做法id
        {
            get
            {
                return _DischesWayId;
            }
            set
            {
                Set("DischesWayId", ref _DischesWayId, value);
            }
        }

        int _DischesWayNameId;
        public int DischesWayNameId    //做法类型id
        {
            get
            {
                return _DischesWayNameId;
            }
            set
            {
                Set("DischesWayNameId", ref _DischesWayNameId, value);
            }
        }
        string _DischesWayName;
        public string DischesWayName    //做法类型显示
        {
            get
            {
                return _DischesWayName;
            }
            set
            {
                Set("DischesWayName", ref _DischesWayName, value);
            }
        }


        string _Code;
        public string Code    //做法编码显示
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
        public string Name    //做法名称
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

        string _WayDetail;
        public string WayDetail   //做法说明
        {
            get
            {
                return _WayDetail;
            }
            set
            {
                Set("WayDetail", ref _WayDetail, value);
            }
        }

        string _PingYing="-";
        public string PingYing  //拼音
        {
            get
            {
                return _PingYing;
            }
            set
            {
                Set("PingYing", ref _PingYing, value);
            }
        }

        double _AddPrice;
        public double AddPrice    //加价
        {
            get
            {
                return _AddPrice;
            }
            set
            {
                Set("AddPrice", ref _AddPrice, value);
            }
        }

        int _AddPriceByNum;
        public int AddPriceByNum   //是否根据数量加价
        {
            get
            {
                return _AddPriceByNum;
            }
            set
            {
                
                Set("AddPriceByNum", ref _AddPriceByNum, value);
            }
        }
        bool _addPriceByNum;
        public bool addPriceByNum   //是否根据数量加价
        {
            get
            {
                return _addPriceByNum;
            }
            set
            {
                if (value == true)
                {
                    AddPriceByNum = 1;
                }
                else
                {
                    AddPriceByNum = 0;
                }
                Set("addPriceByNum", ref _addPriceByNum, value);
            }
        }

        System.DateTime _CreateDatetime;
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
        public int Deleted    //是否删除
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
        public int Status   //状态
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
        bool _IsReadOnlyCode;
        public bool IsReadOnlyCode
        {
            get
            {
                return _IsReadOnlyCode;
            }
            set
            {
                Set("IsReadOnlyCode", ref _IsReadOnlyCode, value);
            }
        }
        


        public DishesWayBean CreateDishesWayBean(DischesWay bean)
        {
           
            this.DischesWayId = bean.DischesWayId;
            this.DischesWayNameId = bean.DischesWayNameId;
            this.Code = bean.Code;
            this.Name = bean.Name;
            this.WayDetail = bean.WayDetail;
            this.PingYing = bean.PingYing;
            this.AddPrice = bean.AddPrice;
            this.AddPriceByNum = bean.AddPriceByNum;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;

            if (bean.AddPriceByNum == 0)
            {
                this.addPriceByNum = false;
            }
            else
            {
                this.addPriceByNum = true;
            }
            return this;

        }
        public DishesWayBean CreateDishesWayBean(DishesWayBean bean)
        {
            this.DischesWayId = bean.DischesWayId;
            this.DischesWayNameId = bean.DischesWayNameId;
            this.DischesWayName = bean.DischesWayName;
            this.LineNumber = bean.LineNumber;
            this.CurrentScaleText = bean.CurrentScaleText;
            this.Code = bean.Code;
            this.Name = bean.Name;
            this.WayDetail = bean.WayDetail;
            this.PingYing = bean.PingYing;
            this.AddPrice = bean.AddPrice;
            this.AddPriceByNum = bean.AddPriceByNum;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            this.addPriceByNum = bean.addPriceByNum;
            return this;

        }

        public DischesWay CreateDishesWay(DishesWayBean bean)
        {
            DischesWay beanBack = new DischesWay();
            beanBack.DischesWayId = bean.DischesWayId;
            beanBack.DischesWayNameId = bean.DischesWayNameId;
            beanBack.Code = bean.Code;
            beanBack.Name = bean.Name;
            beanBack.WayDetail = bean.WayDetail;
            beanBack.PingYing = bean.PingYing;
            beanBack.AddPrice = bean.AddPrice;
            beanBack.AddPriceByNum = bean.AddPriceByNum;
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
