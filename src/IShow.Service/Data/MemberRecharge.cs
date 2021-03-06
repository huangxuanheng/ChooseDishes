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
    public partial class MemberRecharge
    {
        public MemberRecharge()
        {
            this.RechargeItem = new HashSet<RechargeItem>();
        }
    
        [DataMember]
        public int RechargeId { get; set; }
        [DataMember]
        public int ShiftId { get; set; }
        [DataMember]
        public int CreateBy { get; set; }
        [DataMember]
        public System.DateTime CreateTime { get; set; }
        [DataMember]
        public System.DateTime StartTime { get; set; }
        [DataMember]
        public System.DateTime EndTime { get; set; }
        [DataMember]
        public int RechargeNum { get; set; }
        [DataMember]
        public double RechargeMoney { get; set; }
        [DataMember]
        public double PayMoney { get; set; }
    
        [DataMember]
        public virtual ShiftBill ShiftBill { get; set; }
        [DataMember]
        public virtual ICollection<RechargeItem> RechargeItem { get; set; }
    }
}
