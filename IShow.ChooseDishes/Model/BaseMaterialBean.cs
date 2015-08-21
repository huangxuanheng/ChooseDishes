using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class BaseMaterialBean : ObservableObject, IEditableObject
    {
        int _Id;
        public int Id    //编号
        {
            get
            {
                return _Id;
            }
            set
            {
                Set("Id", ref _Id, value);
            }
        }
        string _Code;
        public string Code    //编号
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
        public string Name  //名称
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
        Nullable<int> _ParentRawId;
        public Nullable<int> ParentRawId   //类别
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
        int _CreateBy=SubjectUtils.GetAuthenticationId();
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
        public int Status
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
        public BaseMaterialBean CreateBaseMaterialBean(Raw bean)
        {
            this.Id = bean.RawId;
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
        /**根据传入的原料单位对象获取BaseMaterialBean对象*/
        public BaseMaterialBean CreateBaseMaterialBean(RawUnit bean)
        {
            this.Id = bean.UnitId;
            this.Name = bean.Name;
            this.CreateDatetime = bean.CreateDatetime;
            this.CreateBy = bean.CreateBy;
            this.Deleted = bean.Deleted;
            this.Status = bean.Status;
            this.UpdateDatetime = bean.UpdateDatetime;
            this.UpdateBy = bean.UpdateBy;
            return this;
        }
        /**根据传入的原料单位对象获取原料单位对象*/
        public RawUnit CreateRawUnitBean(BaseMaterialBean bean)
        {

            RawUnit beanBack = new RawUnit();
            beanBack.UnitId = bean.Id;
            beanBack.Name = bean.Name;
            beanBack.CreateDatetime = bean.CreateDatetime;
            beanBack.CreateBy = bean.CreateBy;
            beanBack.Deleted = bean.Deleted;
            beanBack.Status = bean.Status;
            beanBack.UpdateDatetime = bean.UpdateDatetime;
            beanBack.UpdateBy = bean.UpdateBy;
            return beanBack;
        }
        public Raw CreateRaw(BaseMaterialBean bean)
        {
            Raw beanBack= new Raw();
            beanBack.RawId = bean.Id;
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
        public bool IsModify { get; set; }
        public void BeginEdit()
        {
            IsModify = true;
        }

        public void CancelEdit()
        {
            IsModify = false;
        }

        public void EndEdit()
        {
            IsModify = true;
        }
    }
}
