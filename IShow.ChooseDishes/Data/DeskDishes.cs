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
    
    public partial class DeskDishes
    {
        public DeskDishes()
        {
            this.DeskOrder = new HashSet<DeskOrder>();
            this.TimerProject = new HashSet<TimerProject>();
        }
    
        public int DeskDishesId { get; set; }
        public int TableId { get; set; }
        public string OrderId { get; set; }
        public int Take { get; set; }
        public int Merged { get; set; }
        public int Locked { get; set; }
        public int Timer { get; set; }
        public int DeskStatus { get; set; }
        public int OrderStatus { get; set; }
        public int UnionCount { get; set; }
        public int PartyCount { get; set; }
        public int Turn { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual CreateDesk CreateDesk { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<DeskOrder> DeskOrder { get; set; }
        public virtual ICollection<TimerProject> TimerProject { get; set; }
    }
}
