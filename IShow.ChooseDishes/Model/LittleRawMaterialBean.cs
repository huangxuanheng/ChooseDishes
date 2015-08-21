using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    [DataContract(Namespace = "www.IShow.com", IsReference = true)]
    public class LittleRawMaterialBean : ObservableObject
    {
        int _RawId;
        public int RawId   //类别id
        {
            get
            {
                return _RawId;
            }
            set
            {
                Set("RawId", ref _RawId, value);
            }
        }
        string _Code;
        public string Code  //类别名称
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
        string _Name; 
        public string Name  //类别名称
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
        string _ParentRaw;
        public string ParentRaw  //父类名称
        {
            get
            {
                return _ParentRaw;
            }
            set
            {
                Set("ParentRaw", ref _ParentRaw, value);
            }
        }
        
        Nullable<int> _ParentRawId;
        public Nullable<int> ParentRawId   //父级类别  null或者0为父级 ，1为小类
        {
            get
            {
                return _ParentRawId;
            }
            set
            {
                Set("ParentRawId", ref _ParentRawId, value);
            }
        }
        System.DateTime _CreateDatetime;
        public System.DateTime CreateDatetime
        {
            get
            {
                return _CreateDatetime;
            }
            set
            {
                Set("CreateDatetime", ref _CreateDatetime, value);
            }
        }
        int _CreateBy;
        public int CreateBy
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
        int _Deleted;
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
        int _Status;
        public int Status   //状态
        {
            get
            {
                return _Status;
            }
            set
            {
                Set("Status", ref _Status, value);
            }
        }
        Nullable<System.DateTime> _UpdateDatetime;
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
        Nullable<int> _UpdateBy;
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
        public LittleRawMaterialBean CreateLittleRawMaterialBean(Raw bean)
        {
            this.RawId = bean.RawId;
            this.Name = bean.Name;
            this.ParentRawId = bean.ParentRawId;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;
        }
        public Raw CreateRaw(LittleRawMaterialBean bean)
        {
            Raw beanBack= new Raw();
            beanBack.RawId=bean.RawId;
            beanBack.Name=bean.Name;
            beanBack.ParentRawId=bean.ParentRawId;
            beanBack.CreateDatetime=bean.CreateDatetime;
            beanBack.CreateBy=bean.CreateBy;
            beanBack.Deleted=bean.Deleted;
            beanBack.Status=bean.Status;
            beanBack.UpdateDatetime=bean.UpdateDatetime;
            beanBack.UpdateBy=bean.UpdateBy;
            return beanBack;
}
    }
}
