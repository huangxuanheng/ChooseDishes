using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.User
{
    public class RoleBean : ObservableObject
    {
        public int _RoleId;
        public int RoleId
        {
            get
            {
                return _RoleId;
            }
            set
            {
                Set("RoleId", ref _RoleId, value);
            }
        }

        public string _Name;
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

        public int _Deleted;
        public int Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                Set("Deleted", ref _Deleted, value);
            }
        }

        public string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                Set("Description", ref _Description, value);
            }
        }

        public System.DateTime _CreateDateTime;
        public System.DateTime CreateDateTime
        {
            get
            {
                return _CreateDateTime;
            }
            set
            {
                Set("CreateDateTime", ref _CreateDateTime, value);
            }
        }

        public Nullable<int> _CreateBy;
        public Nullable<int> CreateBy
        {
            get
            {
                return _CreateBy;
            }
            set
            {
                Set("CreateBy", ref _CreateBy, value);
            }
        }

        public Nullable<System.DateTime> _UpdateDatetime;
        public Nullable<System.DateTime> UpdateDatetime
        {
            get
            {
                return _UpdateDatetime;
            }
            set
            {
                Set("UpdateDatetime", ref _UpdateDatetime, value);
            }
        }

        public Nullable<int> _UpdateBy;
        public Nullable<int> UpdateBy
        {
            get
            {
                return _UpdateBy;
            }
            set
            {
                Set("UpdateBy", ref _UpdateBy, value);
            }
        }



        public RoleBean CreateRoleBean(Role bean)
        {
            this.RoleId = bean.RoleId;
            this.Name = bean.Name;
            this.Deleted = bean.Deleted;
            this.Description = bean.Description;
            this.CreateDateTime = bean.CreateDateTime;
            this.CreateBy = bean.CreateBy;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;

        }
        public Role CreateRole(RoleBean bean)
        {
            Role beanBack = new Role();
            beanBack.RoleId = bean.RoleId;
            beanBack.Name = bean.Name;
            beanBack.Deleted = bean.Deleted;
            beanBack.Description = bean.Description;
            beanBack.CreateDateTime = bean.CreateDateTime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            return beanBack;

        }

    }
}
