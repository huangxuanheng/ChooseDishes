using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model.ConfigModel;
using IShow.ChooseDishes.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IShow.ChooseDishes.ViewModel
{
    public class ConfigSettingViewModel : ViewModelBase
    {
        IConfigurationService _DataService;
        Hashtable configsTable;

        #region 实体对象
        //常规参数
        BasicConfig _BasicConfig;
        public BasicConfig BasicConfig
        {
            get { return _BasicConfig; }
            set { Set("BasicConfig", ref _BasicConfig, value); }
        }
        //点菜参数
        DishConfig _DishConfig;
        public DishConfig DishConfig
        {
            get { return _DishConfig; }
            set { Set("DishConfig", ref _DishConfig, value); }
        }
        //收银参数
        CashierConfig _CashierConfig;
        public CashierConfig CashierConfig
        {
            get { return _CashierConfig; }
            set { Set("CashierConfig", ref _CashierConfig, value); }
        }
        //账单参数
        BillConfig _BillConfig;
        public BillConfig BillConfig
        {
            get { return _BillConfig; }
            set { Set("BillConfig", ref _BillConfig, value); }
        }
        //总单参数
        BillTotalConfig _BillTotalConfig;
        public BillTotalConfig BillTotalConfig
        {
            get { return _BillTotalConfig; }
            set { Set("BillTotalConfig", ref _BillTotalConfig, value); }
        }
        //厨打参数
        KitchenPrintConfig _KitchenPrintConfig;
        public KitchenPrintConfig KitchenPrintConfig
        {
            get { return _KitchenPrintConfig; }
            set { Set("KitchenPrintConfig", ref _KitchenPrintConfig, value); }
        }

        
        #endregion

        #region 判断参数是否被修改
        //检测checkBox数值变化
        public void CheckCheckBoxValueChange(string name, bool? b){
            if (b != null)
            {
                Config config = _DataService.Find(name); ;
                string changeValue = string.Empty;
                if (b == true) { changeValue = "1"; }
                if (b == false) { changeValue = "0"; }
                if (!config.Value.Equals(changeValue))
                {
                    //判断该属性被改变，加入hashTable
                    configsTable.Add(name, changeValue);
                }
                else
                {
                    //该属性值被还原，判断hash表有无保存该值，有则移除
                    if (configsTable.Contains(name))
                    {
                        configsTable.Remove(name);
                    }
                }
            }
        }

        //检测textBox数值变化
        public void CheckTextValueChange(string name,string text)
        {
            Config config = _DataService.Find(name); ;
            string changeValue = text;
            if (!config.Value.Equals(changeValue))
            {
                if (configsTable.Contains(name))
                {
                    configsTable.Remove(name);
                    configsTable.Add(name, changeValue);
                }
                else
                {
                    configsTable.Add(name, changeValue);
                }
            }
            else
            {
                //该属性值被还原，判断hash表有无保存该值，有则移除
                if (configsTable.Contains(name))
                {
                    configsTable.Remove(name);
                }
            }
        }

        //检测checkBox数值变化
        public void CheckRadioButtonValueChange(string tag,string name)
        {
            Config config = _DataService.Find(tag);
            string changeValue = string.Empty;
            string[] sArray = name.Split(new char[1] { '_' });
            string strN = sArray[sArray.Length - 1];
            MessageBox.Show(strN);
            if (strN.Equals("One")) { changeValue = "1"; }
            if (strN.Equals("Two")) { changeValue = "2"; }
            if (strN.Equals("Three")) { changeValue = "3"; }
            if (strN.Equals("Four")) { changeValue = "4"; }
            if (strN.Equals("Five")) { changeValue = "5"; }

            if (!config.Value.Equals(changeValue))
            {
                configsTable.Add(tag, changeValue);
            }
            else
            {
                //该属性值被还原，判断hash表有无保存该值，有则移除
                if (configsTable.Contains(tag))
                {
                    configsTable.Remove(tag);
                }
            }
        }
        #endregion

        #region 保存/取消 参数配置操作
        RelayCommand _SaveConfigSetting;
        public RelayCommand SaveConfigSetting
        {
            get
            {
                return _SaveConfigSetting ?? (_SaveConfigSetting = new RelayCommand(() =>
                {
                    //MessageBox.Show("click confirm！！！");
                    try
                    {

                        _DataService.BatchUpdate(configsTable);
                        MessageBox.Show("保存成功");

                        configsTable.Clear();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }));
            }
        }

        RelayCommand _ResetConfigSetting;
        public RelayCommand ResetConfigSetting
        {
            get
            {
                return _ResetConfigSetting ?? (_ResetConfigSetting = new RelayCommand(() => { 
                    
                }));
            }
        }
        #endregion

        #region 初始化窗口
        public ConfigSettingViewModel(IConfigurationService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            configsTable = new Hashtable();
            List<Config> basicConfigList = new List<Config>();
            List<Config> dishConfigList = new List<Config>();
            List<Config> cashierConfigList = new List<Config>();
            List<Config> billConfigList = new List<Config>();
            List<Config> billTotalConfigList = new List<Config>();
            List<Config> kitchenPrintConfigList = new List<Config>();
            basicConfigList = _DataService.QueryByDomain("BasicConfig");
            dishConfigList = _DataService.QueryByDomain("DishConfig");
            cashierConfigList = _DataService.QueryByDomain("CashierConfig");
            billConfigList = _DataService.QueryByDomain("BillConfig");
            billTotalConfigList = _DataService.QueryByDomain("BillTotalConfig");
            kitchenPrintConfigList = _DataService.QueryByDomain("KitchenPrintConfig");
            BasicConfig basicConfig = new BasicConfig();
            DishConfig dishConfig = new DishConfig();
            CashierConfig cashierConfig = new CashierConfig();
            BillConfig billConfig = new BillConfig();
            BillTotalConfig billTotalConfig = new BillTotalConfig();
            KitchenPrintConfig kitchenPrintConfig = new KitchenPrintConfig();
            try
            {
                _BasicConfig = basicConfig.QueryBasicConfig(basicConfigList);
                _DishConfig = dishConfig.QueryDishConfig(dishConfigList);
                _CashierConfig = cashierConfig.QueryCashierConfig(cashierConfigList);
                _BillConfig = billConfig.QueryBillConfig(billConfigList);
                _BillTotalConfig = billTotalConfig.QueryBillTotalConfig(billTotalConfigList);
                _KitchenPrintConfig = kitchenPrintConfig.QueryKitchenPrintConfig(kitchenPrintConfigList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion
        
        
    }
}
