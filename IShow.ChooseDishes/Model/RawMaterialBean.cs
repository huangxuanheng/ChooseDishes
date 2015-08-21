using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    [DataContract(Namespace = "www.IShow.com", IsReference = true)]
    public class RawMaterialBean : ObservableObject
    {

        int _LineNumber;
        public int LineNumber     //原料编号
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
        string _CurrentScale;
        public string CurrentScale     //当前记录即总数
        {
            get
            {
                return _CurrentScale;
            }
            set
            {
                Set("CurrentScale", ref _CurrentScale, value);
            }
        }
        
        int _Id;
        public int Id     //原料编号
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
        public string Code     //原料编号
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
        Nullable<int> _RawId;
        public Nullable<int> RawId     //原料类型编号
        {
            get
            {
                return _RawId;
            }
            set
            {
                Set("RawId", ref _RawId, value);
            }
        }

        string _MaterialName;
        public string MaterialName      //原料名称
        {
            get
            {
                return _MaterialName;
            }
            set
            {
                Set("MaterialName", ref _MaterialName, value);
                DispatcherHelper.CheckBeginInvokeOnUI(
                () =>
                {
                    base.RaisePropertyChanged("MaterialName");
                });
            }
        }

        string _Format;
        public string Format    //规格
        {
            get
            {
                return _Format;
            }
            set
            {
                Set("Format", ref _Format, value);
            }
        }
        string _BigType;
        public string BigType    //所属大类
        {
            get
            {
                return _BigType;
            }
            set
            {
                Set("BigType", ref _BigType, value);
            }
        }
        string _LittleType;
        public string LittleType    //所属小类
        {
            get
            {
                return _LittleType;
            }
            set
            {
                Set("LittleType", ref _LittleType, value);
            }
        }
        

        string _Pinying;
        public string Pinying    //拼音简码
        {
            get
            {
                return _Pinying;
            }
            set
            {
                Set("Pinying", ref _Pinying, value);
            }
        }

        int _InGoodsUnit;
        public int InGoodsUnit   //进货单位
        {
            get
            {
                return _InGoodsUnit;
            }
            set
            {
                
                Set("InGoodsUnit", ref _InGoodsUnit, value);
            }
        }

        int _StockUnit;
        public int StockUnit   //库存单位
        {
            get
            {
                return _StockUnit;
            }
            set
            {

               
                Set("StockUnit", ref _StockUnit, value);
            }
        }

        int _InGoodsStock=1;
        public int InGoodsStock     //进货单位与库存单位换算比
        {
            get
            {
                return _InGoodsStock;
            }
            set
            {
                Set("InGoodsStock", ref _InGoodsStock, value);
            }
        }

        int _FormulaUnit;
        public int FormulaUnit    //配方单位
        {
            get
            {
                return _FormulaUnit;
            }
            set
            {
                Set("FormulaUnit", ref _FormulaUnit, value);
            }
        }

        int _StockFormula=1;
        public int StockFormula    //库存单位与配方单位换算比
        {
            get
            {
                return _StockFormula;
            }
            set
            {
                Set("StockFormula", ref _StockFormula, value);
            }
        }

        double _InGoodsPrice;
        public double InGoodsPrice    //建议采购价
        {
            get
            {
                return _InGoodsPrice;
            }
            set
            {
                Set("InGoodsPrice", ref _InGoodsPrice, value);
            }
        }

        int _StockMax;
        public int StockMax    //库存上限
        {
            get
            {
                return _StockMax;
            }
            set
            {
                Set("StockMax", ref _StockMax, value);
            }
        }

        int _StockMin;
        public int StockMin   //库存下限
        {
            get
            {
                return _StockMin;
            }
            set
            {
                Set("StockMin", ref _StockMin, value);
            }
        }
        
        bool _WriteDown;
        public bool WriteDown    //自动减库存
        {
            get
            {
                return _WriteDown;
            }
            set
            {
                Set("WriteDown", ref _WriteDown, value);
            }
        }
        int _WriteDowns;
        public int WriteDowns    //是否销售冲减库存
        {
            get
            {
                return _WriteDowns;
            }
            set
            {
                if (value != 0)
                {
                    this.WriteDown = true;
                }
                Set("WriteDowns", ref _WriteDowns, value);
            }
        }
        bool _orderRawAdd;
        public bool orderRawAdd   //点菜是否加料界面显示
        {
            get
            {
                return _orderRawAdd;
            }
            set
            {
                if (value)
                {
                    _OrderRawAdd = 1;
                }
                else
                {
                    _OrderRawAdd = 0;
                }
                Set("orderRawAdd", ref _orderRawAdd, value);
            }
        }

        int _OrderRawAdd;
        public int OrderRawAdd   //点菜是否加料
        {
            get
            {
                return _OrderRawAdd;
            }
            set
            {
                if (value != 0)
                {
                    this.orderRawAdd = true;
                }
                else
                {
                    this.orderRawAdd = false;
                }
                Set("OrderRawAdd", ref _OrderRawAdd, value);
            }
        }
        Nullable<double> _RawAddPrice;
        public Nullable<double> RawAddPrice   //加料加价
        {
            get
            {
                return _RawAddPrice;
            }
            set
            {
                Set("RawAddPrice", ref _RawAddPrice, value);
            }
        }

        Nullable<int> _SaleUnit;
        public Nullable<int> SaleUnit    //销售单位
        {
            get
            {
                return _SaleUnit;
            }
            set
            {
                Set("SaleUnit", ref _SaleUnit, value);
            }
        }

        int _IsWeight;
        public int IsWeight   //是否称重
        {
            get
            {
                return _IsWeight;
            }
            set
            {
                if (value == 0)
                {
                    _isWeight = false;
                }
                else
                {
                    _isWeight = true;
                }
                Set("IsWeight", ref _IsWeight, value);
            }
        }
        bool _isWeight;
        public bool isWeight   //是否称重
        {
            get
            {
                return _isWeight;
            }
            set
            {
                if (value)
                {
                    _IsWeight = 1;
                }
                else
                {
                    _IsWeight = 0;
                }
                Set("isWeight", ref _isWeight, value);
            }
        }

        int _CheckDay;
        public int CheckDay   //是否每日盘点
        {
            get
            {
                return _CheckDay;
            }
            set
            {
                if (value == 0)
                {
                    _checkDay = false;
                }
                else
                {
                    _checkDay = true;
                }
                Set("CheckDay", ref _CheckDay, value);
            }
        }

        bool _checkDay;
        public bool checkDay   //是否每日盘点
        {
            get
            {
                return _checkDay;
            }
            set
            {
                if (value)
                {
                    _CheckDay = 1;
                }
                else
                {
                    _CheckDay = 0;
                }
                Set("checkDay", ref _checkDay, value);
            }
        }

        string _Detail;
        public string Detail   //备注
        {
            get
            {
                return _Detail;
            }
            set
            {
                Set("Detail", ref _Detail, value);
            }
        }

        System.DateTime _CreateDatetime;
        public System.DateTime CreateDatetime   //创建时间
        {
            get
            {
                return _CreateDatetime;
            }
            set
            {
                if (value == null)
                {
                    value = DateTime.Now;
                }
                Set("CreateDatetime", ref _CreateDatetime, value);
            }
        }

        int _CreateBy;
        public int CreateBy    //创建人id
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
        public int Deleted   //是否删除
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

        bool _status;
        public bool status   //状态显示
        {
            get
            {
                return _status;
            }
            set
            {
                if (value)
                {
                    _Status = 1;
                }
                else
                {
                    _Status = 0;
                }
                Set("status", ref _status, value);
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
                if (value != 0)   //表示停用
                {
                    this.status = true;
                }
                else
                {
                    this.status = false;
                }
                Set("Status", ref _Status, value);
            }
        }
        Nullable<System.DateTime> _UpdateDatetime;
        public Nullable<System.DateTime> UpdateDatetime   //修改时间
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
        public Nullable<int> UpdateBy   //修改人  
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

        List<RawUnit> _InGoodsUnitItems;
        //进货单位
        public List<RawUnit> InGoodsUnitItems
        {
            get
            {
                return _InGoodsUnitItems ?? (_InGoodsUnitItems = new List<RawUnit>());
            }
            set
            {
                this._InGoodsUnitItems = value;
                Set("InGoodsUnitItems", ref _InGoodsUnitItems, value);
            }
        }
        List<RawUnit> _StockUnitItems;
        //库存单位
        public List<RawUnit> StockUnitItems
        {
            get
            {
                return _StockUnitItems ?? (_StockUnitItems = new List<RawUnit>());
            }
            set
            {
                this._StockUnitItems = value;
                Set("StockUnitItems", ref _StockUnitItems, value);
            }
        }

        List<RawUnit> _FormulaUnitItems;
        //配方单位
        public List<RawUnit> FormulaUnitItems
        {
            get
            {
                return _FormulaUnitItems ?? (_FormulaUnitItems = new List<RawUnit>());
            }
            set
            {
                this._FormulaUnitItems = value;
                Set("FormulaUnitItems", ref _FormulaUnitItems, value);
            }
        }
        List<RawUnit> _SaleUnitItems;
        //销售单位
        public List<RawUnit> SaleUnitItems
        {
            get
            {
                return _SaleUnitItems ?? (_SaleUnitItems = new List<RawUnit>());
            }
            set
            {
                this._SaleUnitItems = value;
                Set("SaleUnitItems", ref _SaleUnitItems, value);
            }
        }

        RawUnit _SelectedSaleUnitItem;
        //销售单位被选中的字段
        public RawUnit SelectedSaleUnitItem
        {
            get
            {
                return _SelectedSaleUnitItem;
            }
            set
            {
                SaleUnit = value.UnitId;
                Set("SelectedSaleUnitItem", ref _SelectedSaleUnitItem, value);
            }
        }
        RawUnit _SelectedInGoodsUnitItem;
        //进货单位被选中的字段
        public RawUnit SelectedInGoodsUnitItem
        {
            get
            {
                return _SelectedInGoodsUnitItem;
            }
            set
            {
                InGoodsUnit = value.UnitId;
                Set("SelectedInGoodsUnitItem", ref _SelectedInGoodsUnitItem, value);
            }
        }
        RawUnit _SelectedStockUnitItem;
        //库存单位被选中的字段
        public RawUnit SelectedStockUnitItem
        {
            get
            {
                return _SelectedStockUnitItem;
            }
            set
            {
                StockUnit = value.UnitId;
                Set("SelectedStockUnitItem", ref _SelectedStockUnitItem, value);
            }
        }
        RawUnit _SelectedFormulaUnitItem;
        //配方单位被选中的字段
        public RawUnit SelectedFormulaUnitItem
        {
            get
            {
                return _SelectedFormulaUnitItem;
            }
            set
            {
                FormulaUnit = value.UnitId;
                Set("SelectedFormulaUnitItem", ref _SelectedFormulaUnitItem, value);
            }
        }
        /**根据原料资料对象RawMaterial创建RawMaterialBean对象*/
        public RawMaterialBean CreateRawMaterialBean(RawMaterial bean)   
        {
            this.Id = bean.Id;
            this.RawId = bean.RawId;
            this.MaterialName = bean.MaterialName;
            this.Format = bean.Format;
            this.Pinying = bean.Pinying;
            this.InGoodsUnit = bean.InGoodsUnit;
            this.StockUnit = bean.StockUnit;
            this.InGoodsStock = bean.InGoodsStock;
            this.FormulaUnit = bean.FormulaUnit;
            this.StockFormula = bean.StockFormula;
            this.InGoodsPrice = bean.InGoodsPrice;
            this.StockMax = bean.StockMax;
            this.StockMin = bean.StockMin;
            this.WriteDowns = bean.WriteDowns;
            this.OrderRawAdd = bean.OrderRawAdd;
            this.RawAddPrice = bean.RawAddPrice;
            this.SaleUnit = bean.SaleUnit;
            this.IsWeight = bean.IsWeight;
            this.CheckDay = bean.CheckDay;
            this.Detail = bean.Detail;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;

        }
        /**根据RawMaterialBean创建原料资料对象RawMaterial*/
        public RawMaterial CreateRawMaterial(RawMaterialBean bean)
        {
            RawMaterial beanBack = new RawMaterial();
            beanBack.Id = bean.Id;
            beanBack.RawId = bean.RawId;
            beanBack.MaterialName = bean.MaterialName;
            beanBack.Format = bean.Format;
            beanBack.Pinying = bean.Pinying;
            beanBack.InGoodsUnit = bean.InGoodsUnit;
            beanBack.StockUnit = bean.StockUnit;
            beanBack.InGoodsStock = bean.InGoodsStock;
            beanBack.FormulaUnit = bean.FormulaUnit;
            beanBack.StockFormula = bean.StockFormula;
            beanBack.InGoodsPrice = bean.InGoodsPrice;
            beanBack.StockMax = bean.StockMax;
            beanBack.StockMin = bean.StockMin;
            beanBack.WriteDowns = bean.WriteDowns;
            beanBack.OrderRawAdd = bean.OrderRawAdd;
            beanBack.RawAddPrice = bean.RawAddPrice;
            beanBack.SaleUnit = bean.SaleUnit;
            beanBack.IsWeight = bean.IsWeight;
            beanBack.CheckDay = bean.CheckDay;
            beanBack.Detail = bean.Detail;
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
