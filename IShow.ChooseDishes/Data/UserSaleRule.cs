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
    
    public partial class UserSaleRule
    {
        public int UserId { get; set; }
        public Nullable<double> DiscountAllowanceLimit { get; set; }
        public Nullable<double> DiscountLimit { get; set; }
        public Nullable<int> AlowanceType { get; set; }
        public Nullable<double> AllowanceLimit { get; set; }
        public Nullable<int> PresentType { get; set; }
        public Nullable<double> PresentLimit { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public int Deleted { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
    }
}
