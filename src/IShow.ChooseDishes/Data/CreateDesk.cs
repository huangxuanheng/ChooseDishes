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
    
    public partial class CreateDesk
    {
        public CreateDesk()
        {
            this.DeskDishes = new HashSet<DeskDishes>();
        }
    
        public int OrderId { get; set; }
        public string DeskNum { get; set; }
        public Nullable<int> Position { get; set; }
        public int Number { get; set; }
        public string ManualNumber { get; set; }
        public int PriceClass { get; set; }
        public string Server { get; set; }
        public string Assistant { get; set; }
        public string Remark { get; set; }
        public string PeriodTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string Property { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> PerDeskPrice { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual ICollection<DeskDishes> DeskDishes { get; set; }
    }
}
