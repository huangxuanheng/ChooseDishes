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
    public class DishBean : BeanBasis, IEditableObject
    {
        
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
        int _LineNumber1;
        public int LineNumber1
        {
            get
            {
                return _LineNumber1;
            }
            set
            {
                Set("LineNumber1", ref _LineNumber1, value);
            }
        }
        int _DishTypeId;
        public int DishTypeId
        {
            get
            {
                return _DishTypeId;
            }
            set
            {
                Set("DishTypeId", ref _DishTypeId, value);
            }
        }

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
        //DishFinanceId
        int? _DishFinanceId;
        public int? DishFinanceId
        {
            get
            {
                return _DishFinanceId;
            }
            set
            {
                Set("DishFinanceId", ref _DishFinanceId, value);
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
        //PingYing
        string _PingYing;
        public string PingYing
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
        //AidNumber
        string _AidNumber;
        public string AidNumber
        {
            get
            {
                return _AidNumber;
            }
            set
            {
                Set("AidNumber", ref _AidNumber, value);
            }
        }
        //EnglishName
        string _EnglishName;
        public string EnglishName
        {
            get
            {
                return _EnglishName;
            }
            set
            {
                Set("EnglishName", ref _EnglishName, value);
            }
        }
        //DishFormat
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
        //WeightConfirm
        int _WeightConfirm;
        public int WeightConfirm
        {
            get
            {
                return _WeightConfirm;
            }
            set
            {
                Set("WeightConfirm", ref _WeightConfirm, value);
            }
        }
        //LowConsumerConfirm
        int _LowConsumerConfirm =1;
        public int LowConsumerConfirm
        {
            get
            {
                return _LowConsumerConfirm;
            }
            set
            {
                Set("LowConsumerConfirm", ref _LowConsumerConfirm, value);
            }
        }
        //ServerfreeConsumer
        int _ServerfreeConsumer = 1 ;
        public int ServerfreeConsumer
        {
            get
            {
                return _ServerfreeConsumer;
            }
            set
            {
                Set("ServerfreeConsumer", ref _ServerfreeConsumer, value);
            }
        }
        //SanpConfirm
        int _SanpConfirm;
        public int SanpConfirm
        {
            get
            {
                return _SanpConfirm;
            }
            set
            {
                Set("SanpConfirm", ref _SanpConfirm, value);
            }
        }
        //IsStop
        int _IsStop;
        public int IsStop
        {
            get
            {
                return _IsStop;
            }
            set
            {
                Set("IsStop", ref _IsStop, value);
            }
        }
        //DiscountConfirm
        int _DiscountConfirm = 1 ;
        public int DiscountConfirm
        {
            get
            {
                return _DiscountConfirm;
            }
            set
            {
                Set("DiscountConfirm", ref _DiscountConfirm, value);
            }
        }
        //PriceTimeConfirm
        int _PriceTimeConfirm;
        public int PriceTimeConfirm
        {
            get
            {
                return _PriceTimeConfirm;
            }
            set
            {
                Set("PriceTimeConfirm", ref _PriceTimeConfirm, value);
            }
        }
        //PackagesConfirm
        int _PackagesConfirm;
        public int PackagesConfirm
        {
            get
            {
                return _PackagesConfirm;
            }
            set
            {
                Set("PackagesConfirm", ref _PackagesConfirm, value);
            }
        }
        //PosConfirm
        int _PosConfirm = 0;
        public int PosConfirm
        {
            get
            {
                return _PosConfirm;
            }
            set
            {
                Set("PosConfirm", ref _PosConfirm, value);
            }
        }
        //FoodFight
        int _FoodFight;
        public int FoodFight
        {
            get
            {
                return _FoodFight;
            }
            set
            {
                Set("FoodFight", ref _FoodFight, value);
            }
        }
        //LineConfirm
        int _LineConfirm;
        public int LineConfirm
        {
            get
            {
                return _LineConfirm;
            }
            set
            {
                Set("LineConfirm", ref _LineConfirm, value);
            }
        }
        //DischesType
        int _DischesType = 1 ;
        public int DischesType
        {
            get
            {
                return _DischesType;
            }
            set
            {
                Set("DischesType", ref _DischesType, value);
            }
        }
        //Detail
        string _Detail;
        public string Detail
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
        //Img
        string _Img;
        public string Img
        {
            get
            {
                return _Img;
            }
            set
            {
                Set("Img", ref _Img, value);
            }
        }
        //KitchenType
        int? _KitchenType;
        public int? KitchenType
        {
            get
            {
                return _KitchenType;
            }
            set
            {
                Set("KitchenType", ref _KitchenType, value);
            }
        }
        //PublisherType
        int? _PublisherType;
        public int? PublisherType
        {
            get
            {
                return _PublisherType;
            }
            set
            {
                Set("PublisherType", ref _PublisherType, value);
            }
        }
        //WeihtConfirm
        int _WeihtConfirm;
        public int WeihtConfirm
        {
            get
            {
                return _WeihtConfirm;
            }
            set
            {
                Set("WeihtConfirm", ref _WeihtConfirm, value);
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
        //菜品大类名字
        public String _DishTypeBigName;
        public String DishTypeBigName
        {
            get
            {
                return _DishTypeBigName;
            }
            set
            {
                Set("DishTypeBigName", ref _DishTypeBigName, value);
            }
        }  
        //菜品小类名字
        public String _DishTypeName;
        public String DishTypeName
        {
            get
            {
                return _DishTypeName;
            }
            set
            {
                Set("DishTypeName", ref _DishTypeName, value);
            }
        }
        //选择 菜牌时候 勾选的菜品 IsSelectedMenus
        public bool _IsSelectedMenus;
        public bool IsSelectedMenus
        {
            get
            {
                return _IsSelectedMenus;
            }
            set
            {
                Set("IsSelectedMenus", ref _IsSelectedMenus, value);
            }
        }
        //菜牌名字
        public string _DishMenusName;
        public string DishMenusName
        {
            get
            {
                return _DishMenusName;
            }
            set
            {
                Set("DishMenusName", ref _DishMenusName, value);
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

        public  ICollection<DishPrice> DishPrice { get; set; }
        public  DishUnit DishUnit { get; set; }
        //根据菜品单位,注入单位名字
        public void InjectDishUnitName()
        {
            if (DishUnit != null) { 
                this.DishUnitName = DishUnit.Name;
            }
        }
        //根据价格集合 ,找出 基础规格 注入到 DishBean 中
        public void InjectBeanPrice() {
            if (DishPrice != null) {
                foreach (var element in DishPrice) {
                    if (element.IsMainPrice == 1) {
                        this.Price1 = element.Price1;
                        this.Price2 = element.Price2;
                        this.Price3 = element.Price3;
                        this._DishFormatName = element.DishSpecification;
                        this.MemberPrice1 = element.MemberPrice1;
                        this.MemberPrice2 = element.MemberPrice2;
                        this.MemberPrice3 = element.MemberPrice3;
                        break;
                    }
                }
            }
        }
        //根据 
        public DishBean CreateDishBean(Dish dish)
        {
            this.AidNumber = dish.AidNumber;
            this.Code = dish.Code;
            this.CreateBy = dish.CreateBy;
            this.CreateDatetime = dish.CreateDatetime;
            this.Deleted = dish.Deleted;
            this.Detail = dish.Detail;
            this.DischesType = dish.DischesType;
            this.DiscountConfirm = dish.DiscountConfirm;
            this.DishFinanceId = dish.DishFinanceId;
            this.DishFormat = dish.DishFormat;
            this.DishId = dish.DishId;
            this.DishName = dish.DishName;
            this.DishTypeId = dish.DishTypeId;
            this.DishUnitId = dish.DishUnitId;
            this.EnglishName = dish.EnglishName;
            this.FoodFight = dish.FoodFight;
            this.Img = dish.Img;
            this.IsStop = dish.IsStop;
            this.KitchenType = dish.KitchenType;
            this.LineConfirm = dish.LineConfirm;
            this.LowConsumerConfirm = dish.LowConsumerConfirm;
            this.PackagesConfirm = dish.PackagesConfirm;
            this.PingYing = dish.PingYing;
            this.PosConfirm = dish.PosConfirm;
            this.PriceTimeConfirm = dish.PriceTimeConfirm;
            this.PublisherType = dish.PublisherType;
            this.SanpConfirm = dish.SanpConfirm;
            this.Status = dish.Status;
            this.ServerfreeConsumer = dish.ServerfreeConsumer;
            this.UpdateBy = dish.UpdateBy;
            this.UpdateDatetime = dish.UpdateDatetime;
            this.WeightConfirm = dish.WeightConfirm;
            this.DishPrice = dish.DishPrice;
            this.DishUnit = dish.DishUnit;
            this.DishUnitName = this.DishUnit.Name;
            return this;
        }
        public DishBean CreateDishBean2DishWay(Dish dish,DishUnit unit)
        {
            this.AidNumber = dish.AidNumber;
            this.Code = dish.Code;
            this.CreateBy = dish.CreateBy;
            this.CreateDatetime = dish.CreateDatetime;
            this.Deleted = dish.Deleted;
            this.Detail = dish.Detail;
            this.DischesType = dish.DischesType;
            this.DiscountConfirm = dish.DiscountConfirm;
            this.DishFinanceId = dish.DishFinanceId;
            this.DishFormat = dish.DishFormat;
            this.DishId = dish.DishId;
            this.DishName = dish.DishName;
            this.DishTypeId = dish.DishTypeId;
            this.DishUnitId = dish.DishUnitId;
            this.EnglishName = dish.EnglishName;
            this.FoodFight = dish.FoodFight;
            this.Img = dish.Img;
            this.IsStop = dish.IsStop;
            this.KitchenType = dish.KitchenType;
            this.LineConfirm = dish.LineConfirm;
            this.LowConsumerConfirm = dish.LowConsumerConfirm;
            this.PackagesConfirm = dish.PackagesConfirm;
            this.PingYing = dish.PingYing;
            this.PosConfirm = dish.PosConfirm;
            this.PriceTimeConfirm = dish.PriceTimeConfirm;
            this.PublisherType = dish.PublisherType;
            this.SanpConfirm = dish.SanpConfirm;
            this.Status = dish.Status;
            this.ServerfreeConsumer = dish.ServerfreeConsumer;
            this.UpdateBy = dish.UpdateBy;
            this.UpdateDatetime = dish.UpdateDatetime;
            this.WeightConfirm = dish.WeightConfirm;
            this.DishUnitName = unit.Name;
            return this;
        }
        public Dish CreateDish(DishBean dishBean)
        {
            Dish dish = new Dish();
            dish.AidNumber = dishBean.AidNumber;
            dish.Code = dishBean.Code;
            dish.CreateBy = dishBean.CreateBy;
            dish.CreateDatetime = dishBean.CreateDatetime;
            dish.Deleted = dishBean.Deleted;
            dish.Detail = dishBean.Detail;
            dish.DischesType = dishBean.DischesType;
            dish.DiscountConfirm = dishBean.DiscountConfirm;
            dish.DishFinanceId = dishBean.DishFinanceId;
            dish.DishFormat = dishBean.DishFormat;
            dish.DishId = dishBean.DishId;
            dish.DishName = dishBean.DishName;
            dish.DishTypeId = dishBean.DishTypeId;
            dish.DishUnitId = dishBean.DishUnitId;
            dish.EnglishName = dishBean.EnglishName;
            dish.FoodFight = dishBean.FoodFight;
            dish.Img = dishBean.Img;
            dish.IsStop = dishBean.IsStop;
            dish.KitchenType = dishBean.KitchenType;
            dish.LineConfirm = dishBean.LineConfirm;
            dish.LowConsumerConfirm = dishBean.LowConsumerConfirm;
            dish.PackagesConfirm = dishBean.PackagesConfirm;
            dish.PingYing = dishBean.PingYing;
            dish.PosConfirm = dishBean.PosConfirm;
            dish.PriceTimeConfirm = dishBean.PriceTimeConfirm;
            dish.PublisherType = dishBean.PublisherType;
            dish.SanpConfirm = dishBean.SanpConfirm;
            dish.Status = dishBean.Status;
            dish.ServerfreeConsumer = dishBean.ServerfreeConsumer;
            dish.UpdateBy = dishBean.UpdateBy;
            dish.UpdateDatetime = dishBean.UpdateDatetime;
            dish.WeightConfirm = dishBean.WeihtConfirm;

            return dish;
        }

        public DishBean InjectionPrice(DishPrice bean) {
            this.Price1 = bean.Price1;
            this.Price2 = bean.Price2;
            this.Price3 = bean.Price3;
            this.MemberPrice3 = bean.MemberPrice3;
            this.MemberPrice2 = bean.MemberPrice2;
            this.MemberPrice1 = bean.MemberPrice1; 
            return this;
        }

        public DishPrice CreateDishPrice(DishBean bean)
        {
            DishPrice beanBack = new DishPrice();
            beanBack.DishId = bean.DishId;
            beanBack.DishSpecification = bean.DishFormat;
            beanBack.Price1 = bean.Price1;
            beanBack.Price2 = bean.Price2;
            beanBack.Price3 = bean.Price3;
            beanBack.MemberPrice3 = bean.MemberPrice3;
            beanBack.MemberPrice2 = bean.MemberPrice2;
            beanBack.MemberPrice1 = bean.MemberPrice1;
            beanBack.CreateTime = DateTime.Now;
            beanBack.IsMainPrice = 1;
            beanBack.Deleted = 0;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.Update_by = bean.UpdateBy;
            beanBack.UpdateTime = bean.UpdateDatetime;
            return beanBack;

        }
    }
}
