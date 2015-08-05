//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IShow.ChooseDishes.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShiftBill
    {
        public ShiftBill()
        {
            this.CheckoutInfo = new HashSet<CheckoutInfo>();
            this.ConsumeInfo = new HashSet<ConsumeInfo>();
            this.MemberRecharge = new HashSet<MemberRecharge>();
            this.RefundInfo = new HashSet<RefundInfo>();
            this.ShiftItem = new HashSet<ShiftItem>();
        }
    
        public int ShiftId { get; set; }
        public string ShiftNo { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string OperatorBy { get; set; }
        public string SucceedTo { get; set; }
        public double BackupMoney { get; set; }
        public double ShuldTurnOnMoney { get; set; }
        public double TurnOnCash { get; set; }
        public double Cdk { get; set; }
        public string Remark { get; set; }
        public int PayNum { get; set; }
        public double RmbPayMoney { get; set; }
        public double OperatingIncome { get; set; }
        public int TableNum { get; set; }
        public int CustNum { get; set; }
        public int BillNum { get; set; }
        public double ConsumeMoney { get; set; }
        public double DiscountMoney { get; set; }
        public double GiveMoney { get; set; }
        public double TruncationMoney { get; set; }
        public double Dxc { get; set; }
        public double FreeMoney { get; set; }
        public double ServeMoney { get; set; }
        public double ShouldPayTotal { get; set; }
        public double BillAverageConsume { get; set; }
        public double Djyj { get; set; }
        public double CustlAverageConsume { get; set; }
        public double Rjyj { get; set; }
        public int ShouldReleaseInvoice { get; set; }
        public int RealReleaseInvoice { get; set; }
        public double Deposit { get; set; }
        public double ReturnDeposit { get; set; }
    
        public virtual ICollection<CheckoutInfo> CheckoutInfo { get; set; }
        public virtual ICollection<ConsumeInfo> ConsumeInfo { get; set; }
        public virtual ICollection<MemberRecharge> MemberRecharge { get; set; }
        public virtual ICollection<RefundInfo> RefundInfo { get; set; }
        public virtual ICollection<ShiftItem> ShiftItem { get; set; }
    }
}
