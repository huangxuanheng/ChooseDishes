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
    public partial class OrderItem
    {
        public OrderItem()
        {
            this.OrderMateria = new HashSet<OrderMateria>();
            this.OrderPractice = new HashSet<OrderPractice>();
        }
    
        [DataMember]
        public int OrderItemId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DishNum { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public int Num { get; set; }
        [DataMember]
        public int Quit { get; set; }
        [DataMember]
        public int Addprice { get; set; }
        [DataMember]
        public int IsPay { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        [DataMember]
        public System.DateTime CreateDatetime { get; set; }
        [DataMember]
        public int CreateBy { get; set; }
        [DataMember]
        public int Deleted { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public Nullable<int> UpdateBy { get; set; }
        [DataMember]
        public int SpecialPrice { get; set; }
        [DataMember]
        public int Weight { get; set; }
        [DataMember]
        public int Pause { get; set; }
        [DataMember]
        public int Rebate { get; set; }
        [DataMember]
        public Nullable<int> Discount { get; set; }
    
        [DataMember]
        public virtual Order Order { get; set; }
        [DataMember]
        public virtual ICollection<OrderMateria> OrderMateria { get; set; }
        [DataMember]
        public virtual ICollection<OrderPractice> OrderPractice { get; set; }
    }
}