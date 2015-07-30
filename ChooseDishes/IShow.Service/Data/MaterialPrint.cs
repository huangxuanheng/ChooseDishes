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
    public partial class MaterialPrint
    {
        [DataMember]
    public int Id { get; set; }
        [DataMember]
    public string MaterialCode { get; set; }
        [DataMember]
    public string MaterialName { get; set; }
        [DataMember]
    public int Type { get; set; }
        [DataMember]
    public int PlanId { get; set; }
        [DataMember]
    public int AreaPlanId { get; set; }
        [DataMember]
    public string CreateBy { get; set; }
        [DataMember]
    public System.DateTime Createtime { get; set; }
        [DataMember]
    public int Deleted { get; set; }
        [DataMember]
    public Nullable<System.DateTime> UpdateTime { get; set; }
        [DataMember]
    public string UpdateBy { get; set; }
        [DataMember]
    public int Status { get; set; }
    
        [DataMember]
    public virtual AreaPrintPlan AreaPrintPlan { get; set; }
        [DataMember]
    public virtual BasicPrintPlan BasicPrintPlan { get; set; }
    }
}
