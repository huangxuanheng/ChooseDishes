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
    public class BargainDishBean : BeanBasis, IEditableObject
    {

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

        public string _StartTime="00:00";
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

        public System.DateTime _EndDate = DateTime.Now.AddDays(1);
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

        public int _Week1 = 1;
        public int Week1
        {
            get
            {
                return _Week1;
            }
            set
            {
                Set("Week1", ref _Week1, value);
            }
        }

        public int _Week2=1;
        public int Week2
        {
            get
            {
                return _Week2;
            }
            set
            {
                Set("Week2", ref _Week2, value);
            }
        }

        public int _Week3=1;
        public int Week3
        {
            get
            {
                return _Week3;
            }
            set
            {
                Set("Week3", ref _Week3, value);
            }
        }

        public int _Week4=1;
        public int Week4
        {
            get
            {
                return _Week4;
            }
            set
            {
                Set("Week4", ref _Week4, value);
            }
        }

        public int _Week5=1;
        public int Week5
        {
            get
            {
                return _Week5;
            }
            set
            {
                Set("Week5", ref _Week5, value);
            }
        }

        public int _Week6=1;
        public int Week6
        {
            get
            {
                return _Week6;
            }
            set
            {
                Set("Week6", ref _Week6, value);
            }
        }

        public int _Week0=1;
        public int Week0
        {
            get
            {
                return _Week0;
            }
            set
            {
                Set("Week0", ref _Week0, value);
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
                Set("MarketTypeId", ref _MarketTypeId, value);
            }
        }

        public int _Enable;
        public int Enable
        {
            get
            {
                return _Enable;
            }
            set
            {
                Set("Enable", ref _Enable, value);
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

        public  ICollection<BargainDishPrice> _BargainDishPrice;
        public  ICollection<BargainDishPrice> BargainDishPrice
        {
            get
            {
                return _BargainDishPrice;
            }
            set
            {
                Set("BargainDishPrice", ref _BargainDishPrice, value);
            }
        }
        public Dish Dish { get; set; }

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

        public BargainDishBean CreateBargainDishBean(BargainDish bean)
        {
            this.Id = bean.Id;
            this.DishId = bean.DishId;
            this.StartTime = bean.StartTime;
            this.EndTime = bean.EndTime;
            this.StartDate = bean.StartDate;
            this.EndDate = bean.EndDate;
            this.Week1 = bean.Week1;
            this.Week2 = bean.Week2;
            this.Week3 = bean.Week3;
            this.Week4 = bean.Week4;
            this.Week5 = bean.Week5;
            this.Week6 = bean.Week6;
            this.Week0 = bean.Week0;
            this.MarketTypeId = bean.MarketTypeId;
            this.Enable = bean.Enable;
            this.CreateBy = bean.CreateBy;
            this.CreateDatetime = bean.CreateTime;
            this.UpdateBy = bean.Update_by;
            this.UpdateDatetime = bean.UpdateTime;
            this.Deleted = bean.Deleted;
            this.BargainDishPrice = bean.BargainDishPrice;
            InjectDish(bean.Dish);
            InjectBargainDishPrice();
            return this;

        }

        public BargainDishBean InjectDish(Dish dish) {
            if (dish != null) { 
                this.Code = dish.Code;
                this.DishName = dish.DishName;
                this.DishFormat = dish.DishFormat;
                if (dish.DishUnit != null) {
                    this.DishUnitName = dish.DishUnit.Name;
                }
            }
            return this;
        }

        public void InjectBargainDishPrice() {
            if (BargainDishPrice != null && BargainDishPrice.Count > 0) {
                foreach (var bean in BargainDishPrice)
                {
                    this.Price1 = bean.Price1;
                    this.Price2 = bean.Price2;
                    this.Price3 = bean.Price3;
                    this.MemberPrice3 = bean.MemberPrice3;
                    this.MemberPrice2 = bean.MemberPrice2;
                    this.MemberPrice1 = bean.MemberPrice1;
                }
            }
        }

        public BargainDish CreateBargainDish(BargainDishBean bean)
        {
            BargainDish beanBack = new BargainDish();
            beanBack.Id = bean.Id;
            beanBack.DishId = bean.DishId;
            beanBack.StartTime = bean.StartTime;
            beanBack.EndTime = bean.EndTime;
            beanBack.StartDate = bean.StartDate;
            beanBack.EndDate = bean.EndDate;
            beanBack.Week1 = bean.Week1;
            beanBack.Week2 = bean.Week2;
            beanBack.Week3 = bean.Week3;
            beanBack.Week4 = bean.Week4;
            beanBack.Week5 = bean.Week5;
            beanBack.Week6 = bean.Week6;
            beanBack.Week0 = bean.Week0;
            beanBack.MarketTypeId = bean.MarketTypeId;
            beanBack.Enable = bean.Enable;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.CreateTime = DateTime.Now;
            beanBack.Update_by = bean.UpdateBy;
            beanBack.UpdateTime = bean.UpdateDatetime;
            beanBack.Deleted = bean.Deleted;
            return beanBack;

        }
        public BargainDishPrice CreateBargainDishPrice(BargainDishBean bean)
        {
            BargainDishPrice beanBack = new BargainDishPrice();
            beanBack.Id = bean.BargainDishPrice == null ? 0 : bean.BargainDishPrice.Count == 0 ? 0 : bean.BargainDishPrice.First().Id;
            beanBack.BargainDishId = bean.Id;
            beanBack.Price1 = bean.Price1;
            beanBack.Price2 = bean.Price2;
            beanBack.Price3 = bean.Price3;
            beanBack.MemberPrice3 = bean.MemberPrice3;
            beanBack.MemberPrice2 = bean.MemberPrice2;
            beanBack.MemberPrice1 = bean.MemberPrice1;
            beanBack.DishSpecification = bean.DishFormat;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.CreateTime = DateTime.Now;
            beanBack.Update_by = bean.UpdateBy;
            beanBack.UpdateTime = bean.UpdateDatetime;
            beanBack.Deleted = bean.Deleted;
            return beanBack;

        }
        public List<BargainDish> CreateBargainDishList(DishBeanUtil[] _BargainDiahSelectList)
        {
            if (_BargainDiahSelectList != null && _BargainDiahSelectList.Length > 0) {

                List<BargainDish> list = new List<BargainDish>();
                foreach (var element in _BargainDiahSelectList) {
                    BargainDish bargainDishBean = CreateBargainDish(this);
                    bargainDishBean.DishId = element.DishId;
                    bargainDishBean.Enable = 1;
                    bargainDishBean.MarketTypeId = 0;
                    bargainDishBean.CreateBy = SubjectUtils.GetAuthenticationId();
                    BargainDishPrice bargainDishPrice = new BargainDishPrice();
                    bargainDishPrice.Price1 = element.Price1;
                    bargainDishPrice.Price2 = element.Price2;
                    bargainDishPrice.Price3 = element.Price3;
                    bargainDishPrice.MemberPrice3 = element.MemberPrice3;
                    bargainDishPrice.MemberPrice2 = element.MemberPrice2;
                    bargainDishPrice.MemberPrice1 = element.MemberPrice1;
                    bargainDishPrice.DishSpecification = element.DishFormat;
                    bargainDishPrice.CreateBy = bargainDishBean.CreateBy;
                    bargainDishPrice.CreateTime = DateTime.Now;
                    bargainDishBean.BargainDishPrice.Add(bargainDishPrice);
                    list.Add(bargainDishBean);
                }
                return list;
            
            }
            return null;
        }
    }
}
