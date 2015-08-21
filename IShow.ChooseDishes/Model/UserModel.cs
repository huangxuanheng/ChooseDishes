using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Model
{
    /// <summary>
    /// 用户Model,即系统中的操作员
    /// </summary>
    public class UserModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        private string Password { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeId { get; set; }
        //员工名称
        public string EmployeeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String AllowanceType { get; set; }
       /// <summary>
       /// 折扣极限
       /// </summary>
        public double? AllowanceLimit { get; set; }
        /// <summary>
        /// 赠送界别控制
        /// </summary>
        public String PresentType { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public double? PresentLimit { get; set; }

        
        /// <summary>
        /// 折让折扣底限
        /// </summary>
        public double? DiscountAllowanceLimit { get; set; }

        public double? DiscountLimit { get; set; }
        public string[] Roles { get; set; }

        public UserModel(UserInfo Info) {
            this.From(Info);
        } 

        protected  void From(UserInfo userInfo) {
            this.UserId = userInfo.UserId;
            this.EmployeeId = userInfo.EmployeeId;
            this.Username = userInfo.Username;
            this.EmployeeName = userInfo.Employee.Name;
            if (null != userInfo.UserSaleRule) {
                this.AllowanceType = ""+userInfo.UserSaleRule.AlowanceType;
                this.AllowanceLimit = userInfo.UserSaleRule.AllowanceLimit;
                this.PresentType = ""+userInfo.UserSaleRule.PresentType;
                this.PresentLimit = userInfo.UserSaleRule.PresentLimit;
                this.DiscountAllowanceLimit = userInfo.UserSaleRule.DiscountAllowanceLimit;
                this.DiscountLimit = userInfo.UserSaleRule.DiscountLimit;
            }
        }


    }
}
