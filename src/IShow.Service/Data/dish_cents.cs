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
    public partial class dish_cents
    {
        [DataMember]
        public Nullable<int> DishId { get; set; }
        [DataMember]
        public Nullable<int> DiancaiCents { get; set; }
        [DataMember]
        public Nullable<int> DiancaiType { get; set; }
        [DataMember]
        public Nullable<double> DiancaiCentsScale { get; set; }
        [DataMember]
        public Nullable<double> DiancaiCentsFix { get; set; }
        [DataMember]
        public Nullable<int> ServerCents { get; set; }
        [DataMember]
        public Nullable<int> ServerType { get; set; }
        [DataMember]
        public Nullable<double> ServerCentsScale { get; set; }
        [DataMember]
        public Nullable<int> ServerCentsFix { get; set; }
        [DataMember]
        public Nullable<double> SaleCents { get; set; }
        [DataMember]
        public Nullable<int> SaleType { get; set; }
        [DataMember]
        public Nullable<double> SaleCentsScale { get; set; }
        [DataMember]
        public Nullable<double> SaleCentsFix { get; set; }
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
        public virtual Dish Dish { get; set; }
    }
}