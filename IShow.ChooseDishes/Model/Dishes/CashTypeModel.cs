using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IShow.ChooseDishes.Model
{
    public class CashTypeBean : ObservableObject, IEditableObject
    {
        public int Id { get; set; }
        string _Code;
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

        string _Name;
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
        int _CashBaseTypeId;
        public int CashBaseTypeId
        {
            get
            {
                return _CashBaseTypeId;
            }
            set
            {
                Set("CashBaseTypeId", ref _CashBaseTypeId, value);
            }
        }
        string _Keys;
        public string Keys
        {
            get
            {
                return _Keys;
            }
            set
            {
                Set("Keys", ref _Keys, value);
            }
        }
        int _UseingKeys;
        public int UseingKeys
        {
            get
            {
                return _UseingKeys;
            }
            set
            {
                Set("UseingKeys", ref _UseingKeys, value);
            }
        }
        int _IsScore = 0;
        public int IsScore
        {
            get
            {
                return _IsScore;
            }
            set
            {
                Set("IsScore", ref _IsScore, value);
            }
        }
        int _ReceptionUseing =1;
        public int ReceptionUseing
        {
            get
            {
                return _ReceptionUseing;
            }
            set
            {
                Set("ReceptionUseing", ref _ReceptionUseing, value);
            }
        }

        int _SupplierUsing =0 ;
        public int SupplierUsing
        {
            get
            {
                return _SupplierUsing;
            }
            set
            {
                Set("SupplierUsing", ref _SupplierUsing, value);
            }
        }
        int _LossesUsing=0;
        public int LossesUsing
        {
            get
            {
                return _LossesUsing;
            }
            set
            {
                Set("LossesUsing", ref _LossesUsing, value);
            }
        }

        int _RechargeUsing=0;
        public int RechargeUsing
        {
            get
            {
                return _RechargeUsing;
            }
            set
            {
                Set("RechargeUsing", ref _RechargeUsing, value);
            }
        }

        int _IsPaid = 0;
        public int IsPaid
        {
            get
            {
                return _IsPaid;
            }
            set
            {
                Set("IsPaid", ref _IsPaid, value);
            }
        }
        //
        int _IsBillIncome =0;
        public int IsBillIncome
        {
            get
            {
                return _IsBillIncome;
            }
            set
            {
                Set("IsBillIncome", ref _IsBillIncome, value);
            }
        }
        //Rate
        double _Rate = 0.00;
        public double Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                Set("Rate", ref _Rate, value);
            }
        }
        int? _KeepRecharge=0;
        public int? KeepRecharge
        {
            get
            {
                return _KeepRecharge;
            }
            set
            {
                Set("KeepRecharge", ref _KeepRecharge, value);
            }
        }
        //IsPrivilege
        int? _IsPrivilege=0;
        public int? IsPrivilege
        {
            get
            {
                return _IsPrivilege;
            }
            set
            {
                Set("IsPrivilege", ref _IsPrivilege, value);
            }
        }
        //AllDiscount
        int? _AllDiscount =0;
        public int? AllDiscount
        {
            get
            {
                return _AllDiscount;
            }
            set
            {
                Set("AllDiscount", ref _AllDiscount, value);
            }
        }
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
        //绑定支付类型
        String _CashBaseTypeName;
        public String CashBaseTypeName
        {
            get
            {
                return _CashBaseTypeName;
            }
            set
            {
                Set("CashBaseTypeName", ref _CashBaseTypeName, value);
            }
        }
        public CashTypeBean CreateCashTypeBean(CashType cashType)
        {
            this.AllDiscount = cashType.AllDiscount;
            this.CashBaseTypeId = cashType.CashBaseTypeId;
            this.Code = cashType.Code;
            this.CreateBy = cashType.CreateBy;
            this.CreateDatetime = cashType.CreateDatetime;
            this.Deleted = cashType.Deleted;
            this.Id = cashType.Id;
            this.IsBillIncome = cashType.IsBillIncome;
            this.IsPaid = cashType.IsPaid;
            this.IsPrivilege = cashType.IsPrivilege;
            this.IsScore = cashType.IsScore;
            this.KeepRecharge = cashType.KeepRecharge;
            this.Keys = cashType.Keys;
            this.LossesUsing = cashType.LossesUsing;
            this.Name = cashType.Name;
            this.Rate = cashType.Rate;
            this.ReceptionUseing = cashType.ReceptionUseing;
            this.RechargeUsing = cashType.RechargeUsing;
            this.Status = cashType.Status;
            this.SupplierUsing = cashType.SupplierUsing;
            this.UpdateBy = cashType.UpdateBy;
            this.UpdateDatetime = cashType.UpdateDatetime;
            this.UseingKeys = cashType.UseingKeys;
            this.CashBaseTypeName = TiQuName(cashType.CashBaseTypeId);
            return this;
        }

        public string TiQuName(int p)
        {
            switch(p)
            {
                case 1: return "现金";
                case 2: return "会员卡";
                case 3: return "银行卡";
                case 4: return "代金券";
                case 5: return "折让";
                case 6: return "其他";
                default: return "未知";
            };
        }
        public CashType CreateCashType(CashTypeBean cashType)
        {
            CashType ct = new CashType();
            ct.AllDiscount = cashType.AllDiscount;
            ct.CashBaseTypeId = cashType.CashBaseTypeId;
            ct.Code = cashType.Code;
            ct.CreateBy = cashType.CreateBy;
            ct.CreateDatetime = cashType.CreateDatetime;
            ct.Deleted = cashType.Deleted;
            ct.Id = cashType.Id;
            ct.IsBillIncome = cashType.IsBillIncome;
            ct.IsPaid = cashType.IsPaid;
            ct.IsPrivilege = cashType.IsPrivilege;
            ct.IsScore = cashType.IsScore;
            ct.KeepRecharge = cashType.KeepRecharge;
            ct.Keys = cashType.Keys;
            ct.LossesUsing = cashType.LossesUsing;
            ct.Name = cashType.Name;
            ct.Rate = cashType.Rate;
            ct.ReceptionUseing = cashType.ReceptionUseing;
            ct.RechargeUsing = cashType.RechargeUsing;
            ct.Status = cashType.Status;
            ct.SupplierUsing = cashType.SupplierUsing;
            ct.UpdateBy = cashType.UpdateBy;
            ct.UpdateDatetime = cashType.UpdateDatetime;
            ct.UseingKeys = cashType.UseingKeys;
            return ct;
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
