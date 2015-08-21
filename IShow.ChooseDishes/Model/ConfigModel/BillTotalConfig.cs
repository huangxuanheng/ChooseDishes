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
    /// 总单参数
    /// </summary>
    public partial class BillTotalConfig : ObservableObject
    {
        string _Print_Order_Title;
        public string Print_Order_Title
        {
            get { return _Print_Order_Title; }
            set { Set("Print_Order_Title", ref _Print_Order_Title, value); }
        }

        string _Retreat_Food_Title;
        public string Retreat_Food_Title
        {
            get { return _Retreat_Food_Title; }
            set { Set("Retreat_Food_Title", ref _Retreat_Food_Title, value); }
        }

        int _Billing_Number_TotalBill;
        public int Billing_Number_TotalBill
        {
            get { return _Billing_Number_TotalBill; }
            set { Set("Billing_Number_TotalBill", ref _Billing_Number_TotalBill, value); }
        }

        int _Table_TotalBill;
        public int Table_TotalBill
        {
            get { return _Table_TotalBill; }
            set { Set("Table_TotalBill", ref _Table_TotalBill, value); }
        }

        int _Table_Font_Increase_TotalBill;
        public int Table_Font_Increase_TotalBill
        {
            get { return _Table_Font_Increase_TotalBill; }
            set { Set("Table_Font_Increase_TotalBill", ref _Table_Font_Increase_TotalBill, value); }
        }

        int _Person_Num_TotalBill;
        public int Person_Num_TotalBill
        {
            get { return _Person_Num_TotalBill; }
            set { Set("Person_Num_TotalBill", ref _Person_Num_TotalBill, value); }
        }

        int _Bill_Start_TotalBill;
        public int Bill_Start_TotalBill
        {
            get { return _Bill_Start_TotalBill; }
            set { Set("Bill_Start_TotalBill", ref _Bill_Start_TotalBill, value); }
        }

        int _Open_Waiter_Name;
        public int Open_Waiter_Name
        {
            get { return _Open_Waiter_Name; }
            set { Set("Open_Waiter_Name", ref _Open_Waiter_Name, value); }
        }

        int _Waiter_Num_TotalBill;
        public int Waiter_Num_TotalBill
        {
            get { return _Waiter_Num_TotalBill; }
            set { Set("Waiter_Num_TotalBill", ref _Waiter_Num_TotalBill, value); }
        }

        int _Waiter_Name_TotalBill;
        public int Waiter_Name_TotalBill
        {
            get { return _Waiter_Name_TotalBill; }
            set { Set("Waiter_Name_TotalBill", ref _Waiter_Name_TotalBill, value); }
        }

        int _Handwriting_Num_TotalBill;
        public int Handwriting_Num_TotalBill
        {
            get { return _Handwriting_Num_TotalBill; }
            set { Set("Handwriting_Num_TotalBill", ref _Handwriting_Num_TotalBill, value); }
        }

        int _Bill_Note_TotalBill;
        public int Bill_Note_TotalBill
        {
            get { return _Bill_Note_TotalBill; }
            set { Set("Bill_Note_TotalBill", ref _Bill_Note_TotalBill, value); }
        }

        int _Waiter_TotalBill;
        public int Waiter_TotalBill
        {
            get { return _Waiter_TotalBill; }
            set { Set("Waiter_TotalBill", ref _Waiter_TotalBill, value); }
        }

        string _List_Title;
        public string List_Title
        {
            get { return _List_Title; }
            set { Set("List_Title", ref _List_Title, value); }
        }

        int _Detail_Num_TotalBill;
        public int Detail_Num_TotalBill
        {
            get { return _Detail_Num_TotalBill; }
            set { Set("Detail_Num_TotalBill", ref _Detail_Num_TotalBill, value); }
        }

        int _Give_Mark_TotalBill;
        public int Give_Mark_TotalBill
        {
            get { return _Give_Mark_TotalBill; }
            set { Set("Give_Mark_TotalBill", ref _Give_Mark_TotalBill, value); }
        }

        int _Set_Meal_Mark_TotalBill;
        public int Set_Meal_Mark_TotalBill
        {
            get { return _Set_Meal_Mark_TotalBill; }
            set { Set("Set_Meal_Mark_TotalBill", ref _Set_Meal_Mark_TotalBill, value); }
        }

        int _Dishes_Print_English_Name_TotalBill;
        public int Dishes_Print_English_Name_TotalBill
        {
            get { return _Dishes_Print_English_Name_TotalBill; }
            set { Set("Dishes_Print_English_Name_TotalBill", ref _Dishes_Print_English_Name_TotalBill, value); }
        }

        int _Special_Dishes_Mark_TotalBill;
        public int Special_Dishes_Mark_TotalBill
        {
            get { return _Special_Dishes_Mark_TotalBill; }
            set { Set("Special_Dishes_Mark_TotalBill", ref _Special_Dishes_Mark_TotalBill, value); }
        }

        int _Discount_Mark_TotalBill;
        public int Discount_Mark_TotalBill
        {
            get { return _Discount_Mark_TotalBill; }
            set { Set("Discount_Mark_TotalBill", ref _Discount_Mark_TotalBill, value); }
        }

        int _Print_Retreat_Dishes_TotalBill;
        public int Print_Retreat_Dishes_TotalBill
        {
            get { return _Print_Retreat_Dishes_TotalBill; }
            set { Set("Print_Retreat_Dishes_TotalBill", ref _Print_Retreat_Dishes_TotalBill, value); }
        }

        int _Unit_TotalBill;
        public int Unit_TotalBill
        {
            get { return _Unit_TotalBill; }
            set { Set("Unit_TotalBill", ref _Unit_TotalBill, value); }
        }

        int _Coupons_Mark_TotalBill;
        public int Coupons_Mark_TotalBill
        {
            get { return _Coupons_Mark_TotalBill; }
            set { Set("Coupons_Mark_TotalBill", ref _Coupons_Mark_TotalBill, value); }
        }

        int _If_Print_Method_TotalBill;
        public int If_Print_Method_TotalBill
        {
            get { return _If_Print_Method_TotalBill; }
            set { Set("If_Print_Method_TotalBill", ref _If_Print_Method_TotalBill, value); }
        }

        int _If_Print_Add_Materials_TotalBill;
        public int If_Print_Add_Materials_TotalBill
        {
            get { return _If_Print_Add_Materials_TotalBill; }
            set { Set("If_Print_Add_Materials_TotalBill", ref _If_Print_Add_Materials_TotalBill, value); }
        }

        int _Num_TotalBill;
        public int Num_TotalBill
        {
            get { return _Num_TotalBill; }
            set { Set("Num_TotalBill", ref _Num_TotalBill, value); }
        }

        string _Num_Small_Digit_TotalBill;
        public string Num_Small_Digit_TotalBill
        {
            get { return _Num_Small_Digit_TotalBill; }
            set { Set("Num_Small_Digit_TotalBill", ref _Num_Small_Digit_TotalBill, value); }
        }

        string _Set_Meal_Print_Method_TotalBill;
        public string Set_Meal_Print_Method_TotalBill
        {
            get { return _Set_Meal_Print_Method_TotalBill; }
            set { Set("Set_Meal_Print_Method_TotalBill", ref _Set_Meal_Print_Method_TotalBill, value); }
        }

        int _Dishes_Classification_Statistic_TotalBill;
        public int Dishes_Classification_Statistic_TotalBill
        {
            get { return _Dishes_Classification_Statistic_TotalBill; }
            set { Set("Dishes_Classification_Statistic_TotalBill", ref _Dishes_Classification_Statistic_TotalBill, value); }
        }

        int _Price_TotalBill;
        public int Price_TotalBill
        {
            get { return _Price_TotalBill; }
            set { Set("Price_TotalBill", ref _Price_TotalBill, value); }
        }

        string _Price_Small_Digit_TotalBill;
        public string Price_Small_Digit_TotalBill
        {
            get { return _Price_Small_Digit_TotalBill; }
            set { Set("Price_Small_Digit_TotalBill", ref _Price_Small_Digit_TotalBill, value); }
        }

        int _Original_Price_TotalBill;
        public int Original_Price_TotalBill
        {
            get { return _Original_Price_TotalBill; }
            set { Set("Original_Price_TotalBill", ref _Original_Price_TotalBill, value); }
        }

        string _Original_Price_Small_Digit_TotalBill;
        public string Original_Price_Small_Digit_TotalBill
        {
            get { return _Original_Price_Small_Digit_TotalBill; }
            set { Set("Original_Price_Small_Digit_TotalBill", ref _Original_Price_Small_Digit_TotalBill, value); }
        }

        int _Print_Classification_Noprint_Detail_TotalBill;
        public int Print_Classification_Noprint_Detail_TotalBill
        {
            get { return _Print_Classification_Noprint_Detail_TotalBill; }
            set { Set("Print_Classification_Noprint_Detail_TotalBill", ref _Print_Classification_Noprint_Detail_TotalBill, value); }
        }

        int _If_Print_Money_TotalBill;
        public int If_Print_Money_TotalBill
        {
            get { return _If_Print_Money_TotalBill; }
            set { Set("If_Print_Money_TotalBill", ref _If_Print_Money_TotalBill, value); }
        }

        string _Money_Small_Digit_TotalBill;
        public string Money_Small_Digit_TotalBill
        {
            get { return _Money_Small_Digit_TotalBill; }
            set { Set("Money_Small_Digit_TotalBill", ref _Money_Small_Digit_TotalBill, value); }
        }

        int _Preferential_Money_TotalBill;
        public int Preferential_Money_TotalBill
        {
            get { return _Preferential_Money_TotalBill; }
            set { Set("Preferential_Money_TotalBill", ref _Preferential_Money_TotalBill, value); }
        }

        string _Preferential_Money_Small_Digit_TotalBill;
        public string Preferential_Money_Small_Digit_TotalBill
        {
            get { return _Preferential_Money_Small_Digit_TotalBill; }
            set { Set("Preferential_Money_Small_Digit_TotalBill", ref _Preferential_Money_Small_Digit_TotalBill, value); }
        }

        int _Total_Quantity;
        public int Total_Quantity
        {
            get { return _Total_Quantity; }
            set { Set("Total_Quantity", ref _Total_Quantity, value); }
        }

        int _Total_Amount;
        public int Total_Amount
        {
            get { return _Total_Amount; }
            set { Set("Total_Amount", ref _Total_Amount, value); }
        }

        public BillTotalConfig QueryBillTotalConfig(List<Config> configList)
        {
            //40
            this.Print_Order_Title = this.QueryValue(configList, "Print_Order_Title").Value;//点菜标题
            this.Retreat_Food_Title = this.QueryValue(configList, "Retreat_Food_Title").Value;//退菜标题
            this.Billing_Number_TotalBill = int.Parse(this.QueryValue(configList, "Billing_Number_TotalBill").Value);//开单单号
            this.Table_TotalBill = int.Parse(this.QueryValue(configList, "Table_TotalBill").Value);//餐桌
            this.Table_Font_Increase_TotalBill = int.Parse(this.QueryValue(configList, "Table_Font_Increase_TotalBill").Value);//餐桌字体加大
            this.Person_Num_TotalBill = int.Parse(this.QueryValue(configList, "Person_Num_TotalBill").Value);//消费人数
            this.Bill_Start_TotalBill = int.Parse(this.QueryValue(configList, "Bill_Start_TotalBill").Value);//开台时间
            this.Open_Waiter_Name = int.Parse(this.QueryValue(configList, "Open_Waiter_Name").Value);//开台员工
            this.Waiter_Num_TotalBill = int.Parse(this.QueryValue(configList, "Waiter_Num_TotalBill").Value);//服务员工号
            this.Waiter_Name_TotalBill = int.Parse(this.QueryValue(configList, "Waiter_Name_TotalBill").Value);//服务员姓名
            this.Handwriting_Num_TotalBill = int.Parse(this.QueryValue(configList, "Handwriting_Num_TotalBill").Value);//手工单号
            this.Bill_Note_TotalBill = int.Parse(this.QueryValue(configList, "Bill_Note_TotalBill").Value);//开单备注
            this.Waiter_TotalBill = int.Parse(this.QueryValue(configList, "Waiter").Value);//点菜员
            this.List_Title = this.QueryValue(configList, "List_Title").Value;//列表头
            this.Detail_Num_TotalBill = int.Parse(this.QueryValue(configList, "Detail_Num_TotalBill").Value);//明细序号
            this.Give_Mark_TotalBill = int.Parse(this.QueryValue(configList, "Give_Mark_TotalBill").Value);//赠送标识
            this.Set_Meal_Mark_TotalBill = int.Parse(this.QueryValue(configList, "Set_Meal_Mark_TotalBill").Value);//套菜标识
            this.Dishes_Print_English_Name_TotalBill = int.Parse(this.QueryValue(configList, "Dishes_Print_English_Name_TotalBill").Value);//品名打印成英文名称
            this.Special_Dishes_Mark_TotalBill = int.Parse(this.QueryValue(configList, "Special_Dishes_Mark_TotalBill").Value);//特价标识
            this.Discount_Mark_TotalBill = int.Parse(this.QueryValue(configList, "Discount_Mark_TotalBill").Value);//折扣标识*
            this.Print_Retreat_Dishes_TotalBill = int.Parse(this.QueryValue(configList, "Print_Retreat_Dishes_TotalBill").Value);//打印退菜菜品
            this.Unit_TotalBill = int.Parse(this.QueryValue(configList, "Unit_TotalBill").Value);//单位
            this.Coupons_Mark_TotalBill = int.Parse(this.QueryValue(configList, "Coupons_Mark_TotalBill").Value);//优惠券标示
            this.If_Print_Method_TotalBill = int.Parse(this.QueryValue(configList, "If_Print_Method_TotalBill").Value);//是否打印做法
            this.If_Print_Add_Materials_TotalBill = int.Parse(this.QueryValue(configList, "If_Print_Add_Materials_TotalBill").Value);//是否打印加料
            this.Num_TotalBill = int.Parse(this.QueryValue(configList, "Num_TotalBill").Value);//数量
            this.Num_Small_Digit_TotalBill = this.QueryValue(configList, "Num_Small_Digit_TotalBill").Value;//数量小数位
            this.Set_Meal_Print_Method_TotalBill = this.QueryValue(configList, "Set_Meal_Print_Method_TotalBill").Value;//套菜打印方式
            this.Dishes_Classification_Statistic_TotalBill = int.Parse(this.QueryValue(configList, "Dishes_Classification_Statistic_TotalBill").Value);//菜品分类统计
            this.Price_TotalBill = int.Parse(this.QueryValue(configList, "Price_TotalBill").Value);//价格
            this.Price_Small_Digit_TotalBill = this.QueryValue(configList, "Price_Small_Digit_TotalBill").Value;//价格小数位
            this.Original_Price_TotalBill = int.Parse(this.QueryValue(configList, "Original_Price_TotalBill").Value);//原价额
            this.Original_Price_Small_Digit_TotalBill = this.QueryValue(configList, "Original_Price_Small_Digit_TotalBill").Value;//原价额小数位
            this.Print_Classification_Noprint_Detail_TotalBill = int.Parse(this.QueryValue(configList, "Print_Classification_Noprint_Detail_TotalBill").Value);//只打印分类不打印明细
            this.If_Print_Money_TotalBill = int.Parse(this.QueryValue(configList, "If_Print_Money_TotalBill").Value);//金额
            this.Money_Small_Digit_TotalBill = this.QueryValue(configList, "Money_Small_Digit_TotalBill").Value;//金额小数位
            this.Preferential_Money_TotalBill = int.Parse(this.QueryValue(configList, "Preferential_Money_TotalBill").Value);//优惠额
            this.Preferential_Money_Small_Digit_TotalBill = this.QueryValue(configList, "Preferential_Money_Small_Digit_TotalBill").Value;//优惠额小数位
            this.Total_Quantity = int.Parse(this.QueryValue(configList, "Total_Quantity").Value);//总数量：合计数量
            this.Total_Amount = int.Parse(this.QueryValue(configList, "Total_Amount").Value);//总金额：合计金额

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
