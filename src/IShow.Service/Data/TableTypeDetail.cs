//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IShow.Service.Data
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    [DataContract(Namespace = "www.IShow.com", IsReference = true)]
    public partial class TableTypeDetail
    {
        [DataMember]
        public int TableTypeDetailId { get; set; }
        [DataMember]
        public Nullable<int> TableTypeId { get; set; }
        [DataMember]
        public Nullable<int> DataType { get; set; }
        [DataMember]
        public Nullable<int> AccountType { get; set; }
        [DataMember]
        public int ConsumerMode { get; set; }
        [DataMember]
        public Nullable<int> StartUnit { get; set; }
        [DataMember]
        public Nullable<System.DateTime> StartEnd { get; set; }
        [DataMember]
        public Nullable<double> OutMoney { get; set; }
        [DataMember]
        public Nullable<int> OutTime { get; set; }
        [DataMember]
        public Nullable<int> StartMoney { get; set; }
        [DataMember]
        public int ConsumerMoney { get; set; }
        [DataMember]
        public Nullable<int> StartGetMoneyTime { get; set; }
        [DataMember]
        public int ServerfreeNax { get; set; }
        [DataMember]
        public Nullable<int> OutTimeFree { get; set; }
        [DataMember]
        public System.DateTime CreateDatetime { get; set; }
        [DataMember]
        public int CreateBy { get; set; }
        [DataMember]
        public int Deleted { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        [DataMember]
        public Nullable<int> UpdateBy { get; set; }
    
        [DataMember]
        public virtual TableType TableType { get; set; }
    }
}
