//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IShow.ChooseDishes.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeskOrder
    {
        public DeskOrder()
        {
            this.DeskOrderMateria = new HashSet<DeskOrderMateria>();
            this.DeskOrderPractice = new HashSet<DeskOrderPractice>();
        }
    
        public int DeskOrderId { get; set; }
        public Nullable<int> DeskDishesId { get; set; }
        public string DeskNum { get; set; }
        public string DishNum { get; set; }
        public int Price { get; set; }
        public int Num { get; set; }
        public int Quit { get; set; }
        public int SpecialPrice { get; set; }
        public int Weight { get; set; }
        public int Pause { get; set; }
        public int Urge { get; set; }
        public int Rebate { get; set; }
        public Nullable<int> Discount { get; set; }
        public int Single_note { get; set; }
        public int Temporary_menu { get; set; }
        public Nullable<int> TemporaryMenuNum { get; set; }
        public int ClearDish { get; set; }
        public int IsDshes { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual DeskDishes DeskDishes { get; set; }
        public virtual ICollection<DeskOrderMateria> DeskOrderMateria { get; set; }
        public virtual ICollection<DeskOrderPractice> DeskOrderPractice { get; set; }
    }
}
