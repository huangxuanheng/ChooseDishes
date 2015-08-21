using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class LockScreenViewModel : ViewModelBase
    {
        string aUserName = "zhangsan";
        string aPassword = "123456";

        public string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { Set("UserName", ref _UserName, value );}
        }
        public string _PassWord;
        public string PassWord
        {
            get { return _PassWord; }
            set { Set("PassWord", ref _PassWord, value); }
        }

        #region 数字键功能
        RelayCommand<int> _Input;
        public RelayCommand<int> Input
        {
            get
            {
                return _Input ?? (_Input = new RelayCommand<int>(num =>
                {
                    PassWord += num.ToString();
                }));
            }
        }
        RelayCommand _Small_Digit;
        public RelayCommand Small_Digit
        {
            get
            {
                return _Small_Digit ?? (_Small_Digit = new RelayCommand(() =>
                {
                    PassWord += ".";
                }));
            }
        }
        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    PassWord = PassWord.Substring(0, PassWord.Length - 1);
                },
                    () =>
                    {
                        return !string.IsNullOrEmpty(PassWord);
                    }));
            }
        }
        #endregion

        #region
        #endregion

        #region
        RelayCommand _LockScreenCommand;
        public RelayCommand LockScreenCommand
        {
            get
            {
                return _LockScreenCommand ?? (_LockScreenCommand = new RelayCommand(() =>
                {
                    
                }));
            }
        }
        #endregion

        public bool TestAccountInformation()
        {
            bool isSuccess = false;
            //if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(PassWord))
            //{
            //    MessageBox.Show("请输入用户名和密码。");
            //    return false;
            //}
            //MessageBox.Show(string.Format("UserName: {0} PassWord: {1}", UserName, PassWord));
            if (aUserName.Equals(UserName) && aPassword.Equals(PassWord))
            {
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
