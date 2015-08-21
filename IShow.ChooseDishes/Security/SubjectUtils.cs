using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Utils.Logger;

namespace IShow.ChooseDishes.Security
{

    /// <summary>
    /// 鉴权工具类
    /// </summary>
    public class SubjectUtils
    {
        public static int GetAuthenticationId() {
            return Convert.ToInt16(SubjectManager.GetSubject().GetPrincipal());
        }

        public static bool HasPremession(string premession) {
            //Log.Info(Loggers.LOG_LOGIN,)
            return SubjectManager.GetSubject().HasPremission(premession);
        }

        /// <summary>
        /// 是否认证
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthenticationed() {
            return SubjectManager.GetSubject().IsAuthenticationed;
        }

        /// <summary>
        /// 是否授权
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthorizationed(){
            //return SubjectManager.GetSubject();
            return  true;
        }
    }
}
