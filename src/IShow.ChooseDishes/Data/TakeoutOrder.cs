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
    
    public partial class TakeoutOrder
    {
        public int TakeoutId { get; set; }
        public Nullable<int> OrderPeopleId { get; set; }
        public int OrderId { get; set; }
        public string DeliveryManNum { get; set; }
        public string Num { get; set; }
        public Nullable<int> AdvanceAmount { get; set; }
        public System.DateTime DeliverTime { get; set; }
        public System.DateTime SendTime { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public int CreateBy { get; set; }
        public Nullable<int> Status { get; set; }
        public int Deleted { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    
        public virtual TakeoutClientInfo TakeoutClientInfo { get; set; }
    }
}
