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
    public partial class RefundInfo
    {
        public RefundInfo()
        {
            this.RefundInfoItem = new HashSet<RefundInfoItem>();
        }
    
        [DataMember]
    public int RefundId { get; set; }
        [DataMember]
    public Nullable<int> ShiftId { get; set; }
        [DataMember]
    public int OperatorBy { get; set; }
        [DataMember]
    public string OperatorName { get; set; }
        [DataMember]
    public int SucceedId { get; set; }
        [DataMember]
    public string SucceedName { get; set; }
        [DataMember]
    public System.DateTime StartTime { get; set; }
        [DataMember]
    public System.DateTime EndTime { get; set; }
        [DataMember]
    public string Remark { get; set; }
        [DataMember]
    public double TurnOnCash { get; set; }
        [DataMember]
    public int RefundNum { get; set; }
        [DataMember]
    public int RefundDishNum { get; set; }
        [DataMember]
    public double RefundMoney { get; set; }
    
        [DataMember]
    public virtual ICollection<RefundInfoItem> RefundInfoItem { get; set; }
        [DataMember]
    public virtual ShiftBill ShiftBill { get; set; }
    }
}
