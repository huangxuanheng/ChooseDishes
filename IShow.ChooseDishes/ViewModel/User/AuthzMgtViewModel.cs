using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View.User;
using GalaSoft.MvvmLight.Command;
using IShow.ChooseDishes.Model.User;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel.User
{
    public class AuthzMgtViewModel:ViewModelBase,Lifecycle
    {

        public ObservableCollection<RoleModel> _Roles;

        public ObservableCollection<RoleModel> Roles {
            get {
                return _Roles ?? (_Roles = new ObservableCollection<RoleModel>());
            }
        }

        public AuthzMgtViewModel(IUserService _UserService)
        {
            this._UserService = _UserService;
            this.Initialize();
        }

        IUserService _UserService;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize() {
            Modules.Clear();
            Roles.Clear();
            DispatcherHelper.RunAsync(()=>{
                List<Role> roles = _UserService.QueryRoles();
                foreach (var r in roles) {
                    Roles.Add(new RoleModel(r));
                }

                List<Module> modules = _UserService.QueryModuleWithFunctions();
                
                foreach (var m in modules) {
                    var module = new ModuleModel(m);
                    
                    if (m.Function != null && m.Function.Count>0) {
                        List<FunctionModel> functions = new List<FunctionModel>();
                        foreach (var f in m.Function) {
                            functions.Add(new FunctionModel(f,0));
                        }
                        module.Functions = functions;
                    }
                    Modules.Add(module);
                }
            });
        
        }


        public ObservableCollection<FunctionModel> _Functions;

        public ObservableCollection<FunctionModel> Functions
        {
            get
            {
                return _Functions ?? (_Functions = new ObservableCollection<FunctionModel>());
            }
        }

        public ObservableCollection<ModuleModel> _Modules;

        public ObservableCollection<ModuleModel> Modules {
            get {
                return _Modules ?? (_Modules = new ObservableCollection<ModuleModel>()); 
            }
        }

        //新增页面
        EditRoleWindow aw { get; set; }
        //打开新增窗口
        RelayCommand _Add;
        public RelayCommand Add
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    _Rolexaml = new RoleBean();
                    aw = new EditRoleWindow();
                    aw.ShowDialog();
                }));
            }
        }
        //新增窗口绑定对象
        RoleBean _Rolexaml;
        public RoleBean Rolexaml
        {
            get
            {
                return _Rolexaml;
            }
            set
            {
                Set("Rolexaml", ref _Rolexaml, value);
            }
        }

        //新增窗口保存
        RelayCommand _AddWin;
        public RelayCommand AddWin
        {
            get
            {
                return _AddWin ?? (_AddWin = new RelayCommand(() =>
                {
                    String Name = _Rolexaml.Name;
                    String Description = _Rolexaml.Description;
                    int i = _UserService.AddRoleOutId(Name, Description);
                    Role r = new Role();
                    r.Name = Name;
                    r.RoleId = i;
                    Roles.Add(new RoleModel(r));
                    aw.Close();
                }));
            }
        }

        //角色选中事件
        RoleModel _SelectedRole;
        public RoleModel SelectedRole
        {
            get
            {
                return _SelectedRole;
            }
            set
            {
                Set("SelectedRole", ref _SelectedRole, value);
                if (_SelectedRole != null)
                {
                    List<RoleRefFunction> function = _UserService.QueryFunctionForRole(_SelectedRole.Id);
                    Modules.Clear();
                    List<Module> modules = _UserService.QueryModuleWithFunctions();
                    int selected = 0;
                    foreach (var m in modules)
                    {
                        var module = new ModuleModel(m);

                        if (m.Function != null && m.Function.Count > 0)
                        {
                            List<FunctionModel> functions = new List<FunctionModel>();
                            foreach (var f in m.Function)
                            {
                                foreach (var fun in function)
                                {
                                    if (f.Id == fun.FunctionId)
                                    {
                                        selected = 1;
                                    }

                                }
                                functions.Add(new FunctionModel(f, selected));
                                selected = 0;
                            }
                            module.Functions = functions;
                        }
                        Modules.Add(module);
                    }
                }


            }
        }

        //数据保存
        RelayCommand _Save;
        public RelayCommand Save
        {
            get
            {
                return _Save ?? (_Save = new RelayCommand(() =>
                {
                    if (SelectedRole == null) {
                        MessageBox.Show("请选择需要保存的角色！");
                    }
                    List<RoleRefFunction> function = _UserService.QueryFunctionForRole(_SelectedRole.Id);
                    foreach (var f in function)
                    {
                          _UserService.RevokeFunctionForRole(SelectedRole.Id, f.FunctionId);
                    }
                    

                    foreach(var m in Modules){
                      foreach(var f in m.Functions){
                          if (f.Selected == 1) {
                              _UserService.GrantFunctionForRole(SelectedRole.Id,f.Id);
                          }
                      }
                    }

                    MessageBox.Show("保存成功！");
                   

                }));
            }
        }

        //角色删除
        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    if (SelectedRole != null)
                    {
                        _UserService.DeleteRole(SelectedRole.Id);
                        List<RoleRefFunction> function = _UserService.QueryFunctionForRole(SelectedRole.Id);
                        foreach (var f in function)
                        {
                            _UserService.RevokeFunctionForRole(SelectedRole.Id, f.FunctionId);
                        }
                        Roles.RemoveAt(Roles.IndexOf(SelectedRole));
                        SelectedRole = null;
                        Initialize();
                    }
                    else
                    {
                        MessageBox.Show("请选择需要删除的折扣方案！");
                    }
                }));
            }
        }
       
    }
}
