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
    /// 收银参数
    /// </summary>
    public partial class CashierConfig : ObservableObject
    {
        int _Compute_Mode;
        public int Compute_Mode
        {
            get { return _Compute_Mode; }
            set { Set("Compute_Mode", ref _Compute_Mode, value); }
        }

        int _Erase_Fraction_Set;
        public int Erase_Fraction_Set
        {
            get { return _Erase_Fraction_Set; }
            set { Set("Erase_Fraction_Set", ref _Erase_Fraction_Set, value); }
        }

        int _Round_Set;
        public int Round_Set
        {
            get { return _Round_Set; }
            set { Set("Round_Set", ref _Round_Set, value); }
        }

        int _Checkout_Grant_Invoive;
        public int Checkout_Grant_Invoive
        {
            get { return _Checkout_Grant_Invoive; }
            set { Set("Checkout_Grant_Invoive", ref _Checkout_Grant_Invoive, value); }
        }

        int _Paid_In_Amount_Invoive;
        public int Paid_In_Amount_Invoive
        {
            get { return _Paid_In_Amount_Invoive; }
            set { Set("Paid_In_Amount_Invoive", ref _Paid_In_Amount_Invoive, value); }
        }

        int _Pay_Full_Cash_Default;
        public int Pay_Full_Cash_Default
        {
            get { return _Pay_Full_Cash_Default; }
            set { Set("Pay_Full_Cash_Default", ref _Pay_Full_Cash_Default, value); }
        }

        string _Bill_Continuous_Copies_Num;
        public string Bill_Continuous_Copies_Num
        {
            get { return _Bill_Continuous_Copies_Num; }
            set { Set("Bill_Continuous_Copies_Num", ref _Bill_Continuous_Copies_Num, value); }
        }

        int _No_Preview_Printing;
        public int No_Preview_Printing
        {
            get { return _No_Preview_Printing; }
            set { Set("No_Preview_Printing", ref _No_Preview_Printing, value); }
        }

        int _Change_Display_Start;
        public int Change_Display_Start
        {
            get { return _Change_Display_Start; }
            set { Set("Change_Display_Start", ref _Change_Display_Start, value); }
        }

        int _Checkout_Printing;
        public int Checkout_Printing
        {
            get { return _Checkout_Printing; }
            set { Set("Checkout_Printing", ref _Checkout_Printing, value); }
        }

        int _Total_Order_Printing;
        public int Total_Order_Printing
        {
            get { return _Total_Order_Printing; }
            set { Set("Total_Order_Printing", ref _Total_Order_Printing, value); }
        }

        int _Checkout_Need_Select_Table;
        public int Checkout_Need_Select_Table
        {
            get { return _Checkout_Need_Select_Table; }
            set { Set("Checkout_Need_Select_Table", ref _Checkout_Need_Select_Table, value); }
        }

        #region 计算方式
        int _Compute_Mode_One;
        public int Compute_Mode_One
        {
            get { return _Compute_Mode_One; }
            set { Set("Compute_Mode_One", ref _Compute_Mode_One, value); }
        }
        int _Compute_Mode_Two;
        public int Compute_Mode_Two
        {
            get { return _Compute_Mode_Two; }
            set { Set("Compute_Mode_Two", ref _Compute_Mode_Two, value); }
        }
        int _Compute_Mode_Three;
        public int Compute_Mode_Three
        {
            get { return _Compute_Mode_Three; }
            set { Set("Compute_Mode_Three", ref _Compute_Mode_Three, value); }
        }
        #endregion

        #region 抹零设置
        int _Erase_Fraction_Set_One;
        public int Erase_Fraction_Set_One
        {
            get { return _Erase_Fraction_Set_One; }
            set { Set("Erase_Fraction_Set_One", ref _Erase_Fraction_Set_One, value); }
        }
        int _Erase_Fraction_Set_Two;
        public int Erase_Fraction_Set_Two
        {
            get { return _Erase_Fraction_Set_Two; }
            set { Set("Erase_Fraction_Set_Two", ref _Erase_Fraction_Set_Two, value); }
        }
        int _Erase_Fraction_Set_Three;
        public int Erase_Fraction_Set_Three
        {
            get { return _Erase_Fraction_Set_Three; }
            set { Set("Erase_Fraction_Set_Three", ref _Erase_Fraction_Set_Three, value); }
        }
        int _Erase_Fraction_Set_Four;
        public int Erase_Fraction_Set_Four
        {
            get { return _Erase_Fraction_Set_Four; }
            set { Set("Erase_Fraction_Set_Four", ref _Erase_Fraction_Set_Four, value); }
        }
        #endregion

        #region 四舍五入设置
        int _Round_Set_One;
        public int Round_Set_One
        {
            get { return _Round_Set_One; }
            set { Set("Round_Set_One", ref _Round_Set_One, value); }
        }
        int _Round_Set_Two;
        public int Round_Set_Two
        {
            get { return _Round_Set_Two; }
            set { Set("Round_Set_Two", ref _Round_Set_Two, value); }
        }
        int _Round_Set_Three;
        public int Round_Set_Three
        {
            get { return _Round_Set_Three; }
            set { Set("Round_Set_Three", ref _Round_Set_Three, value); }
        }
        int _Round_Set_Four;
        public int Round_Set_Four
        {
            get { return _Round_Set_Four; }
            set { Set("Round_Set_Four", ref _Round_Set_Four, value); }
        }
        #endregion

        public CashierConfig QueryCashierConfig(List<Config> configList)
        {
            //12
            this.Compute_Mode = int.Parse(this.QueryValue(configList, "Compute_Mode").Value);//计算方式
            this.Erase_Fraction_Set = int.Parse(this.QueryValue(configList, "Erase_Fraction_Set").Value);//抹零设置
            this.Round_Set = int.Parse(this.QueryValue(configList, "Round_Set").Value);//四舍五入设置
            this.Checkout_Grant_Invoive = int.Parse(this.QueryValue(configList, "Checkout_Grant_Invoive").Value);//埋单启用发票发放
            this.Paid_In_Amount_Invoive = int.Parse(this.QueryValue(configList, "Paid_In_Amount_Invoive").Value);//按实收金额发放发票
            this.Pay_Full_Cash_Default = int.Parse(this.QueryValue(configList, "Pay_Full_Cash_Default").Value);//现金默认付全款
            this.Bill_Continuous_Copies_Num = this.QueryValue(configList, "Bill_Continuous_Copies_Num").Value;//帐单连续打印份数
            this.No_Preview_Printing = int.Parse(this.QueryValue(configList, "No_Preview_Printing").Value);//本机结帐单直接打印（不预览）
            this.Change_Display_Start = int.Parse(this.QueryValue(configList, "Change_Display_Start").Value);//启用找零显示功能
            this.Checkout_Printing = int.Parse(this.QueryValue(configList, "Checkout_Printing").Value);//本机埋单打印帐单
            this.Total_Order_Printing = int.Parse(this.QueryValue(configList, "Total_Order_Printing").Value);//结帐后埋单打印结帐总单
            this.Checkout_Need_Select_Table = int.Parse(this.QueryValue(configList, "Checkout_Need_Select_Table").Value);//快餐结算必选餐桌
            
            //计算方式
            switch (this.Compute_Mode)
            {
                case 1:
                    this.Compute_Mode_One = 1;
                    this.Compute_Mode_Two = 0;
                    this.Compute_Mode_Three = 0;
                    break;
                case 2:
                    this.Compute_Mode_One = 0;
                    this.Compute_Mode_Two = 1;
                    this.Compute_Mode_Three = 0;
                    break;
                case 3:
                    this.Compute_Mode_One = 0;
                    this.Compute_Mode_Two = 0;
                    this.Compute_Mode_Three = 1;
                    break;
                default:
                    break;
            }
            //抹零设置
            switch (this.Erase_Fraction_Set)
            {
                case 1:
                    this.Erase_Fraction_Set_One = 1;
                    this.Erase_Fraction_Set_Two = 0;
                    this.Erase_Fraction_Set_Three = 0;
                    this.Erase_Fraction_Set_Four = 0;
                    break;
                case 2:
                    this.Erase_Fraction_Set_One = 0;
                    this.Erase_Fraction_Set_Two = 1;
                    this.Erase_Fraction_Set_Three = 0;
                    this.Erase_Fraction_Set_Four = 0;
                    break;
                case 3:
                    this.Erase_Fraction_Set_One = 0;
                    this.Erase_Fraction_Set_Two = 0;
                    this.Erase_Fraction_Set_Three = 1;
                    this.Erase_Fraction_Set_Four = 0;
                    break;
                case 4:
                    this.Erase_Fraction_Set_One = 0;
                    this.Erase_Fraction_Set_Two = 0;
                    this.Erase_Fraction_Set_Three = 0;
                    this.Erase_Fraction_Set_Four = 1;
                    break;
                default:
                    break;
            }
            //四舍五入设置
            switch (this.Round_Set)
            {
                case 1:
                    this.Round_Set_One = 1;
                    this.Round_Set_Two = 0;
                    this.Round_Set_Three = 0;
                    this.Round_Set_Four = 0;
                    break;
                case 2:
                    this.Round_Set_One = 0;
                    this.Round_Set_Two = 1;
                    this.Round_Set_Three = 0;
                    this.Round_Set_Four = 0;
                    break;
                case 3:
                    this.Round_Set_One = 0;
                    this.Round_Set_Two = 0;
                    this.Round_Set_Three = 1;
                    this.Round_Set_Four = 0;
                    break;
                case 4:
                    this.Round_Set_One = 0;
                    this.Round_Set_Two = 0;
                    this.Round_Set_Three = 0;
                    this.Round_Set_Four = 1;
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
