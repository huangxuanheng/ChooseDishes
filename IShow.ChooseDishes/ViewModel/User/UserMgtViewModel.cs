using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View.User;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.Model.EnumSet;
using IShow.ChooseDishes.ViewModel.Common;

namespace IShow.ChooseDishes.ViewModel.User
{
    /// <summary>
    /// 用户管理（操作员管理ViewModel）
    /// </summary>
    public class UserMgtViewModel:ViewModelBase
    {

        #region 按钮命令绑定
        public RelayCommand _AddCommand;
        public RelayCommand _UpdateCommand;
        public RelayCommand _RemoveCommand;
        public RelayCommand _ResetPwdCommand;
        public RelayCommand _EditPwdWin;
        public RelayCommand _SetPwdCommand;
        public RelayCommand _ExitCommand;
        public RelayCommand _RefreshCommand;
        public IUserService _UserService;
        public UserModel _SelectedUser;
      
        

        public UserMgtViewModel(IUserService _UserService) {
            this._UserService = _UserService;
        }


        public UserModel SelectedUser {
            get { 
                return _SelectedUser; 
            }
            set {
                Set("SelectedUser", ref _SelectedUser, value);
            }
        
        }
        public AddUserWindow AddWindow;
       

        public RelayCommand AddCommand {
            get
            {
                return _AddCommand ?? (_AddCommand = new RelayCommand(() =>
                {
                    AddWindow = new AddUserWindow();
                    bool? result = AddWindow.ShowDialog();
                  if (null != result && true == result) {
                      RefreshUsers();
                  }

                }));
            }
            private set { }
        
        }

        /// <summary>
        /// 刷新表格数据
        /// </summary>
        protected void RefreshUsers() {
            List<UserInfo> userInfo = _UserService.QueryUserRelations();
            Users.Clear();
            foreach (var u in userInfo)
            {
                
                UserModel user= new UserModel(u);
                user.PresentType = NameMapping.Presents[(PresentType)u.UserSaleRule.PresentType];
                Users.Add(user);
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                return _RefreshCommand ?? (_RefreshCommand = new RelayCommand(() =>{
                        RefreshUsers();
                }));
            }
            private set { }

        }

       public EditUserWindow EditWindow;
        public RelayCommand UpdateCommand
        {
            get
            {
                return _UpdateCommand ?? (_UpdateCommand = new RelayCommand(() =>
                {
                    if (null == SelectedUser) {
                        MessageBox.Show("请选择需要修改的操作员！");
                        return;
                    }
                    ViewModelDeliver.Set(SelectedUser);
                    EditWindow = new EditUserWindow();
                    bool? result = EditWindow.ShowDialog();
                    if (null != result && true == result)
                    {
                        RefreshUsers();
                    }

                }));
            }
            private set { }

        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return _RemoveCommand ?? (_RemoveCommand = new RelayCommand(() =>
                {
                    if (null == SelectedUser)
                    {
                        MessageBox.Show("请选择需要删除的操作员！");
                        return;
                    }
                    //删除用户
                    _UserService.Delete(SelectedUser.UserId);
                    //删除用户规则
                    _UserService.RemoveSaleRuleByUserId(SelectedUser.UserId);
                    //查看用户角色
                    List<UserRoleRef> userRole = FindWithRelation(SelectedUser.UserId);

                    if (userRole.Count > 0)
                    {
                        int[] roleid = new int[userRole.Count];
                        //收回用户角色
                        int i = 0;
                        foreach (var u in userRole)
                        {
                            roleid[i] = u.RoleId;
                            i++;
                        }
                        _UserService.Revoke(SelectedUser.UserId, roleid);
                    }

                    RefreshUsers();
                }));
            }
            private set { }

        }
        //查询用户角色
        public List<UserRoleRef> FindWithRelation(int UserId)
        {
            List<UserRoleRef> rule = _UserService.QueryRolesByUserId(UserId);
            if (rule == null)
            {
                rule = new List<UserRoleRef>();
            }
            return rule;
        }
        public RelayCommand ResetPwdCommand
        {
            get
            {
                return _ResetPwdCommand ?? (_ResetPwdCommand = new RelayCommand(() =>
                {

                }));
            }
            private set { }

        }

        public EditUserPwdWindow EditPwdWindow;
        public RelayCommand SetPwdCommand
        {
            get
            {
                return _SetPwdCommand ?? (_SetPwdCommand = new RelayCommand(() =>
                {
                    if (null == SelectedUser)
                    {
                        MessageBox.Show("请选择需要修改密码的操作员！");
                        return;
                    }
                    NewPassWord = null;
                    PassWord = null;
                    ViewModelDeliver.Set(SelectedUser);
                    EditPwdWindow = new EditUserPwdWindow();
                    EditPwdWindow.ShowDialog();
                }));
            }
            private set { }

        }


        public RelayCommand EditPwdWin
        {
            get
            {
                return _EditPwdWin ?? (_EditPwdWin = new RelayCommand(() =>
                {
                   object target = ViewModelDeliver.Get();
                   if (null != target && target is UserModel)
                   {
                       UserModel model = target as UserModel;
                       if(!NewPassWord.Equals(PassWord)){
                           MessageBox.Show("修改密码失败，两次密码不一致！");
                           return;
                       }
                       _UserService.ResetPasswd(model.UserId, CryptoUtils.MD5Encrypt(PassWord));

                       
                   }
                   else {
                       MessageBox.Show("修改密码失败，请联系管理员！");
                   }
                   EditPwdWindow.Close();
                   
                }));
            }
            private set { }

        }

        public RelayCommand ExitCommand
        {
            get
            {
                return _ExitCommand ?? (_ExitCommand = new RelayCommand(() =>
                {


                }));
            }
            private set { }

        }
        #endregion

        #region 集合绑定
        ObservableCollection<UserModel> _UserModels;

        public ObservableCollection<UserModel> Users
        {
            get {
                return _UserModels ??(_UserModels = new ObservableCollection<UserModel>());
            }
            set {
                Set("UserModel", ref _UserModels, value);
            }
        }
        #endregion

        #region 表单绑定
        private string _NewPassWord;
        private string _PassWord;

        public string NewPassWord
        {
            get
            {
                return _NewPassWord;
            }
            set
            {
                Set("NewPassWord", ref _NewPassWord, value);
            }
        }
        public string PassWord
        {
            get
            {
                return _PassWord;
            }
            set
            {
                Set("PassWord", ref _PassWord, value);
            }
        }
        #endregion

        /// <summary>
        /// 页面打开加载该方法
        /// </summary>
        public void Init()
        {
            DispatcherHelper.RunAsync(() => {
                RefreshUsers();
            });
        }
    }
}
