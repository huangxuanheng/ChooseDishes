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
    /// 账单参数
    /// </summary>
    public partial class BillConfig : ObservableObject
    {
        int _Print_Logo;
        public int Print_Logo{
            get { return _Print_Logo; }
            set { Set("Print_Logo", ref _Print_Logo, value); }
        }

        string _Logo_Path;
        public string Logo_Path
        {
            get { return _Logo_Path; }
            set { Set("Logo_Path", ref _Logo_Path, value); }
        }

        int _Anti_Checking_Done;
        public int Anti_Checking_Done
        {
            get { return _Anti_Checking_Done; }
            set { Set("Anti_Checking_Done", ref _Anti_Checking_Done, value); }
        }

        string _Bill_Title;
        public string Bill_Title
        {
            get { return _Bill_Title; }
            set { Set("Bill_Title", ref _Bill_Title, value); }
        }

        int _Handwriting_Num;
        public int Handwriting_Num
        {
            get { return _Handwriting_Num; }
            set { Set("Handwriting_Num", ref _Handwriting_Num, value); }
        }

        int _Bill_Mark;
        public int Bill_Mark
        {
            get { return _Bill_Mark; }
            set { Set("Bill_Mark", ref _Bill_Mark, value); }
        }

        int _Payment_Num;
        public int Payment_Num
        {
            get { return _Payment_Num; }
            set { Set("Payment_Num", ref _Payment_Num, value); }
        }

        int _Table;
        public int Table
        {
            get { return _Table; }
            set { Set("Table", ref _Table, value); }
        }

        int _Table_Font_Increase;
        public int Table_Font_Increase
        {
            get { return _Table_Font_Increase; }
            set { Set("Table_Font_Increase", ref _Table_Font_Increase, value); }
        }

        int _Checkout_Time;
        public int Checkout_Time
        {
            get { return _Checkout_Time; }
            set { Set("Checkout_Time", ref _Checkout_Time, value); }
        }

        int _Consume_Duration;
        public int Consume_Duration
        {
            get { return _Consume_Duration; }
            set { Set("Consume_Duration", ref _Consume_Duration, value); }
        }

        int _Print_Order_Num_After_Five;
        public int Print_Order_Num_After_Five
        {
            get { return _Print_Order_Num_After_Five; }
            set { Set("Print_Order_Num_After_Five", ref _Print_Order_Num_After_Five, value); }
        }

        int _Bill_Num;
        public int Bill_Num
        {
            get { return _Bill_Num; }
            set { Set("Bill_Num", ref _Bill_Num, value); }
        }

        int _Person_Num;
        public int Person_Num
        {
            get { return _Person_Num; }
            set { Set("Person_Num", ref _Person_Num, value); }
        }

        int _Bill_Start;
        public int Bill_Start
        {
            get { return _Bill_Start; }
            set { Set("Bill_Start", ref _Bill_Start, value); }
        }

        int _Bill_Note;
        public int Bill_Note
        {
            get { return _Bill_Note; }
            set { Set("Bill_Note", ref _Bill_Note, value); }
        }

        int _Cashier_Num;
        public int Cashier_Num
        {
            get { return _Cashier_Num; }
            set { Set("Cashier_Num", ref _Cashier_Num, value); }
        }

        int _Cashier_Name;
        public int Cashier_Name
        {
            get { return _Cashier_Name; }
            set { Set("Cashier_Name", ref _Cashier_Name, value); }
        }

        int _Customer_Contact;
        public int Customer_Contact
        {
            get { return _Customer_Contact; }
            set { Set("Customer_Contact", ref _Customer_Contact, value); }
        }

        int _Customer_Name;
        public int Customer_Name
        {
            get { return _Customer_Name; }
            set { Set("Customer_Name", ref _Customer_Name, value); }
        }

        int _Customer_Adress;
        public int Customer_Adress
        {
            get { return _Customer_Adress; }
            set { Set("Customer_Adress", ref _Customer_Adress, value); }
        }

        int _Deliver_Takeout_Time;
        public int Deliver_Takeout_Time
        {
            get { return _Deliver_Takeout_Time; }
            set { Set("Deliver_Takeout_Time", ref _Deliver_Takeout_Time, value); }
        }

        int _Waiter_Num;
        public int Waiter_Num
        {
            get { return _Waiter_Num; }
            set { Set("Waiter_Num", ref _Waiter_Num, value); }
        }

        int _Waiter_Name;
        public int Waiter_Name
        {
            get { return _Waiter_Name; }
            set { Set("Waiter_Name", ref _Waiter_Name, value); }
        }

        int _Sales_Num;
        public int Sales_Num
        {
            get { return _Sales_Num; }
            set { Set("Sales_Num", ref _Sales_Num, value); }
        }

        int _Sales_Name;
        public int Sales_Name
        {
            get { return _Sales_Name; }
            set { Set("Sales_Name", ref _Sales_Name, value); }
        }

        string _Head_List;
        public string Head_List
        {
            get { return _Head_List; }
            set { Set("Head_List", ref _Head_List, value); }
        }

        int _Detail_Num;
        public int Detail_Num
        {
            get { return _Detail_Num; }
            set { Set("Detail_Num", ref _Detail_Num, value); }
        }

        int _Give_Mark;
        public int Give_Mark
        {
            get { return _Give_Mark; }
            set { Set("Give_Mark", ref _Give_Mark, value); }
        }

        int _Set_Meal_Mark;
        public int Set_Meal_Mark
        {
            get { return _Set_Meal_Mark; }
            set { Set("Set_Meal_Mark", ref _Set_Meal_Mark, value); }
        }

        int _Dishes_Print_English_Name;
        public int Dishes_Print_English_Name
        {
            get { return _Dishes_Print_English_Name; }
            set { Set("Dishes_Print_English_Name", ref _Dishes_Print_English_Name, value); }
        }

        int _Special_Dishes_Mark;
        public int Special_Dishes_Mark
        {
            get { return _Special_Dishes_Mark; }
            set { Set("Special_Dishes_Mark", ref _Special_Dishes_Mark, value); }
        }

        int _Discount_Mark;
        public int Discount_Mark
        {
            get { return _Discount_Mark; }
            set { Set("Discount_Mark", ref _Discount_Mark, value); }
        }

        int _Print_Retreat_Dishes;
        public int Print_Retreat_Dishes
        {
            get { return _Print_Retreat_Dishes; }
            set { Set("Print_Retreat_Dishes", ref _Print_Retreat_Dishes, value); }
        }

        int _Unit;
        public int Unit
        {
            get { return _Unit; }
            set { Set("Unit", ref _Unit, value); }
        }

        int _Coupons_Mark;
        public int Coupons_Mark

        {
            get { return _Coupons_Mark; }
            set { Set("Coupons_Mark", ref _Coupons_Mark, value); }
        }

        int _If_Print_Method;
        public int If_Print_Method
        {
            get { return _If_Print_Method; }
            set { Set("If_Print_Method", ref _If_Print_Method, value); }
        }

        int _If_Print_Add_Materials;
        public int If_Print_Add_Materials
        {
            get { return _If_Print_Add_Materials; }
            set { Set("If_Print_Add_Materials", ref _If_Print_Add_Materials, value); }
        }

        int _Num;
        public int Num
        {
            get { return _Num; }
            set { Set("Num", ref _Num, value); }
        }

        string _Num_Small_Digit;
        public string Num_Small_Digit
        {
            get { return _Num_Small_Digit; }
            set { Set("Num_Small_Digit", ref _Num_Small_Digit, value); }
        }

        string _Set_Meal_Print_Method;
        public string Set_Meal_Print_Method
        {
            get { return _Set_Meal_Print_Method; }
            set { Set("Set_Meal_Print_Method", ref _Set_Meal_Print_Method, value); }
        }

        int _Dishes_Classification_Statistic;
        public int Dishes_Classification_Statistic
        {
            get { return _Dishes_Classification_Statistic; }
            set { Set("Dishes_Classification_Statistic", ref _Dishes_Classification_Statistic, value); }
        }

        int _Price;
        public int Price
        {
            get { return _Price; }
            set { Set("Price", ref _Price, value); }
        }

        string _Price_Small_Digit;
        public string Price_Small_Digit
        {
            get { return _Price_Small_Digit; }
            set { Set("Price_Small_Digit", ref _Price_Small_Digit, value); }
        }

        int _Original_Price;
        public int Original_Price
        {
            get { return _Original_Price; }
            set { Set("Original_Price", ref _Original_Price, value); }
        }

        string _Original_Price_Small_Digit;
        public string Original_Price_Small_Digit
        {
            get { return _Original_Price_Small_Digit; }
            set { Set("Original_Price_Small_Digit", ref _Original_Price_Small_Digit, value); }
        }

        int _Print_Classification_Noprint_Detail;
        public int Print_Classification_Noprint_Detail
        {
            get { return _Print_Classification_Noprint_Detail; }
            set { Set("Print_Classification_Noprint_Detail", ref _Print_Classification_Noprint_Detail, value); }
        }

        int _If_Print_Money;
        public int If_Print_Money
        {
            get { return _If_Print_Money; }
            set { Set("If_Print_Money", ref _If_Print_Money, value); }
        }

        string _Money_Small_Digit;
        public string Money_Small_Digit
        {
            get { return _Money_Small_Digit; }
            set { Set("Money_Small_Digit", ref _Money_Small_Digit, value); }
        }

        int _Preferential_Money;
        public int Preferential_Money
        {
            get { return _Preferential_Money; }
            set { Set("Preferential_Money", ref _Preferential_Money, value); }
        }

        string _Preferential_Money_Small_Digit;
        public string Preferential_Money_Small_Digit
        {
            get { return _Preferential_Money_Small_Digit; }
            set { Set("Preferential_Money_Small_Digit", ref _Preferential_Money_Small_Digit, value); }
        }

        int _Per_Capita_Consumption;
        public int Per_Capita_Consumption
        {
            get { return _Per_Capita_Consumption; }
            set { Set("Per_Capita_Consumption", ref _Per_Capita_Consumption, value); }
        }

        int _Print_Coupon_Money;
        public int Print_Coupon_Money
        {
            get { return _Print_Coupon_Money; }
            set { Set("Print_Coupon_Money", ref _Print_Coupon_Money, value); }
        }

        int _Print_Invoice_Money;
        public int Print_Invoice_Money
        {
            get { return _Print_Invoice_Money; }
            set { Set("Print_Invoice_Money", ref _Print_Invoice_Money, value); }
        }

        int _Discount_Scheme;
        public int Discount_Scheme
        {
            get { return _Discount_Scheme; }
            set { Set("Discount_Scheme", ref _Discount_Scheme, value); }
        }

        int _Line_Print_How_Many_Columns;
        public int Line_Print_How_Many_Columns
        {
            get { return _Line_Print_How_Many_Columns; }
            set { Set("Line_Print_How_Many_Columns", ref _Line_Print_How_Many_Columns, value); }
        }

        int _Service_Charge_Name;
        public int Service_Charge_Name
        {
            get { return _Service_Charge_Name; }
            set { Set("Service_Charge_Name", ref _Service_Charge_Name, value); }
        }

        int _Vip_Balance;
        public int Vip_Balance
        {
            get { return _Vip_Balance; }
            set { Set("Vip_Balance", ref _Vip_Balance, value); }
        }

        int _Available_Voucher;
        public int Available_Voucher
        {
            get { return _Available_Voucher; }
            set { Set("Available_Voucher", ref _Available_Voucher, value); }
        }

        int _Free_Charge_Cause;
        public int Free_Charge_Cause
        {
            get { return _Free_Charge_Cause; }
            set { Set("Free_Charge_Cause", ref _Free_Charge_Cause, value); }
        }

        int _Sign;
        public int Sign
        {
            get { return _Sign; }
            set { Set("Sign", ref _Sign, value); }
        }

        string _Last_Word;
        public string Last_Word
        {
            get { return _Last_Word; }
            set { Set("Last_Word", ref _Last_Word, value); }
        }

        int _QR_Code;
        public int QR_Code
        {
            get { return _QR_Code; }
            set { Set("QR_Code", ref _QR_Code, value); }
        }

        string _QR_Code_Road;
        public string QR_Code_Road
        {
            get { return _QR_Code_Road; }
            set { Set("QR_Code_Road", ref _QR_Code_Road, value); }
        }

        string _QR_Code_Explain;
        public string QR_Code_Explain
        {
            get { return _QR_Code_Explain; }
            set { Set("QR_Code_Explain", ref _QR_Code_Explain, value); }
        }

        string _Print_Software_Name;
        public string Print_Software_Name
        {
            get { return _Print_Software_Name; }
            set { Set("Print_Software_Name", ref _Print_Software_Name, value); }
        }

        public BillConfig QueryBillConfig(List<Config> configList)
        {
            //66
            this.Print_Logo = int.Parse(this.QueryValue(configList, "Print_Logo").Value);//打印logo
            this.Logo_Path = this.QueryValue(configList, "Logo_Path").Value;//logo路径
            this.Anti_Checking_Done = int.Parse(this.QueryValue(configList, "Anti_Checking_Done").Value);//已做反结账
            this.Bill_Title = this.QueryValue(configList, "Bill_Title").Value;//账单标题
            this.Handwriting_Num = int.Parse(this.QueryValue(configList, "Handwriting_Num").Value);//手工单号
            this.Bill_Mark = int.Parse(this.QueryValue(configList, "Bill_Mark").Value);//账单标识
            this.Payment_Num = int.Parse(this.QueryValue(configList, "Payment_Num").Value);//付款号
            this.Table = int.Parse(this.QueryValue(configList, "Table").Value);//餐桌
            this.Table_Font_Increase = int.Parse(this.QueryValue(configList, "Table_Font_Increase").Value);//餐桌字体加大
            this.Checkout_Time = int.Parse(this.QueryValue(configList, "Checkout_Time").Value);//结账时间
            this.Consume_Duration = int.Parse(this.QueryValue(configList, "Consume_Duration").Value);//消费时长
            this.Print_Order_Num_After_Five = int.Parse(this.QueryValue(configList, "Print_Order_Num_After_Five").Value);//付款单号打印后五位
            this.Bill_Num = int.Parse(this.QueryValue(configList, "Bill_Num").Value);//开单单号
            this.Person_Num = int.Parse(this.QueryValue(configList, "Person_Num").Value);//人数
            this.Bill_Start = int.Parse(this.QueryValue(configList, "Bill_Start").Value);//开单时间
            this.Bill_Note = int.Parse(this.QueryValue(configList, "Bill_Note").Value);//开单备注
            this.Cashier_Num = int.Parse(this.QueryValue(configList, "Cashier_Num").Value);//收银员工号
            this.Cashier_Name = int.Parse(this.QueryValue(configList, "Cashier_Name").Value);//收银员姓名
            this.Customer_Contact = int.Parse(this.QueryValue(configList, "Customer_Contact").Value);//外送联系电话
            this.Customer_Name = int.Parse(this.QueryValue(configList, "Customer_Name").Value);//外送联系人
            this.Customer_Adress = int.Parse(this.QueryValue(configList, "Customer_Adress").Value);//外送地址
            this.Deliver_Takeout_Time = int.Parse(this.QueryValue(configList, "Deliver_Takeout_Time").Value);//送餐时间
            this.Waiter_Num = int.Parse(this.QueryValue(configList, "Waiter_Num").Value);//服务员工号
            this.Waiter_Name = int.Parse(this.QueryValue(configList, "Waiter_Name").Value);//服务员姓名
            this.Sales_Num = int.Parse(this.QueryValue(configList, "Sales_Num").Value);//营销员工号
            this.Sales_Name = int.Parse(this.QueryValue(configList, "Sales_Name").Value);//营销员姓名
            this.Head_List = this.QueryValue(configList, "Head_List").Value;//列表头
            this.Detail_Num = int.Parse(this.QueryValue(configList, "Detail_Num").Value);//明细序号
            this.Give_Mark = int.Parse(this.QueryValue(configList, "Give_Mark").Value);//赠送标识
            this.Set_Meal_Mark = int.Parse(this.QueryValue(configList, "Set_Meal_Mark").Value);//套菜标识
            this.Dishes_Print_English_Name = int.Parse(this.QueryValue(configList, "Dishes_Print_English_Name").Value);//品名打印成英文名称
            this.Special_Dishes_Mark = int.Parse(this.QueryValue(configList, "Special_Dishes_Mark").Value);//特价标识
            this.Discount_Mark = int.Parse(this.QueryValue(configList, "Discount_Mark").Value);//折扣标识*
            this.Print_Retreat_Dishes = int.Parse(this.QueryValue(configList, "Print_Retreat_Dishes").Value);//打印退菜菜品
            this.Unit = int.Parse(this.QueryValue(configList, "Unit").Value);//单位
            this.Coupons_Mark = int.Parse(this.QueryValue(configList, "Coupons_Mark").Value);//优惠券标示
            this.If_Print_Method = int.Parse(this.QueryValue(configList, "If_Print_Method").Value);//是否打印做法
            this.If_Print_Add_Materials = int.Parse(this.QueryValue(configList, "If_Print_Add_Materials").Value);//是否打印加料
            this.Num = int.Parse(this.QueryValue(configList, "Num").Value);//数量
            this.Num_Small_Digit = this.QueryValue(configList, "Num_Small_Digit").Value;//数量小数位
            this.Set_Meal_Print_Method = this.QueryValue(configList, "Set_Meal_Print_Method").Value;//套菜打印方式
            this.Dishes_Classification_Statistic = int.Parse(this.QueryValue(configList, "Dishes_Classification_Statistic").Value);//菜品分类统计
            this.Price = int.Parse(this.QueryValue(configList, "Price").Value);//价格
            this.Price_Small_Digit = this.QueryValue(configList, "Price_Small_Digit").Value;//价格小数位
            this.Original_Price = int.Parse(this.QueryValue(configList, "Original_Price").Value);//原价额
            this.Original_Price_Small_Digit = this.QueryValue(configList, "Original_Price_Small_Digit").Value;//原价额小数位
            this.Print_Classification_Noprint_Detail = int.Parse(this.QueryValue(configList, "Print_Classification_Noprint_Detail").Value);//只打印分类不打印明细
            this.If_Print_Money = int.Parse(this.QueryValue(configList, "If_Print_Money").Value);//金额
            this.Money_Small_Digit = this.QueryValue(configList, "Money_Small_Digit").Value;//金额小数位
            this.Preferential_Money = int.Parse(this.QueryValue(configList, "Preferential_Money").Value);//优惠额
            this.Preferential_Money_Small_Digit = this.QueryValue(configList, "Preferential_Money_Small_Digit").Value;//优惠额小数位
            this.Per_Capita_Consumption = int.Parse(this.QueryValue(configList, "Per_Capita_Consumption").Value);//人均消费
            this.Print_Coupon_Money = int.Parse(this.QueryValue(configList, "Print_Coupon_Money").Value);//可发礼券额
            this.Print_Invoice_Money = int.Parse(this.QueryValue(configList, "Print_Invoice_Money").Value);//发票发放额
            this.Discount_Scheme = int.Parse(this.QueryValue(configList, "Discount_Scheme").Value);//折扣方案
            this.Line_Print_How_Many_Columns = int.Parse(this.QueryValue(configList, "Line_Print_How_Many_Columns").Value);//每行打印列数
            this.Service_Charge_Name = int.Parse(this.QueryValue(configList, "Service_Charge_Name").Value);//服务费别名
            this.Vip_Balance = int.Parse(this.QueryValue(configList, "Vip_Balance").Value);//会员余额
            this.Available_Voucher = int.Parse(this.QueryValue(configList, "Available_Voucher").Value);//可用代金券
            this.Free_Charge_Cause = int.Parse(this.QueryValue(configList, "Free_Charge_Cause").Value);//免单原因
            this.Sign = int.Parse(this.QueryValue(configList, "Sign").Value);//签名
            this.Last_Word = this.QueryValue(configList, "Last_Word").Value;//尾语
            this.QR_Code =int.Parse(this.QueryValue(configList, "QR_Code").Value);//二维码
            this.QR_Code_Road = this.QueryValue(configList, "QR_Code_Road").Value;//二维码路径
            this.QR_Code_Explain = this.QueryValue(configList, "QR_Code_Explain").Value;//二维码说明
            this.Print_Software_Name = this.QueryValue(configList, "Print_Software_Name").Value;//打印出软件名称
            
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
