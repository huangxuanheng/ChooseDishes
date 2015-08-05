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
    
    public partial class Dish
    {
        public Dish()
        {
            this.DischesWayRef = new HashSet<DischesWayRef>();
            this.dish_cents = new HashSet<dish_cents>();
            this.DishDao = new HashSet<DishDao>();
            this.DishesMenuRef = new HashSet<DishesMenuRef>();
            this.PromotionsDish = new HashSet<PromotionsDish>();
        }
    
        public int DishId { get; set; }
        public int DishTypeId { get; set; }
        public Nullable<int> DishUnitId { get; set; }
        public Nullable<int> DishFinanceId { get; set; }
        public string Code { get; set; }
        public string DishName { get; set; }
        public string PingYing { get; set; }
        public string AidNumber { get; set; }
        public string EnglishName { get; set; }
        public string DishFormat { get; set; }
        public int WeightConfirm { get; set; }
        public int LowConsumerConfirm { get; set; }
        public int ServerfreeConsumer { get; set; }
        public int SanpConfirm { get; set; }
        public int IsStop { get; set; }
        public int DiscountConfirm { get; set; }
        public int PriceTimeConfirm { get; set; }
        public int PackagesConfirm { get; set; }
        public int PosConfirm { get; set; }
        public int FoodFight { get; set; }
        public int LineConfirm { get; set; }
        public int DischesType { get; set; }
        public string Detail { get; set; }
        public string Img { get; set; }
        public Nullable<int> KitchenType { get; set; }
        public Nullable<int> PublisherType { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual ICollection<DischesWayRef> DischesWayRef { get; set; }
        public virtual ICollection<dish_cents> dish_cents { get; set; }
        public virtual DishFinance DishFinance { get; set; }
        public virtual DishType DishType { get; set; }
        public virtual DishUnit DishUnit { get; set; }
        public virtual ICollection<DishDao> DishDao { get; set; }
        public virtual ICollection<DishesMenuRef> DishesMenuRef { get; set; }
        public virtual ICollection<PromotionsDish> PromotionsDish { get; set; }
    }
}