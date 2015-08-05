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
    
    public partial class TableType
    {
        public TableType()
        {
            this.Table = new HashSet<Table>();
            this.TableTypeDetail = new HashSet<TableTypeDetail>();
        }
    
        public int TableTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int PeopleMin { get; set; }
        public int PeopleMax { get; set; }
        public string Prefix { get; set; }
        public int PriceType { get; set; }
        public int ServerfreeNax { get; set; }
        public int ServerfreeModel { get; set; }
        public int ConsumerMode { get; set; }
        public string ColorType { get; set; }
        public int ServerfreeAccountType { get; set; }
        public int Rate { get; set; }
        public int ServerfreeNum { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual ICollection<Table> Table { get; set; }
        public virtual ICollection<TableTypeDetail> TableTypeDetail { get; set; }
    }
}
