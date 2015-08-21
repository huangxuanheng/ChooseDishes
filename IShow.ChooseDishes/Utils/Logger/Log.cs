using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Api;

namespace IShow.ChooseDishes.Utils.Logger
{
    public class Log
    {

        static ILoggerService _LoggerService = Register.GetLogger();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
        /// <param name="itemId"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void L(Format format, LogType type, int actor, int objectId, object[] args)
        {
            _LoggerService.Log(format, type, actor, objectId, args);
        }

        /// <summary>
        /// 用户新增数据时的日志记录
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
        /// <param name="itemId"></param>
        public static void A(Format format, int actor, int objectId)
        {
            L(format, LogType.ADD, actor, objectId, new object[]{actor,objectId});
        }

        /// <summary>
        /// 对数据修改日志记录
        /// </summary>
        /// <param name="app"></param>
        /// <param name="fucntion"></param>
        /// <param name="action"></param>
        /// <param name="itemId"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        public static void M(Format format, int actor, int objectId, string before, string after)
        {
            L(format, LogType.MODIFY, actor, objectId, new object[] { actor, objectId,before, after });
        }


        public static void M(Format format, int actor, int objectId)
        {
            L(format, LogType.MODIFY, actor, objectId, new object[]{actor,objectId});
        }
        public static void M(Format format, int actor, int objectId, object[] args)
        {
            L(format, LogType.MODIFY, actor, objectId, new object[]{actor,objectId,args});
        }

        /// <summary>
        /// 对数据删除
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
        public static void D(Format format, int actor, int objectId)
        {
            L(format, LogType.DELETE, actor, objectId, new object[]{actor,objectId});
        }


        /// <summary>
        /// 查询日志记录
        /// </summary>
        /// <param name="format"></param>
        /// <param name="actor"></param>
        /// <param name="objectId"></param>
        public static void Q(Format format, int actor,object[] args)
        {
            L(format, LogType.QUERY, actor, 0, new object[]{actor,args});
        }
    }
}
