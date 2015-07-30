using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using IShow.Common.Log;

namespace IShow.ChooseDishes.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;

        #region Observable
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Set("Name", ref _Name, value);
            }
        }
        string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                Set("Password", ref _Password, value);
            }
        }
        #endregion Observable

        #region Command
        RelayCommand<int> _Input;
        public RelayCommand<int> Input
        {
            get
            {
                return _Input ?? (_Input = new RelayCommand<int>(num =>
                    {
                        Password += num.ToString();
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
                        Password = Password.Substring(0, Password.Length - 1);
                    },
                    () =>
                    {
                        return !string.IsNullOrEmpty(Password);
                    }));
            }
        }
        RelayCommand _Login;
        public RelayCommand Login
        {
            get
            {
                return _Login ?? (_Login = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
                    {
                        MessageBox.Show("请输入用户名和密码。");
                        return;
                    }
                   MessageBox.Show(string.Format("用户名：{0}   密码：{1}", Name, Password));
                  //  _DataService.Login(Name, Password);
                    Logger.Log(string.Format("Login done, name:{0}, password:{1}", Name, Password), LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        #endregion Command

        public LoginViewModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
        }
    }
}
