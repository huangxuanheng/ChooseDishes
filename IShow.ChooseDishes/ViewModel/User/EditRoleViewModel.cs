using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IShow.ChooseDishes.Api;

namespace IShow.ChooseDishes.ViewModel.User
{
    public class EditRoleViewModel:ViewModelBase
    {
        IUserService _UserService;

        public EditRoleViewModel(IUserService _UserService) {
            this._UserService = _UserService;
        }

        public string _Name;
        public string Name
        {
            get {
                return _Name;
            }
            set {
                Set("Name", ref _Name, value);
            }
        }

        public string _Description;

        public string Description
        {
            get {
                return _Description;
            }
            set {
                Set("Description", ref _Description, value);
            }
        }

        public RelayCommand _SaveCommand;

        public RelayCommand SaveCommand {
            get {
                return _SaveCommand ?? (_SaveCommand = new RelayCommand(() => {
                    _UserService.AddRole(Name, Description);

                    MessageBox.Show("保存角色成功！");
                }));
            
            }
        
        }
    }
}
