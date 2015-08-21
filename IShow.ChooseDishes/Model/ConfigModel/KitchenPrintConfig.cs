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
    /// 厨打参数
    /// </summary>
    public partial class KitchenPrintConfig : ObservableObject
    {
        int _Call_Up_Print_Set;
        public int Call_Up_Print_Set
        {
            get { return _Call_Up_Print_Set; }
            set { Set("Call_Up_Print_Set", ref _Call_Up_Print_Set, value); }
        }

        int _Table_Reminder_Dishes_Print_Set;
        public int Table_Reminder_Dishes_Print_Set
        {
            get { return _Table_Reminder_Dishes_Print_Set; }
            set { Set("Table_Reminder_Dishes_Print_Set", ref _Table_Reminder_Dishes_Print_Set, value); }
        }

        int _Change_Table_Print_Set;
        public int Change_Table_Print_Set
        {
            get { return _Change_Table_Print_Set; }
            set { Set("Change_Table_Print_Set", ref _Change_Table_Print_Set, value); }
        }

        int _Change_Table_Produce_Print_Set;
        public int Change_Table_Produce_Print_Set
        {
            get { return _Change_Table_Produce_Print_Set; }
            set { Set("Change_Table_Produce_Print_Set", ref _Change_Table_Produce_Print_Set, value); }
        }

        int _Delivery_Noprint;
        public int Delivery_Noprint
        {
            get { return _Delivery_Noprint; }
            set { Set("Delivery_Noprint", ref _Delivery_Noprint, value); }
        }

        int _Dishes_Immediately_Weigh;
        public int Dishes_Immediately_Weigh
        {
            get { return _Dishes_Immediately_Weigh; }
            set { Set("Dishes_Immediately_Weigh", ref _Dishes_Immediately_Weigh, value); }
        }

        int _Hang_Print;
        public int Hang_Print
        {
            get { return _Hang_Print; }
            set { Set("Hang_Print", ref _Hang_Print, value); }
        }

        int _Dishes_Weigh_Order_Noprint;
        public int Dishes_Weigh_Order_Noprint
        {
            get { return _Dishes_Weigh_Order_Noprint; }
            set { Set("Dishes_Weigh_Order_Noprint", ref _Dishes_Weigh_Order_Noprint, value); }
        }

        int _After_Dishes_Weigh_Print;
        public int After_Dishes_Weigh_Print
        {
            get { return _After_Dishes_Weigh_Print; }
            set { Set("After_Dishes_Weigh_Print", ref _After_Dishes_Weigh_Print, value); }
        }

        int _Retreat_Food_Noprint;
        public int Retreat_Food_Noprint
        {
            get { return _Retreat_Food_Noprint; }
            set { Set("Retreat_Food_Noprint", ref _Retreat_Food_Noprint, value); }
        }

        int _Dishes_Weigh_Order_Print;
        public int Dishes_Weigh_Order_Print
        {
            get { return _Dishes_Weigh_Order_Print; }
            set { Set("Dishes_Weigh_Order_Print", ref _Dishes_Weigh_Order_Print, value); }
        }

        int _Hang_Dishes_Retreat_Noprint;
        public int Hang_Dishes_Retreat_Noprint
        {
            get { return _Hang_Dishes_Retreat_Noprint; }
            set { Set("Hang_Dishes_Retreat_Noprint", ref _Hang_Dishes_Retreat_Noprint, value); }
        }

        int _Many_Table_Print_One;
        public int Many_Table_Print_One
        {
            get { return _Many_Table_Print_One; }
            set { Set("Many_Table_Print_One", ref _Many_Table_Print_One, value); }
        }

        int _Afte_Temporarily_Print;
        public int Afte_Temporarily_Print
        {
            get { return _Afte_Temporarily_Print; }
            set { Set("Afte_Temporarily_Print", ref _Afte_Temporarily_Print, value); }
        }

        int _Temporarily_Retreat_Noprint;
        public int Temporarily_Retreat_Noprint
        {
            get { return _Temporarily_Retreat_Noprint; }
            set { Set("Temporarily_Retreat_Noprint", ref _Temporarily_Retreat_Noprint, value); }
        }

        #region 叫起厨打设置
        int _Call_Up_Print_Set_One;
        public int Call_Up_Print_Set_One
        {
            get { return _Call_Up_Print_Set_One; }
            set { Set("Call_Up_Print_Set_One", ref _Call_Up_Print_Set_One, value); }
        }
        int _Call_Up_Print_Set_Two;
        public int Call_Up_Print_Set_Two
        {
            get { return _Call_Up_Print_Set_Two; }
            set { Set("Call_Up_Print_Set_Two", ref _Call_Up_Print_Set_Two, value); }
        }
        int _Call_Up_Print_Set_Three;
        public int Call_Up_Print_Set_Three
        {
            get { return _Call_Up_Print_Set_Three; }
            set { Set("Call_Up_Print_Set_Three", ref _Call_Up_Print_Set_Three, value); }
        }
        #endregion

        #region 整桌催菜打印设置
        int _Table_Reminder_Dishes_Print_Set_One;
        public int Table_Reminder_Dishes_Print_Set_One
        {
            get { return _Table_Reminder_Dishes_Print_Set_One; }
            set { Set("Table_Reminder_Dishes_Print_Set_One", ref _Table_Reminder_Dishes_Print_Set_One, value); }
        }
        int _Table_Reminder_Dishes_Print_Set_Two;
        public int Table_Reminder_Dishes_Print_Set_Two
        {
            get { return _Table_Reminder_Dishes_Print_Set_Two; }
            set { Set("Table_Reminder_Dishes_Print_Set_Two", ref _Table_Reminder_Dishes_Print_Set_Two, value); }
        }
        int _Table_Reminder_Dishes_Print_Set_Three;
        public int Table_Reminder_Dishes_Print_Set_Three
        {
            get { return _Table_Reminder_Dishes_Print_Set_Three; }
            set { Set("Table_Reminder_Dishes_Print_Set_Three", ref _Table_Reminder_Dishes_Print_Set_Three, value); }
        }
        #endregion

        #region 转台厨打设置
        int _Change_Table_Print_Set_One;
        public int Change_Table_Print_Set_One
        {
            get { return _Change_Table_Print_Set_One; }
            set { Set("Change_Table_Print_Set_One", ref _Change_Table_Print_Set_One, value); }
        }
        int _Change_Table_Print_Set_Two;
        public int Change_Table_Print_Set_Two
        {
            get { return _Change_Table_Print_Set_Two; }
            set { Set("Change_Table_Print_Set_Two", ref _Change_Table_Print_Set_Two, value); }
        }
        int _Change_Table_Print_Set_Three;
        public int Change_Table_Print_Set_Three
        {
            get { return _Change_Table_Print_Set_Three; }
            set { Set("Change_Table_Print_Set_Three", ref _Change_Table_Print_Set_Three, value); }
        }
        #endregion

        #region 转台出品打印设置
        int _Change_Table_Produce_Print_Set_One;
        public int Change_Table_Produce_Print_Set_One
        {
            get { return _Change_Table_Produce_Print_Set_One; }
            set { Set("Change_Table_Produce_Print_Set_One", ref _Change_Table_Produce_Print_Set_One, value); }
        }
        int _Change_Table_Produce_Print_Set_Two;
        public int Change_Table_Produce_Print_Set_Two
        {
            get { return _Change_Table_Produce_Print_Set_Two; }
            set { Set("Change_Table_Produce_Print_Set_Two", ref _Change_Table_Produce_Print_Set_Two, value); }
        }
        int _Change_Table_Produce_Print_Set_Three;
        public int Change_Table_Produce_Print_Set_Three
        {
            get { return _Change_Table_Produce_Print_Set_Three; }
            set { Set("Change_Table_Produce_Print_Set_Three", ref _Change_Table_Produce_Print_Set_Three, value); }
        }
        #endregion

        public KitchenPrintConfig QueryKitchenPrintConfig(List<Config> configList)
        {
            //23
            this.Call_Up_Print_Set = int.Parse(this.QueryValue(configList, "Call_Up_Print_Set").Value);//叫起厨打设置
            this.Table_Reminder_Dishes_Print_Set = int.Parse(this.QueryValue(configList, "Table_Reminder_Dishes_Print_Set").Value);//整桌催菜打印设置
            this.Change_Table_Print_Set = int.Parse(this.QueryValue(configList, "Change_Table_Print_Set").Value);//转台厨打打印设置
            this.Change_Table_Produce_Print_Set = int.Parse(this.QueryValue(configList, "Change_Table_Produce_Print_Set").Value);//转台出品打印设置
            this.Delivery_Noprint = int.Parse(this.QueryValue(configList, "Delivery_Noprint").Value);//外送不执行厨打
            this.Dishes_Immediately_Weigh = int.Parse(this.QueryValue(configList, "Dishes_Immediately_Weigh").Value);//称重菜品点菜立即称重确认（单台）
            this.Hang_Print = int.Parse(this.QueryValue(configList, "Hang_Print").Value);//挂起厨打
            this.Dishes_Weigh_Order_Noprint = int.Parse(this.QueryValue(configList, "Dishes_Weigh_Order_Noprint").Value);//称重菜品落单不厨打
            this.After_Dishes_Weigh_Print = int.Parse(this.QueryValue(configList, "After_Dishes_Weigh_Print").Value);//称重后厨打
            this.Retreat_Food_Noprint = int.Parse(this.QueryValue(configList, "Retreat_Food_Noprint").Value);//退菜不厨打
            this.Dishes_Weigh_Order_Print = int.Parse(this.QueryValue(configList, "Dishes_Weigh_Order_Print").Value);//称重菜品首次落单打通知单
            this.Hang_Dishes_Retreat_Noprint = int.Parse(this.QueryValue(configList, "Hang_Dishes_Retreat_Noprint").Value);//挂起菜品退菜不厨打
            this.Many_Table_Print_One = int.Parse(this.QueryValue(configList, "Many_Table_Print_One").Value);//多台点菜厨打出品只打印一张
            this.Afte_Temporarily_Print = int.Parse(this.QueryValue(configList, "Afte_Temporarily_Print").Value);//暂结后需要进行厨打
            this.Temporarily_Retreat_Noprint = int.Parse(this.QueryValue(configList, "Temporarily_Retreat_Noprint").Value);//暂结退菜不进行厨打

            Console.WriteLine(string.Format("this.Call_Up_Print_Set:{0}", this.Call_Up_Print_Set));
            //叫起厨打设置
            switch (this.Call_Up_Print_Set)
            {
                case 1:
                    this.Call_Up_Print_Set_One = 1;
                    this.Call_Up_Print_Set_Two = 0;
                    this.Call_Up_Print_Set_Three = 0;
                    break;
                case 2:
                    this.Call_Up_Print_Set_One = 0;
                    this.Call_Up_Print_Set_Two = 1;
                    this.Call_Up_Print_Set_Three = 0;
                    break;
                case 3:
                    this.Call_Up_Print_Set_One = 0;
                    this.Call_Up_Print_Set_Two = 0;
                    this.Call_Up_Print_Set_Three = 1;
                    break;
                default:
                    break;
            }
            //整桌催菜打印设置
            switch (this.Table_Reminder_Dishes_Print_Set)
            {
                case 1:
                    this.Table_Reminder_Dishes_Print_Set_One = 1;
                    this.Table_Reminder_Dishes_Print_Set_Two = 0;
                    this.Table_Reminder_Dishes_Print_Set_Three = 0;
                    break;
                case 2:
                    this.Table_Reminder_Dishes_Print_Set_One = 0;
                    this.Table_Reminder_Dishes_Print_Set_Two = 1;
                    this.Table_Reminder_Dishes_Print_Set_Three = 0;
                    break;
                case 3:
                    this.Table_Reminder_Dishes_Print_Set_One = 0;
                    this.Table_Reminder_Dishes_Print_Set_Two = 0;
                    this.Table_Reminder_Dishes_Print_Set_Three = 1;
                    break;
                default:
                    break;
            }
            //转台厨打打印设置
            switch (this.Change_Table_Print_Set)
            {
                case 1:
                    this.Change_Table_Print_Set_One = 1;
                    this.Change_Table_Print_Set_Two = 0;
                    this.Change_Table_Print_Set_Three = 0;
                    break;
                case 2:
                    this.Change_Table_Print_Set_One = 0;
                    this.Change_Table_Print_Set_Two = 1;
                    this.Change_Table_Print_Set_Three = 0;
                    break;
                case 3:
                    this.Change_Table_Print_Set_One = 0;
                    this.Change_Table_Print_Set_Two = 0;
                    this.Change_Table_Print_Set_Three = 1;
                    break;
                default:
                    break;
            }
            //转台出品打印设置
            switch (this.Change_Table_Produce_Print_Set)
            {
                case 1:
                    this.Change_Table_Produce_Print_Set_One = 1;
                    this.Change_Table_Produce_Print_Set_Two = 0;
                    this.Change_Table_Produce_Print_Set_Three = 0;
                    break;
                case 2:
                    this.Change_Table_Produce_Print_Set_One = 0;
                    this.Change_Table_Produce_Print_Set_Two = 1;
                    this.Change_Table_Produce_Print_Set_Three = 0;
                    break;
                case 3:
                    this.Change_Table_Produce_Print_Set_One = 0;
                    this.Change_Table_Produce_Print_Set_Two = 0;
                    this.Change_Table_Produce_Print_Set_Three = 1;
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
