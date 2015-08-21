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
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.User;
using Microsoft.Practices.ServiceLocation;
using IShow.ChooseDishes.Model.EnumSet;

namespace IShow.ChooseDishes.ViewModel.User
{

    /// <summary>
    /// 编辑操作员
    /// </summary>
    public class AddUserViewModel:ViewModelBase,Lifecycle
    {
        #region 命令绑定
        RelayCommand _SelectEmployeeCommand;

        RelayCommand _SaveCommand;



        IUserService _UserService;

        //员工编号
        public int EmployeeId { get; set; }

        private int UserId{get;set;}

        public AddUserViewModel(IUserService _UserService) {
            this._UserService = _UserService;
        }

        public void Initialize() {
            //如果数据载体中存在数据，则为修改
            
            DoInitRolesModel();
        }

        protected void DoInitRolesModel()
        {
            DispatcherHelper.RunAsync(() => {
                Roles.Clear();
                //获取所有的角色
                List<Role> roles = _UserService.QueryRoles();
                foreach (var r in roles)
                {
                    Roles.Add(new RoleModel(r.RoleId, r.Name, r.Description, false));
                }
            
            });


        }

        public void CheckDirectGrantForUser(int roleId) {
            if (UserId>0) { 
                this._UserService.Grant(UserId, new int[]{roleId});
            }
            
        }

        public void CheckDirectRevokeForUser(int roleId)
        {
            if (UserId>0) {
                this._UserService.Revoke(UserId, new int[] { roleId });
            }
           

        }


        /// <summary>
        /// 初始化表单
        /// </summary>
        /// <param name="_EmpId"></param>
        protected void DoInitEmployeeForm(int empId,string name,string jobNo) {
            this.EmployeeId = empId;
            this.Name = name;
            this.JobNo = jobNo;
        }

        protected void DoInitSaleRuleForm(int _EmpId)
        {
            UserInfo info = _UserService.FindWithRelation(_EmpId);
            SetUserInfoAndRuleForForm(info);
            SetUserRoles(info);
        }

        /// <summary>
        /// 设置表单规则
        /// </summary>
        /// <param name="_UserInfo"></param>
        protected void SetUserInfoAndRuleForForm(UserInfo _UserInfo) {
            this.EmployeeId=_UserInfo.EmployeeId;
            this.Name=_UserInfo.Employee.Name;
        
        }


       /// <summary>
       /// 设置用户选择的权限
       /// </summary>
       /// <param name="_userInfo"></param>
        protected void SetUserRoles(UserInfo _userInfo) {
            var refs = _userInfo.UserRoleRef;
            foreach (var r in refs) {
                foreach (var t in Roles) {
                    if (t.Id == r.RoleId) {
                        t.Had = true;
                    }
                }
            }
        }

        protected int[] GetCheckedRoles() {
            List<int> checkedRoles = new List<int>();
            foreach (var r in Roles) {
                if (r.Had) {
                    checkedRoles.Add(r.Id);
                }
            }
            return checkedRoles.ToArray();
        
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new RelayCommand(() => { 

                    UserSaleRule rule = new UserSaleRule();
                    rule.DiscountLimit=DiscountLimit;
                    rule.PresentType =(int)PresentType;
                    rule.AlowanceType =(int)AllowanceType;
                    rule.PresentLimit=PresentLimit;
                    rule.AllowanceLimit = AllowanceLimit;
                    rule.DiscountAllowanceLimit = DiscountAllowance;
                    //添加用户
                   UserId= _UserService.Add(EmployeeId, this.JobNo, CryptoUtils.GetSalt());
                    //添加用户规则
                   _UserService.SaveOnUpdateForUserSaleRule(UserId, rule);
                    //对用户授权
                   if (GetCheckedRoles().Length > 0) {
                       _UserService.Grant(UserId, GetCheckedRoles());
                   }
                   MessageBox.Show("保存用户配置成功！");
                   UserMgtViewModel user = ServiceLocator.Current.GetInstance<UserMgtViewModel>();
                   user.AddWindow.Close();
                   user.Init();
                }));
            }
            private set { }

        }

        /// <summary>
        /// 修改用户的角色
        /// </summary>
        public void UpdateRoleForUserOnUpdated(RoleModel role) { 
        
        
        }

        public RelayCommand SelectEmployeeCommand
        {
            get
            {
                return _SelectEmployeeCommand ?? (_SelectEmployeeCommand = new RelayCommand(() => {
                    var window = new SelectEmpForUserWindow();
                    bool? result = window.ShowDialog();
                    //关闭，从本地线程变量中获取变量值
                    if (result != null && result==true) {
                        EmployeeBean employee = ViewModelDeliver.Get() as EmployeeBean;
                        if (null != employee) {
                            if (Compare(employee.UserId))
                            {
                                DoInitEmployeeForm(employee.UserId, employee.Name, employee.JobNo);
                             }
                            else {
                                MessageBox.Show("该用户已有操作员角色，请重新选择！");    
                            }
                        }
                    }
                }));
            }
            private set{
            }
        }

        /// <summary>
        /// 判断用户是否有操作员记录
        /// </summary>
        protected bool Compare(int id)
        {
            List<UserInfo> userInfo = _UserService.QueryUserRelations();
            
            foreach (var u in userInfo)
            {
                if (u.EmployeeId == id) {
                    return false;
                }
            }
            return true;
        }


        #endregion
        #region 表单绑定
        private string _Name;
        private double _DiscountLimit;
        private PresentType _PresentType;
        private double _PresentLimit;
        private AllowanceType _AllowanceType;
        private double _AllowanceLimit;
        private double _DiscountAllowance;

        private ObservableCollection<RoleModel> _Roles;

        public ObservableCollection<RoleModel> Roles {
            get {
                return _Roles ?? (_Roles = new ObservableCollection<RoleModel>());
            }
        }
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

        public double DiscountLimit
        {
            get
            {
                return _DiscountLimit;
            }
            set
            {
                Set("DiscountLimit", ref _DiscountLimit, value);
            }
        }
        public PresentType PresentType
        {
            get
            {
                return _PresentType;
            }
            set
            {
                Set("PresentType", ref _PresentType, value);
            }
        }
        public double PresentLimit
        {
            get
            {
                return _PresentLimit;
            }
            set
            {
                Set("PresentLimit", ref _PresentLimit, value);
            }
        }

        public AllowanceType AllowanceType
        {
            get
            {
                return _AllowanceType;
            }
            set
            {
                Set("AllowanceType", ref _AllowanceType, value);
            }
        }
        public double AllowanceLimit
        {
            get
            {
                return _AllowanceLimit;
            }
            set
            {
                Set("AllowanceLimit", ref _AllowanceLimit, value);
            }
        }
        public double DiscountAllowance
        {
            get
            {
                return _DiscountAllowance;
            }
            set
            {
                Set("DiscountAllowance", ref _DiscountAllowance, value);
            }
        }
        

        public string _JobNo;

        public string  JobNo
        {
            get {
                return _JobNo;
            }
            set {
                Set("JobNo", ref _JobNo, value);
            }
        }

        


        #endregion

    }
}
