using IShow.ChooseDishes.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.View.Common
{
    /// <summary>
    /// ParamenterSettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigSettingWindow : MetroWindow
    {
        ConfigSettingViewModel configViewModel;
        
        public ConfigSettingWindow()
        {
            InitializeComponent();
            //Label事件动作 MouseLeftButtonUp="TabItemHeader_ClientInfo_MouseLeftButtonUp"
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            configViewModel = this.DataContext as ConfigSettingViewModel;
            if (configViewModel != null) { 
                CheckBox chk = (CheckBox)sender;
                configViewModel.CheckCheckBoxValueChange(chk.Name, chk.IsChecked);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            configViewModel = this.DataContext as ConfigSettingViewModel;
            if (configViewModel != null)
            {
                TextBox chk = (TextBox)sender;
                if(chk.Name != null && !chk.Name.Equals("")){
                    configViewModel.CheckTextValueChange(chk.Name,chk.Text);
                }
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            configViewModel = this.DataContext as ConfigSettingViewModel;
            if (configViewModel != null)
            {
                RadioButton chk = (RadioButton)sender;
                string tag = string.Format("{0}", chk.Tag);
                if (tag != null && !tag.Equals(""))
                {
                    configViewModel.CheckRadioButtonValueChange(tag, chk.Name);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    configViewModel = this.DataContext as ConfigSettingViewModel;
        //    if (configViewModel != null)
        //    {
        //        configViewModel.QueryDishConfig();
        //    }
        //}
    }
}
