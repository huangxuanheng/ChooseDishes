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
    public partial class ShiftItem
    {
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public int PayType { get; set; }
        [DataMember]
        public int PayNum { get; set; }
        [DataMember]
        public double Money { get; set; }
        [DataMember]
        public double RmbMoney { get; set; }
    
        [DataMember]
        public virtual ShiftBill ShiftBill { get; set; }
    }
}