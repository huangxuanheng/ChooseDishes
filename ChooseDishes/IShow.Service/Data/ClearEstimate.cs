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
    public partial class ClearEstimate
    {
        [DataMember]
    public int Id { get; set; }
        [DataMember]
    public int DishCode { get; set; }
        [DataMember]
    public int Num { get; set; }
        [DataMember]
    public int WarnNum { get; set; }
        [DataMember]
    public int SaleNum { get; set; }
        [DataMember]
    public int LastNum { get; set; }
        [DataMember]
    public System.DateTime StartTime { get; set; }
        [DataMember]
    public string Operator { get; set; }
        [DataMember]
    public System.DateTime EndTime { get; set; }
        [DataMember]
    public string CancleMan { get; set; }
        [DataMember]
    public Nullable<System.DateTime> CancleTime { get; set; }
        [DataMember]
    public int MidwayCancle { get; set; }
        [DataMember]
    public string Reason { get; set; }
        [DataMember]
    public System.DateTime MarkTime { get; set; }
        [DataMember]
    public int Status { get; set; }
        [DataMember]
    public System.DateTime CreateDatetime { get; set; }
        [DataMember]
    public int CreateBy { get; set; }
        [DataMember]
    public int Deleted { get; set; }
        [DataMember]
    public Nullable<System.DateTime> UpdateDatetime { get; set; }
        [DataMember]
    public Nullable<int> UpdateBy { get; set; }
    }
}
