using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Utils.Internal;

namespace IShow.ChooseDishes.Utils.Logger
{
    public class Loggers
    {
        /// <summary>
        ///登录
        /// </summary>
        public static Format LOG_LOGIN = new Format(Functions.USER, Resource.LOGIN);
        public static Format LOG_LOGOUT = new Format(Functions.USER, Resource.LOGOUT);

        #region 用户模块消息
        
        public static Format USER_NEW = new Format(Functions.USER, Resource.USER_NEW);//添加用户
        public static Format USER_DELETE = new Format(Functions.USER, Resource.USER_DELETE);//删除用户
        public static Format USER_GRANT_ROLE = new Format(Functions.USER, Resource.USER_GRANT_ROLE);//授权
        public static Format USER_REVOKE_ROLE = new Format(Functions.USER, Resource.USER_REVOKE_ROLE);//收回权限
        public static Format USER_RESET_PASSWORD = new Format(Functions.USER, Resource.USER_RESET_PASSWORD);//重置密码
        public static Format USER_ADD_ROLE = new Format(Functions.USER, Resource.USER_ADD_ROLE);//添加角色
        public static Format USER_DISABLE_ROLE = new Format(Functions.USER, Resource.USER_DISABLE_ROLE);//启用角色
        public static Format USER_ENABLE_ROLE = new Format(Functions.USER, Resource.USER_ENABLE_ROLE);//修改角色
        #endregion 用户模块消息
    }
}
