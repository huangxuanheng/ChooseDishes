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
    
    public partial class CheckoutIinfoItem
    {
        public int Id { get; set; }
        public int pay_type { get; set; }
        public int pay_num { get; set; }
        public double money { get; set; }
        public double rmb_money { get; set; }
    
        public virtual CheckoutInfo CheckoutInfo { get; set; }
    }
}
