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
    
    public partial class GiveInvoice
    {
        public int Id { get; set; }
        public string BillNo { get; set; }
        public Nullable<int> ContentType { get; set; }
        public Nullable<int> GiftId { get; set; }
        public string GiftName { get; set; }
        public Nullable<double> OrgnalMoney { get; set; }
        public Nullable<double> RealPay { get; set; }
        public Nullable<double> RealReleaseInvoice { get; set; }
        public string Remark { get; set; }
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
