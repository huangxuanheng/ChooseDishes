using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class DepartmentBean : ObservableObject
    {
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

        public int _CompanyId;
        public int CompanyId
        {
            get
            {
                return _CompanyId;
            }
            set
            {
                Set("CompanyId", ref _CompanyId, value);
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



        public DepartmentBean CreateDepartmentInfoBean(DepartmentInfo bean)
        {
            this.DepartmentId = bean.DepartmentId;
            this.CompanyId = bean.CompanyId;
            this.DepartmentName = bean.DepartmentName;
            this.CreateTime = bean.CreateTime;
            this.CreateBy = bean.CreateBy;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            this.Deleted = bean.Deleted;
            return this;

        }
        public DepartmentInfo CreateDepartmentInfo(DepartmentBean bean)
        {
            DepartmentInfo beanBack = new DepartmentInfo();
            beanBack.DepartmentId = bean.DepartmentId;
            beanBack.CompanyId = bean.CompanyId;
            beanBack.DepartmentName = bean.DepartmentName;
            beanBack.CreateTime = bean.CreateTime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            beanBack.Deleted = bean.Deleted;
            return beanBack;

        }

    }
}
