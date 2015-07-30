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
    public partial class DeskOrder
    {
        public DeskOrder()
        {
            this.DeskOrderMateria = new HashSet<DeskOrderMateria>();
            this.DeskOrderPractice = new HashSet<DeskOrderPractice>();
        }
    
        [DataMember]
    public int DeskOrderId { get; set; }
        [DataMember]
    public Nullable<int> DeskDishesId { get; set; }
        [DataMember]
    public string DeskNum { get; set; }
        [DataMember]
    public string DishNum { get; set; }
        [DataMember]
    public int Price { get; set; }
        [DataMember]
    public int Num { get; set; }
        [DataMember]
    public int Quit { get; set; }
        [DataMember]
    public int SpecialPrice { get; set; }
        [DataMember]
    public int Weight { get; set; }
        [DataMember]
    public int Pause { get; set; }
        [DataMember]
    public int Urge { get; set; }
        [DataMember]
    public int Rebate { get; set; }
        [DataMember]
    public Nullable<int> Discount { get; set; }
        [DataMember]
    public int Single_note { get; set; }
        [DataMember]
    public int Temporary_menu { get; set; }
        [DataMember]
    public Nullable<int> TemporaryMenuNum { get; set; }
        [DataMember]
    public int ClearDish { get; set; }
        [DataMember]
    public int IsDshes { get; set; }
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
    public virtual DeskDishes DeskDishes { get; set; }
        [DataMember]
    public virtual ICollection<DeskOrderMateria> DeskOrderMateria { get; set; }
        [DataMember]
    public virtual ICollection<DeskOrderPractice> DeskOrderPractice { get; set; }
    }
}
