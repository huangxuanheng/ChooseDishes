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
    public partial class CashBaseType
    {
        public CashBaseType()
        {
            this.CashType = new HashSet<CashType>();
        }
    
        [DataMember]
        public int CashBaseTypeId { get; set; }
        [DataMember]
        public string Name { get; set; }
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
        public virtual ICollection<CashType> CashType { get; set; }
    }
}
