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
    
    public partial class TimerProject
    {
        public int Id { get; set; }
        public int TimerNum { get; set; }
        public Nullable<int> DeskDishesId { get; set; }
        public string DeskNum { get; set; }
        public string TimerName { get; set; }
        public System.DateTime StartTimer { get; set; }
        public Nullable<System.DateTime> PauseTimer { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual DeskDishes DeskDishes { get; set; }
    }
}
