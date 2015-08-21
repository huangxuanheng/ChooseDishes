using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class BeanBasis : ObservableObject
    {

        //CreateDatetime
        DateTime _CreateDatetime;
        public DateTime CreateDatetime
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
        //CreateBy
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
        //Deleted
        int _Deleted = 0;
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
        //Status
        int _Status = 0;
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
        //UpdateDatetime
        DateTime? _UpdateDatetime;
        public DateTime? UpdateDatetime
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
        //UpdateBy
        int? _UpdateBy;
        public int? UpdateBy
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
