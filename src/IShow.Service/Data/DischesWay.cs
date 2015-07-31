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
    public partial class DischesWay
    {
        public DischesWay()
        {
            this.DischesWayRef = new HashSet<DischesWayRef>();
        }
    
        [DataMember]
        public int DischesWayId { get; set; }
        [DataMember]
        public int DischesWayNameId { get; set; }
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string WayDetail { get; set; }
        [DataMember]
        public string PingYing { get; set; }
        [DataMember]
        public double AddPrice { get; set; }
        [DataMember]
        public int AddPriceByNum { get; set; }
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
        public virtual ICollection<DischesWayRef> DischesWayRef { get; set; }
        [DataMember]
        public virtual DischesWayName DischesWayName { get; set; }
    }
}
