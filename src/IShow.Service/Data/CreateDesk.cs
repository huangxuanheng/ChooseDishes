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
    public partial class CreateDesk
    {
        public CreateDesk()
        {
            this.DeskDishes = new HashSet<DeskDishes>();
        }
    
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public string DeskNum { get; set; }
        [DataMember]
        public Nullable<int> Position { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string ManualNumber { get; set; }
        [DataMember]
        public int PriceClass { get; set; }
        [DataMember]
        public string Server { get; set; }
        [DataMember]
        public string Assistant { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string PeriodTime { get; set; }
        [DataMember]
        public System.DateTime CreateTime { get; set; }
        [DataMember]
        public string Property { get; set; }
        [DataMember]
        public Nullable<int> Type { get; set; }
        [DataMember]
        public Nullable<int> PerDeskPrice { get; set; }
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
        public virtual ICollection<DeskDishes> DeskDishes { get; set; }
    }
}
