using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Model.ConfigModel
{
    /// <summary>
    /// 常规参数
    /// </summary>
    public partial class BasicConfig : ViewModelBase
    {
        int _Original_Default_Server;
        public int Original_Default_Server {
            get { return _Original_Default_Server; }
            set { Set("Original_Default_Server", ref _Original_Default_Server, value); }
        }

        int _Original_Original_Price;
        public int Original_Original_Price
        {
            get { return _Original_Original_Price; }
            set { Set("Original_Original_Price", ref _Original_Original_Price, value); }
        }

        string _Refresh_Rate;
        public string Refresh_Rate
        {
            get { return _Refresh_Rate; }
            set { Set("Refresh_Rate", ref _Refresh_Rate, value); }
        }

        string _Lock_Screen;
        public string Lock_Screen
        {
            get { return _Lock_Screen; }
            set { Set("Lock_Screen", ref _Lock_Screen, value); }
        }

        int _Is_Machine;
        public int Is_Machine
        {
            get { return _Is_Machine; }
            set { Set("Is_Machine", ref _Is_Machine, value); }
        }

        int _Is_Shortcut_Key;
        public int Is_Shortcut_Key
        {
            get { return _Is_Shortcut_Key; }
            set { Set("Is_Shortcut_Key", ref _Is_Shortcut_Key, value); }
        }

        int _Shift_Must_Successor;
        public int Shift_Must_Successor
        {
            get { return _Shift_Must_Successor; }
            set { Set("Shift_Must_Successor", ref _Shift_Must_Successor, value); }
        }

        int _Shift_Must_Cash;
        public int Shift_Must_Cash
        {
            get { return _Shift_Must_Cash; }
            set { Set("Shift_Must_Cash", ref _Shift_Must_Cash, value); }
        }

        int _Shift_blind;
        public int Shift_blind
        {
            get { return _Shift_blind; }
            set { Set("Shift_blind", ref _Shift_blind, value); }
        }

        int _Is_Tobe;
        public int Is_Tobe
        {
            get { return _Is_Tobe; }
            set { Set("Is_Tobe", ref _Is_Tobe, value); }
        }

        string _More_Than_Price;
        public string More_Than_Price
        {
            get { return _More_Than_Price; }
            set { Set("More_Than_Price", ref _More_Than_Price, value); }
        }

        int _Desk_No1;
        public int Desk_No1
        {
            get { return _Desk_No1; }
            set { Set("Desk_No1", ref _Desk_No1, value); }
        }

        int _Desk_No2;
        public int Desk_No2
        {
            get { return _Desk_No2; }
            set { Set("Desk_No2", ref _Desk_No2, value); }
        }

        string _Time_remind;
        public string Time_remind
        {
            get { return _Time_remind; }
            set { Set("Time_remind", ref _Time_remind, value); }
        }

        int _Sold_Out_Reason;
        public int Sold_Out_Reason
        {
            get { return _Sold_Out_Reason; }
            set { Set("Sold_Out_Reason", ref _Sold_Out_Reason, value); }
        }

        int _Skipper_Reason;
        public int Skipper_Reason
        {
            get { return _Skipper_Reason; }
            set { Set("Skipper_Reason", ref _Skipper_Reason, value); }
        }

        int _Present_Reason;
        public int Present_Reason
        {
            get { return _Present_Reason; }
            set { Set("Present_Reason", ref _Present_Reason, value); }
        }

        int _Dishes_Reason;
        public int Dishes_Reason
        {
            get { return _Dishes_Reason; }
            set { Set("Dishes_Reason", ref _Dishes_Reason, value); }
        }

        int _Return_Dishes_Reason;
        public int Return_Dishes_Reason
        {
            get { return _Return_Dishes_Reason; }
            set { Set("Return_Dishes_Reason", ref _Return_Dishes_Reason, value); }
        }
        
        //餐桌第一行第一项
        int _Desk_No1_One;
        public int Desk_No1_One
        {
            get { return _Desk_No1_One; }
            set { Set("Desk_No1_One", ref _Desk_No1_One, value); }
        }
        int _Desk_No1_Two;
        public int Desk_No1_Two
        {
            get { return _Desk_No1_Two; }
            set { Set("Desk_No1_Two", ref _Desk_No1_Two, value); }
        }
        int _Desk_No1_Three;
        public int Desk_No1_Three
        {
            get { return _Desk_No1_Three; }
            set { Set("Desk_No1_Three", ref _Desk_No1_Three, value); }
        }
        int _Desk_No1_Four;
        public int Desk_No1_Four
        {
            get { return _Desk_No1_Four; }
            set { Set("Desk_No1_Four", ref _Desk_No1_Four, value); }
        }
        int _Desk_No1_Five;
        public int Desk_No1_Five
        {
            get { return _Desk_No1_Five; }
            set { Set("Desk_No1_Five", ref _Desk_No1_Five, value); }
        }
        //餐桌第二行第一项
        int _Desk_No2_One;
        public int Desk_No2_One
        {
            get { return _Desk_No2_One; }
            set { Set("Desk_No2_One", ref _Desk_No2_One, value); }
        }
        int _Desk_No2_Two;
        public int Desk_No2_Two
        {
            get { return _Desk_No2_Two; }
            set { Set("Desk_No2_Two", ref _Desk_No2_Two, value); }
        }
        int _Desk_No2_Three;
        public int Desk_No2_Three
        {
            get { return _Desk_No2_Three; }
            set { Set("Desk_No2_Three", ref _Desk_No2_Three, value); }
        }
        int _Desk_No2_Four;
        public int Desk_No2_Four
        {
            get { return _Desk_No2_Four; }
            set { Set("Desk_No2_Four", ref _Desk_No2_Four, value); }
        }
        int _Desk_No2_Five;
        public int Desk_No2_Five
        {
            get { return _Desk_No2_Five; }
            set { Set("Desk_No2_Five", ref _Desk_No2_Five, value); }
        }

        public BasicConfig QueryBasicConfig(List<Config> configList) {
            //19
            this.Original_Default_Server = int.Parse(this.QueryValue(configList, "Original_Default_Server").Value);//本机开台操作默认登录员工
            this.Original_Original_Price = int.Parse(this.QueryValue(configList, "Original_Original_Price").Value);//本机开台选点菜价
            this.Refresh_Rate = this.QueryValue(configList, "Refresh_Rate").Value;//本机营业台刷新频率
            this.Lock_Screen = this.QueryValue(configList, "Lock_Screen").Value;//本机触屏自动锁屏间隔
            this.Is_Machine = int.Parse(this.QueryValue(configList, "Is_Machine").Value);//是否只查看本机数据
            this.Is_Shortcut_Key = int.Parse(this.QueryValue(configList, "Is_Shortcut_Key").Value);//本机前台界面是否显示快捷键
            this.Shift_Must_Successor = int.Parse(this.QueryValue(configList, "Shift_Must_Successor").Value);//交班必须接班人
            this.Shift_Must_Cash = int.Parse(this.QueryValue(configList, "Shift_Must_Cash").Value);//交班是否需要输入交班现金
            this.Shift_blind = int.Parse(this.QueryValue(configList, "Shift_blind").Value);//是否启用盲交功能
            this.Is_Tobe = int.Parse(this.QueryValue(configList, "Is_Tobe").Value);//预打账单启用餐桌待结状态。
            this.More_Than_Price = this.QueryValue(configList, "More_Than_Price").Value;//设置消费金额大于等于多少，餐桌界面特殊显示
            this.Desk_No1 = int.Parse(this.QueryValue(configList, "Desk_No1").Value);//餐桌显示第一行
            this.Desk_No2 = int.Parse(this.QueryValue(configList, "Desk_No2").Value);//餐桌显示第二行
            this.Time_remind = this.QueryValue(configList, "Time_remind").Value;//设置按时间单位收取服务费时提前多少分钟提醒
            this.Sold_Out_Reason = int.Parse(this.QueryValue(configList, "Sold_Out_Reason").Value);//沽清原因
            this.Skipper_Reason = int.Parse(this.QueryValue(configList, "Skipper_Reason").Value);//跑单原因
            this.Present_Reason = int.Parse(this.QueryValue(configList, "Present_Reason").Value);//赠送原因
            this.Dishes_Reason = int.Parse(this.QueryValue(configList, "Dishes_Reason").Value);//折扣原因
            this.Return_Dishes_Reason = int.Parse(this.QueryValue(configList, "Return_Dishes_Reason").Value);//退菜原因

            Console.WriteLine(string.Format("this.Desk_No1:{0}",this.Desk_No1));
            Console.WriteLine(string.Format("this.Desk_No2:{0}", this.Desk_No2));
            //餐桌第一行
            switch (this.Desk_No1)
            {
                case 1:
                    this.Desk_No1_One = 1;
                    this.Desk_No1_Two = 0;
                    this.Desk_No1_Three = 0;
                    this.Desk_No1_Four = 0;
                    this.Desk_No1_Five = 0;
                    break;
                case 2:
                    this.Desk_No1_One = 0;
                    this.Desk_No1_Two = 1;
                    this.Desk_No1_Three = 0;
                    this.Desk_No1_Four = 0;
                    this.Desk_No1_Five = 0;
                    break;
                case 3:
                    this.Desk_No1_One = 0;
                    this.Desk_No1_Two = 0;
                    this.Desk_No1_Three = 1;
                    this.Desk_No1_Four = 0;
                    this.Desk_No1_Five = 0;
                    break;
                case 4:
                    this.Desk_No1_One = 0;
                    this.Desk_No1_Two = 0;
                    this.Desk_No1_Three = 0;
                    this.Desk_No1_Four = 1;
                    this.Desk_No1_Five = 0;
                    break;
                case 5:
                    this.Desk_No1_One = 0;
                    this.Desk_No1_Two = 0;
                    this.Desk_No1_Three = 0;
                    this.Desk_No1_Four = 0;
                    this.Desk_No1_Five = 1;
                    break;
                default:
                    break;
            }
            //餐桌第二行
            switch (this.Desk_No2)
            {
                case 1:
                    this.Desk_No2_One = 1;
                    this.Desk_No2_Two = 0;
                    this.Desk_No2_Three = 0;
                    this.Desk_No2_Four = 0;
                    this.Desk_No2_Five = 0;
                    break;
                case 2:
                    this.Desk_No2_One = 0;
                    this.Desk_No2_Two = 1;
                    this.Desk_No2_Three = 0;
                    this.Desk_No2_Four = 0;
                    this.Desk_No2_Five = 0;
                    break;
                case 3:
                    this.Desk_No2_One = 0;
                    this.Desk_No2_Two = 0;
                    this.Desk_No2_Three = 1;
                    this.Desk_No2_Four = 0;
                    this.Desk_No2_Five = 0;
                    break;
                case 4:
                    this.Desk_No2_One = 0;
                    this.Desk_No2_Two = 0;
                    this.Desk_No2_Three = 0;
                    this.Desk_No2_Four = 1;
                    this.Desk_No2_Five = 0;
                    break;
                case 5:
                    this.Desk_No2_One = 0;
                    this.Desk_No2_Two = 0;
                    this.Desk_No2_Three = 0;
                    this.Desk_No2_Four = 0;
                    this.Desk_No2_Five = 1;
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
