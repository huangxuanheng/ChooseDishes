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
    
    public partial class TakeoutClientInfo
    {
        public TakeoutClientInfo()
        {
            this.TakeoutOrder = new HashSet<TakeoutOrder>();
        }
    
        public int OrderPeopleId { get; set; }
        public string Order_people { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public System.DateTime Create_datetime { get; set; }
        public int Create_by { get; set; }
        public int Deleted { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> Update_datetime { get; set; }
        public Nullable<int> Update_by { get; set; }
    
        public virtual ICollection<TakeoutOrder> TakeoutOrder { get; set; }
    }
}
