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
    
    public partial class PrintSet
    {
        public PrintSet()
        {
            this.BasicPrintPlan = new HashSet<BasicPrintPlan>();
        }
    
        public int Id { get; set; }
        public int PrintName { get; set; }
        public int TicketType { get; set; }
        public int BlankRow { get; set; }
        public int PrintNum { get; set; }
        public int FormatId { get; set; }
        public int CutType { get; set; }
        public int PrintRate { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int Deleted { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public string UpdateBy { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<BasicPrintPlan> BasicPrintPlan { get; set; }
        public virtual KitchenBillFormat KitchenBillFormat { get; set; }
    }
}
