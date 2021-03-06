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
    
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.UserRoleRef = new HashSet<UserRoleRef>();
        }
    
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public int Deleted { get; set; }
        public string Salt { get; set; }
        public int Disabled { get; set; }
        public int Expired { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<UserRoleRef> UserRoleRef { get; set; }
        public virtual UserSaleRule UserSaleRule { get; set; }
    }
}
