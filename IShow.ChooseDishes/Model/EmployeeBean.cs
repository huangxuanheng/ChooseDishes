using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class EmployeeBean : ObservableObject
    {
        public int _UserId;
        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                Set("UserId", ref _UserId, value);
            }
        }

        public int _DepartmentId;
        public int DepartmentId
        {
            get
            {
                return _DepartmentId;
            }
            set
            {
                Set("DepartmentId", ref _DepartmentId, value);
            }
        }

        public string _JobNo;
        public string JobNo
        {
            get
            {
                return _JobNo;
            }
            set
            {
                Set("JobNo", ref _JobNo, value);
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

        public int _Sex;
        public int Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                Set("Sex", ref _Sex, value);
            }
        }

        public string _Birthday;
        public string Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                Set("Birthday", ref _Birthday, value);
            }
        }

        public Nullable<int> _Flag;
        public Nullable<int> Flag
        {
            get
            {
                return _Flag;
            }
            set
            {
                Set("Flag", ref _Flag, value);
            }
        }

        public string _Mobile;
        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                Set("Mobile", ref _Mobile, value);
            }
        }

        public string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                Set("Email", ref _Email, value);
            }
        }

        public System.DateTime _CreateTime;
        public System.DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                Set("CreateTime", ref _CreateTime, value);
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

        public string _Position;
        public string Position
        {
            get
            {
                return _Position;
            }
            set
            {
                Set("Position", ref _Position, value);
            }
        }

        public string _Phone;
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                Set("Phone", ref _Phone, value);
            }
        }

        public string _Code;
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                Set("Code", ref _Code, value);
            }
        }

        public string _ResidentialAddress;
        public string ResidentialAddress
        {
            get
            {
                return _ResidentialAddress;
            }
            set
            {
                Set("ResidentialAddress", ref _ResidentialAddress, value);
            }
        }

        public string _IDAddress;
        public string IDAddress
        {
            get
            {
                return _IDAddress;
            }
            set
            {
                Set("IDAddress", ref _IDAddress, value);
            }
        }

        public string _Remark;
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                Set("Remark", ref _Remark, value);
            }
        }

        private string _FlagVal;
        public string FlagVal
        {
            get
            {
                if (Flag == 1)
                {
                    return "离职";
                }
                else
                {
                    return "在职";
                }
            }
            set
            {
                _FlagVal = value;
            }
        }
        private string _SexVal;
        public string SexVal
        {
            get
            {
                if (Sex == 1)
                {
                    return "男";
                }
                else
                {
                    return "女";
                }
            }
            set
            {
                _SexVal = value;
            }
        }


        public string _DepartmentName;
        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                Set("DepartmentName", ref _DepartmentName, value);
            }
        }

        public EmployeeBean CreateEmployeeBean(Employee bean)
        {
            this.UserId = bean.UserId;
            this.DepartmentId = bean.DepartmentId;
            this.JobNo = bean.JobNo;
            this.Name = bean.Name;
            this.Sex = bean.Sex;
            this.Birthday = bean.Birthday;
            this.Flag = bean.Flag;
            this.Mobile = bean.Mobile;
            this.Email = bean.Email;
            this.CreateTime = bean.CreateTime;
            this.CreateBy = bean.CreateBy;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            this.Deleted = bean.Deleted;
            this.Position = bean.Position;
            this.Phone = bean.Phone;
            this.Code = bean.Code;
            this.ResidentialAddress = bean.ResidentialAddress;
            this.IDAddress = bean.IDAddress;
            this.Remark = bean.Remark;
            return this;

        }

        public static EmployeeBean Build(Employee employee)
        {
            EmployeeBean bean = new EmployeeBean();
            bean.UserId = employee.UserId;
            bean.DepartmentId = employee.DepartmentId;
            bean.JobNo = employee.JobNo;
            bean.Name = employee.Name;
            bean.Sex = employee.Sex;
            bean.Birthday = employee.Birthday;
            bean.Flag = employee.Flag;
            bean.Mobile = employee.Mobile;
            bean.Email = employee.Email;
            bean.CreateTime = employee.CreateTime;
            bean.CreateBy = employee.CreateBy;
            bean.UpdateDatetime = employee.UpdateDatetime;
            bean.UpdateBy = employee.UpdateBy;
            bean.Deleted = employee.Deleted;
            bean.Position = employee.Position;
            bean.Phone = employee.Phone;
            bean.Code = employee.Code;
            bean.ResidentialAddress = employee.ResidentialAddress;
            bean.IDAddress = employee.IDAddress;
            bean.Remark = employee.Remark;
            return bean;

        }
        public Employee CreateEmployee(EmployeeBean bean)
        {
            Employee beanBack = new Employee();
            beanBack.UserId = bean.UserId;
            beanBack.DepartmentId = bean.DepartmentId;
            beanBack.JobNo = bean.JobNo;
            beanBack.Name = bean.Name;
            beanBack.Sex = bean.Sex;
            beanBack.Birthday = bean.Birthday;
            beanBack.Flag = bean.Flag;
            beanBack.Mobile = bean.Mobile;
            beanBack.Email = bean.Email;
            beanBack.CreateTime = bean.CreateTime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            beanBack.Deleted = bean.Deleted;
            beanBack.Position = bean.Position;
            beanBack.Phone = bean.Phone;
            beanBack.Code = bean.Code;
            beanBack.ResidentialAddress = bean.ResidentialAddress;
            beanBack.IDAddress = bean.IDAddress;
            beanBack.Remark = bean.Remark;
            return beanBack;

        }



    }
}
