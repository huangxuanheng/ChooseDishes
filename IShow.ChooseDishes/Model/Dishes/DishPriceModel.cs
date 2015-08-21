using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class DishPriceBean : BeanBasis, IEditableObject
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

        public int _IsMainPrice;
        public int IsMainPrice
        {
            get
            {
                return _IsMainPrice;
            }
            set
            {
                Set("IsMainPrice", ref _IsMainPrice, value);
            }
        }

        public  Dish _Dish;
        public  Dish Dish
        {
            get
            {
                return _Dish;
            }
            set
            {
                Set("Dish", ref _Dish, value);
            }
        }



        public DishPriceBean CreateDishPriceBean(DishPrice bean)
        {
            this.Id = bean.Id;
            this.DishId = bean.DishId;
            this.DishSpecification = bean.DishSpecification;
            this.Price1 = bean.Price1;
            this.Price2 = bean.Price2;
            this.Price3 = bean.Price3;
            this.MemberPrice3 = bean.MemberPrice3;
            this.MemberPrice2 = bean.MemberPrice2;
            this.MemberPrice1 = bean.MemberPrice1;
            this.IsMainPrice = bean.IsMainPrice;
            this.Dish = bean.Dish;
            return this;

        }
        public DishPrice CreateDishPrice(DishPriceBean bean)
        {
            DishPrice beanBack = new DishPrice();
            beanBack.Id = bean.Id;
            beanBack.DishId = bean.DishId;
            beanBack.DishSpecification = bean.DishSpecification;
            beanBack.Price1 = bean.Price1;
            beanBack.Price2 = bean.Price2;
            beanBack.Price3 = bean.Price3;
            beanBack.MemberPrice3 = bean.MemberPrice3;
            beanBack.MemberPrice2 = bean.MemberPrice2;
            beanBack.MemberPrice1 = bean.MemberPrice1;
            beanBack.IsMainPrice = bean.IsMainPrice;
            beanBack.Dish = bean.Dish;
            return beanBack;

        }



    }
}
