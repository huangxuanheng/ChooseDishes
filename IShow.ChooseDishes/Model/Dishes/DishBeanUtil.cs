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
    public class DishBeanUtil : ObservableObject
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
        public DishBeanUtil CreateDishBeanUtilByDishBean(DishPrice bean)
        {
            this.DishId = bean.DishId;
            this.Price1 = bean.Price1;
            this.Price2 = bean.Price2;
            this.Price3 = bean.Price3;
            this.MemberPrice3 = bean.MemberPrice3;
            this.MemberPrice2 = bean.MemberPrice2;
            this.MemberPrice1 = bean.MemberPrice1;
            this.DishFormat = bean.DishSpecification;

            return this;
        }
        public void RoundMathPrice(int ZheKouZhi, int BaoLiuWeiShu)
        {
            this.Price1 = Math.Round(this.Price1 * ZheKouZhi / 100, BaoLiuWeiShu);
            this.Price2 = Math.Round(this.Price2 * ZheKouZhi / 100, BaoLiuWeiShu);
            this.Price3 = Math.Round(this.Price3 * ZheKouZhi / 100, BaoLiuWeiShu);
            this.MemberPrice1 = Math.Round(this.MemberPrice1 * ZheKouZhi / 100, BaoLiuWeiShu);
            this.MemberPrice2 = Math.Round(this.MemberPrice2 * ZheKouZhi / 100, BaoLiuWeiShu);
            this.MemberPrice3 = Math.Round(this.MemberPrice3 * ZheKouZhi / 100, BaoLiuWeiShu);
        }
    }
}
