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
    
    public partial class DeskOrderMateria
    {
        public long Id { get; set; }
        public int DeskOrderId { get; set; }
        public string DishNum { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int Num { get; set; }
        public int Quit { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual DeskOrder DeskOrder { get; set; }
    }
}
