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
    
    public partial class DishPrint
    {
        public int Id { get; set; }
        public string DishNo { get; set; }
        public string DishName { get; set; }
        public int Type { get; set; }
        public int PlanId { get; set; }
        public Nullable<int> AreaPlanId { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int Deleted { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string UpdateBy { get; set; }
        public int Status { get; set; }
    
        public virtual AreaPrintPlan AreaPrintPlan { get; set; }
        public virtual BasicPrintPlan BasicPrintPlan { get; set; }
    }
}
