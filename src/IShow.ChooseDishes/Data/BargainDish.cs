//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IShow.ChooseDishes.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BargainDish
    {
        public BargainDish()
        {
            this.BargainDishPrice = new HashSet<BargainDishPrice>();
        }
    
        public int Id { get; set; }
        public int DishId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Week1 { get; set; }
        public int Week2 { get; set; }
        public int Week3 { get; set; }
        public int Week4 { get; set; }
        public int Week5 { get; set; }
        public int Week6 { get; set; }
        public int Week0 { get; set; }
        public int MarketTypeId { get; set; }
        public int Enable { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int Deleted { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> Update_by { get; set; }
    
        public virtual Dish Dish { get; set; }
        public virtual ICollection<BargainDishPrice> BargainDishPrice { get; set; }
    }
}
