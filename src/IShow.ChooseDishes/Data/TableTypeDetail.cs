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
    
    public partial class TableTypeDetail
    {
        public int TableTypeDetailId { get; set; }
        public int TableTypeId { get; set; }
        public int DataType { get; set; }
        public Nullable<int> ConsumerMode { get; set; }
        public Nullable<int> StartUnit { get; set; }
        public Nullable<System.DateTime> StartDateTime { get; set; }
        public Nullable<double> OutMoney { get; set; }
        public Nullable<int> OutTime { get; set; }
        public Nullable<int> StartMoney { get; set; }
        public Nullable<int> ConsumerMoney { get; set; }
        public Nullable<int> StartGetMoneyTime { get; set; }
        public Nullable<int> OutTimeFree { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> EndDateTime { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<int> ServerfreeNum { get; set; }
        public Nullable<int> ServerfreeAccountType { get; set; }
        public Nullable<int> ServerfreeNax { get; set; }
    
        public virtual TableType TableType { get; set; }
    }
}
