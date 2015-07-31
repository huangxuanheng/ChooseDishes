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
    public partial class CashType
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int CashBaseTypeId { get; set; }
        [DataMember]
        public int UseingKeys { get; set; }
        [DataMember]
        public string Keys { get; set; }
        [DataMember]
        public int IsScore { get; set; }
        [DataMember]
        public int ReceptionUseing { get; set; }
        [DataMember]
        public int SupplierUsing { get; set; }
        [DataMember]
        public int LossesUsing { get; set; }
        [DataMember]
        public int RechargeUsing { get; set; }
        [DataMember]
        public int IsPaid { get; set; }
        [DataMember]
        public int IsBillIncome { get; set; }
        [DataMember]
        public double Rate { get; set; }
        [DataMember]
        public Nullable<int> KeepRecharge { get; set; }
        [DataMember]
        public Nullable<int> IsPrivilege { get; set; }
        [DataMember]
        public Nullable<int> AllDiscount { get; set; }
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
        public virtual CashBaseType CashBaseType { get; set; }
    }
}
