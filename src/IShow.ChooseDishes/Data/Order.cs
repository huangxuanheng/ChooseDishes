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
    
        public int Id { get; set; }
        public int OrdeId { get; set; }
        public string DeskNum { get; set; }
        public int Consume { get; set; }
        public int Discount { get; set; }
        public int Presented { get; set; }
        public int Service { get; set; }
        public int MinBalance { get; set; }
        public int Coupon { get; set; }
        public int Deposit { get; set; }
        public int EraseZero { get; set; }
        public int AvailableVoucher { get; set; }
        public int Receivable { get; set; }
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
