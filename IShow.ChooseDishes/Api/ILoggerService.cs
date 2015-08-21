using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Utils.Logger;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Api
{
    public interface ILoggerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
        /// <param name="itemId"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Log(Format format,LogType type, int actor, int objectId, object[] args);

        /// <summary>
        /// 用户新增数据时的日志记录
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
        /// <param name="itemId"></param>
        void Add(Format format, int actor, int objectId);

        /// <summary>
        /// 对数据修改日志记录
        /// </summary>
        /// <param name="app"></param>
        /// <param name="fucntion"></param>
        /// <param name="action"></param>
        /// <param name="itemId"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        void Modify(Format format, int actor, int objectId, string before, string after);

        /// <summary>
        /// 对数据删除
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
        void Delete(Format format,int actor,int objectId );
        /// <summary>
        /// 查询所有的日志
        /// <para>find all of SystemLog Object from database which table was System</para>
        /// </summary>
        /// <returns>
        /// 找到则返回一个list集合，否则返回null
        /// <para>return the list of SystemLog which will be found,else return null</para>
        /// </returns>
        List<SystemLog> FindAllSystemLog();
        /// <summary>
        /// 根据指定日期删除创建日期比该日期小的日志
        /// deleted SystemLog object from table SystemLog where StartDate less than the parameter date
        /// </summary>
        /// <param name="date">日期</param>
        void DeleteByDate(DateTime date);

         /// <summary>
       /// 根据模块id查找系统日志
      /// <para>get all of  SystemLog object by moduleId from table SystemLog</para>
       /// </summary>
      /// <param name="moduleId">moduleId</param>
       /// <returns>return the list of SystemLog if query success and it is not null,else if return null</returns>
        List<SystemLog> FindAllSystemLogByModuleId(string moduleId);
        /// <summary>
        /// 根据指定开始日期和结束日期查询系统日志
        /// <para>get all of SystemLog by startDate and endDate and operator from table SytemLog</para>
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="op">operator</param>
        /// <returns>return the list of SystemLog if query success and it is not null,else if return null</returns>
        List<SystemLog> FindAllByStartDateAndOperated(DateTime startDate,DateTime endDate, string op);
    }
}
