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
    
    public partial class RechargeItem
    {
        public int Id { get; set; }
        public int RechargeId { get; set; }
        public int PayTypeId { get; set; }
        public int PayTypeName { get; set; }
        public int PayNum { get; set; }
        public double RechargeMoney { get; set; }
        public double PayMoney { get; set; }
    
        public virtual MemberRecharge MemberRecharge { get; set; }
    }
}
