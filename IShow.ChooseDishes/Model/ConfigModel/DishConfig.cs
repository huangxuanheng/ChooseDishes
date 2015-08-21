using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.ConfigModel
{
    /// <summary>
    /// 点菜参数
    /// </summary>
    public partial class DishConfig : ViewModelBase
    {
        int _Point_Dishes_Fuzzy_Query;
        public int Point_Dishes_Fuzzy_Query{
            get { return _Point_Dishes_Fuzzy_Query; }
            set { Set("Point_Dishes_Fuzzy_Query", ref _Point_Dishes_Fuzzy_Query, value); }
        }

        int _Point_Dishes_Goto_Practice;
        public int Point_Dishes_Goto_Practice
        {
            get { return _Point_Dishes_Goto_Practice; }
            set { Set("Point_Dishes_Goto_Practice", ref _Point_Dishes_Goto_Practice, value); }
        }

        int _Point_Dishes_Fill_Post;
        public int Point_Dishes_Fill_Post
        {
            get { return _Point_Dishes_Fill_Post; }
            set { Set("Point_Dishes_Fill_Post", ref _Point_Dishes_Fill_Post, value); }
        }

        int _Point_Goto_Num;
        public int Point_Goto_Num
        {
            get { return _Point_Goto_Num; }
            set { Set("Point_Goto_Num", ref _Point_Goto_Num, value); }
        }

        int _Method_More;
        public int Method_More
        {
            get { return _Method_More; }
            set { Set("Method_More", ref _Method_More, value); }
        }

        int _Display_Dishes_Small_Class;
        public int Display_Dishes_Small_Class
        {
            get { return _Display_Dishes_Small_Class; }
            set { Set("Display_Dishes_Small_Class", ref _Display_Dishes_Small_Class, value); }
        }

        int _Ordering_Total_Printing;
        public int Ordering_Total_Printing
        {
            get { return _Ordering_Total_Printing; }
            set { Set("Ordering_Total_Printing", ref _Ordering_Total_Printing, value); }
        }

        string _Order_Copies_Num;
        public string Order_Copies_Num
        {
            get { return _Order_Copies_Num; }
            set { Set("Order_Copies_Num", ref _Order_Copies_Num, value); }
        }

        int _Find_And_Return_Dishes;
        public int Find_And_Return_Dishes
        {
            get { return _Find_And_Return_Dishes; }
            set { Set("Find_And_Return_Dishes", ref _Find_And_Return_Dishes, value); }
        }

        int _Set_Meal_Detail_Change_Dishes_Start;
        public int Set_Meal_Detail_Change_Dishes_Start
        {
            get { return _Set_Meal_Detail_Change_Dishes_Start; }
            set { Set("Set_Meal_Detail_Change_Dishes_Start", ref _Set_Meal_Detail_Change_Dishes_Start, value); }
        }

        int _Day_Report_Control;
        public int Day_Report_Control
        {
            get { return _Day_Report_Control; }
            set { Set("Day_Report_Control", ref _Day_Report_Control, value); }
        }

        int _Entry_Way;
        public int Entry_Way
        {
            get { return _Entry_Way; }
            set { Set("Entry_Way", ref _Entry_Way, value); }
        }

        string _Takeaway_Price_Type;
        public string Takeaway_Price_Type
        {
            get { return _Takeaway_Price_Type; }
            set { Set("Takeaway_Price_Type", ref _Takeaway_Price_Type, value); }
        }

        //服务员录入方式
        int _Entry_Way_One;
        public int Entry_Way_One
        {
            get { return _Entry_Way_One; }
            set { Set("Entry_Way_One", ref _Entry_Way_One, value); }
        }
        int _Entry_Way_Two;
        public int Entry_Way_Two
        {
            get { return _Entry_Way_Two; }
            set { Set("Entry_Way_Two", ref _Entry_Way_Two, value); }
        }
        int _Entry_Way_Three;
        public int Entry_Way_Three
        {
            get { return _Entry_Way_Three; }
            set { Set("Entry_Way_Three", ref _Entry_Way_Three, value); }
        }
        int _Entry_Way_Four;
        public int Entry_Way_Four
        {
            get { return _Entry_Way_Four; }
            set { Set("Entry_Way_Four", ref _Entry_Way_Four, value); }
        }

        public DishConfig QueryDishConfig(List<Config> configList)
        {
            //13
            this.Point_Dishes_Fuzzy_Query = int.Parse(this.QueryValue(configList, "Point_Dishes_Fuzzy_Query").Value);//点餐启用模糊查询
            this.Point_Dishes_Goto_Practice = int.Parse(this.QueryValue(configList, "Point_Dishes_Goto_Practice").Value);//点菜自动转到私有做法
            this.Point_Dishes_Fill_Post = int.Parse(this.QueryValue(configList, "Point_Dishes_Fill_Post").Value);//套菜换菜时补差价
            this.Point_Goto_Num = int.Parse(this.QueryValue(configList, "Point_Goto_Num").Value);//点菜后自动进入数量录入
            this.Method_More = int.Parse(this.QueryValue(configList, "Method_More").Value);//私有做法可多选
            this.Display_Dishes_Small_Class = int.Parse(this.QueryValue(configList, "Display_Dishes_Small_Class").Value);//点菜界面显示菜品小类
            this.Ordering_Total_Printing = int.Parse(this.QueryValue(configList, "Ordering_Total_Printing").Value);//本机落单打印总单
            this.Order_Copies_Num = this.QueryValue(configList, "Order_Copies_Num").Value;//餐桌点菜单打印份数
            this.Find_And_Return_Dishes = int.Parse(this.QueryValue(configList, "Find_And_Return_Dishes").Value);//查找点菜记录进行退菜
            this.Set_Meal_Detail_Change_Dishes_Start = int.Parse(this.QueryValue(configList, "Set_Meal_Detail_Change_Dishes_Start").Value);//套菜明细换菜启用所有菜品功能
            this.Day_Report_Control = int.Parse(this.QueryValue(configList, "Day_Report_Control").Value);//日结时间控制
            this.Entry_Way = int.Parse(this.QueryValue(configList, "Entry_Way").Value);//服务员录入方式
            this.Takeaway_Price_Type = this.QueryValue(configList, "Takeaway_Price_Type").Value;//外卖价格类型

            //服务员录入方式
            switch (this.Entry_Way)
            {
                case 1:
                    this.Entry_Way_One = 1;
                    this.Entry_Way_Two = 0;
                    this.Entry_Way_Three = 0;
                    this.Entry_Way_Four = 0;
                    break;
                case 2:
                    this.Entry_Way_One = 0;
                    this.Entry_Way_Two = 1;
                    this.Entry_Way_Three = 0;
                    this.Entry_Way_Four = 0;
                    break;
                case 3:
                    this.Entry_Way_One = 0;
                    this.Entry_Way_Two = 0;
                    this.Entry_Way_Three = 1;
                    this.Entry_Way_Four = 0;
                    break;
                case 4:
                    this.Entry_Way_One = 0;
                    this.Entry_Way_Two = 0;
                    this.Entry_Way_Three = 0;
                    this.Entry_Way_Four = 1;
                    break;
                default:
                    break;
            }

            return this;
        }

        public Config QueryValue(List<Config> configList, string name)
        {
            Config c = new Config();
            foreach (Config config in configList)
            {
                if (config.Name.Equals(name))
                {
                    c = config;
                }
            }
            return c;
        }
    }
}
