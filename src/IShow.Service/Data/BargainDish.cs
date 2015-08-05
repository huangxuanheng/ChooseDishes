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
    public partial class BargainDish
    {
        public BargainDish()
        {
            this.BargainDishPrice = new HashSet<BargainDishPrice>();
        }
    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int DishId { get; set; }
        [DataMember]
        public System.DateTime StartTime { get; set; }
        [DataMember]
        public System.DateTime EndTime { get; set; }
        [DataMember]
        public System.DateTime StartDate { get; set; }
        [DataMember]
        public System.DateTime EndDate { get; set; }
        [DataMember]
        public int Week1 { get; set; }
        [DataMember]
        public int Week2 { get; set; }
        [DataMember]
        public int Week3 { get; set; }
        [DataMember]
        public int Week4 { get; set; }
        [DataMember]
        public int Week5 { get; set; }
        [DataMember]
        public int Week6 { get; set; }
        [DataMember]
        public int Week0 { get; set; }
        [DataMember]
        public int MarketTypeId { get; set; }
        [DataMember]
        public int Enable { get; set; }
        [DataMember]
        public string CreateBy { get; set; }
        [DataMember]
        public System.DateTime CreateTime { get; set; }
        [DataMember]
        public int Deleted { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdateTime { get; set; }
        [DataMember]
        public string Update_by { get; set; }
    
        [DataMember]
        public virtual ICollection<BargainDishPrice> BargainDishPrice { get; set; }
    }
}