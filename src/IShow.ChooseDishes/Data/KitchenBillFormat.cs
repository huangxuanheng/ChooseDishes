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
    
    public partial class KitchenBillFormat
    {
        public KitchenBillFormat()
        {
            this.PrintSet = new HashSet<PrintSet>();
        }
    
        public int FormatId { get; set; }
        public int PaperType { get; set; }
        public int PaperWidth { get; set; }
        public int BillType { get; set; }
        public int TableCode { get; set; }
        public int TableFont { get; set; }
        public int BillNo { get; set; }
        public int CustNum { get; set; }
        public int HeadFont { get; set; }
        public int WaiterName { get; set; }
        public int DishServerName { get; set; }
        public int OpenTableRemark { get; set; }
        public int OrdeTtime { get; set; }
        public int OrderRemark { get; set; }
        public int OrderRemarkFont { get; set; }
        public int DetailFont { get; set; }
        public int DishNum { get; set; }
        public int DishNumFormat { get; set; }
        public int DishUnit { get; set; }
        public int DishPrice { get; set; }
        public int DishPriceFormat { get; set; }
        public int EndFont { get; set; }
        public int TotalNum { get; set; }
        public int TotalNumFormat { get; set; }
        public int TotalMoney { get; set; }
        public int TotalMoneyFormat { get; set; }
        public int PrintTime { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime Createatetime { get; set; }
        public int Deleted { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public string UpdateBy { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<PrintSet> PrintSet { get; set; }
    }
}
