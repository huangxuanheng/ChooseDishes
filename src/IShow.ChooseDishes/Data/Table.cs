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
    
    public partial class Table
    {
        public Nullable<int> TableTypeId { get; set; }
        public int TableId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> Seat { get; set; }
        public int LocationId { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual TableType TableType { get; set; }
    }
}
