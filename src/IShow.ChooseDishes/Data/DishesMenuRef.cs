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
    
    public partial class DishesMenuRef
    {
        public int DishId { get; set; }
        public int MenusId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int Deleted { get; set; }
    
        public virtual Dish Dish { get; set; }
        public virtual DishesMenu DishesMenu { get; set; }
    }
}
