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
    
    public partial class Employee
    {
        public Employee()
        {
            this.UserInfo = new HashSet<UserInfo>();
        }
    
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string JobNo { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public string Birthday { get; set; }
        public Nullable<int> Flag { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public int Deleted { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string ResidentialAddress { get; set; }
        public string IDAddress { get; set; }
        public string Remark { get; set; }
    
        public virtual DepartmentInfo DepartmentInfo { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}