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
    
    public partial class Role
    {
        public Role()
        {
            this.UserRoleRef = new HashSet<UserRoleRef>();
        }
    
        public int RoleId { get; set; }
        public string Name { get; set; }
        public int Deleted { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual ICollection<UserRoleRef> UserRoleRef { get; set; }
    }
}
