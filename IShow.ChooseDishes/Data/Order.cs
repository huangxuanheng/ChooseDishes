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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderItem = new HashSet<OrderItem>();
        }
    
        public int OrderId { get; set; }
        public string OriginalNum { get; set; }
        public string OrderNo { get; set; }
        public string DiskIds { get; set; }
        public double Consume { get; set; }
        public double Discount { get; set; }
        public double Presented { get; set; }
        public double Service { get; set; }
        public double MinBalance { get; set; }
        public double Coupon { get; set; }
        public double Deposit { get; set; }
        public double EraseZero { get; set; }
        public double AvailableVoucher { get; set; }
        public double Receivable { get; set; }
        public int Paid { get; set; }
        public int MultiplePay { get; set; }
        public int TurnOver { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
