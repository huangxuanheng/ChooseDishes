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
    
    public partial class CheckoutInfo
    {
        public CheckoutInfo()
        {
            this.CheckoutIinfoItem = new HashSet<CheckoutIinfoItem>();
        }
    
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int OperatorBy { get; set; }
        public string OperatorName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int TotalPayNum { get; set; }
        public double TotalMoney { get; set; }
        public double TotalRmbMoney { get; set; }
    
        public virtual ICollection<CheckoutIinfoItem> CheckoutIinfoItem { get; set; }
        public virtual ShiftBill ShiftBill { get; set; }
    }
}