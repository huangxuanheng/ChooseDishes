using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Utils.Logger;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace IShow.ChooseDishes.Service
{
   public class LoggerService:ILoggerService
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
      public  void Log(Format format,LogType type, int actor, int objectId,object[] args) {
          SystemLog _Log = new SystemLog();
          _Log.ItemId = Convert.ToString(objectId);
          _Log.Actor = Convert.ToString(actor);
          _Log.CreateDatetime = DateTime.Now;
          _Log.Module = format.Function.Module.Name;
          _Log.Function = format.Function.Name;
          _Log.Body = LoggerUtils.Format(format, args);
          _Log.OpType = Enum.GetName(typeof(LogType), type);

          using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
              entities.SystemLog.Add(_Log);
              entities.SaveChanges();
          }      
      }

        /// <summary>
        /// 用户新增数据时的日志记录
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
        /// <param name="itemId"></param>
      public void Add(Format format, int actor, int objectId)
      {
          Log(format, LogType.ADD, actor, objectId, null);  
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
      public void Modify(Format format, int actor, int objectId, string before, string after)
      {
          Log(format, LogType.MODIFY, actor, objectId, new object[]{before,after});
        }

        /// <summary>
        /// 对数据删除
        /// </summary>
        /// <param name="app"></param>
        /// <param name="function"></param>
        /// <param name="actor"></param>
      public void Delete(Format format,int actor, int objectId )
      {
          Log(format, LogType.DELETE, actor, objectId,null);
        }
      /// <summary>
      /// 查询所有的日志
      /// <para>find all of SystemLog Object from database which table was System</para>
      /// </summary>
      /// <returns>
      /// 找到则返回一个list集合，否则返回null
      /// <para>return the list of SystemLog which will be found,else return null</para>
      /// </returns>
      public List<SystemLog> FindAllSystemLog()
      {    
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                List<SystemLog> odws = entities.SystemLog.OrderBy(s=>s.Id).ToList();
                if (odws != null && odws.Count > 0)
                {
                    return odws;
                }
            }
          return null;
      }
       /// <summary>
       /// 根据模块id查找系统日志
      /// <para>get all of  SystemLog object by moduleId from table SystemLog</para>
       /// </summary>
      /// <param name="moduleId">moduleId</param>
       /// <returns>return the list of SystemLog if query success and it is not null,else if return null</returns>
      public List<SystemLog> FindAllSystemLogByModuleId(string moduleId)
      {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                List<SystemLog>  odws = entities.SystemLog.Where(sl=>sl.Module.Equals(moduleId)).OrderBy(s => s.Id).ToList();
                if (odws != null && odws.Count > 0)
                {
                    return odws;
                }
            }
          return null;
      }
      /// <summary>
      /// 根据指定日期删除创建日期比该日期小的日志
      /// deleted SystemLog object from table SystemLog where StartDate less than the parameter date
      /// </summary>
      /// <param name="date">日期</param>
      public void DeleteByDate(DateTime date)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              List<SystemLog> _books;

              _books = entities.SystemLog.Where(book => book.CreateDatetime.CompareTo(date)<0).ToList();
              if(_books!=null)
              foreach (var bk in _books)
              {
                  DbEntityEntry<SystemLog> entry = entities.Entry<SystemLog>(bk);
                  entry.State = EntityState.Deleted;

              }
              entities.SaveChanges();
          }
      }
      /// <summary>
      /// 根据指定开始日期和结束日期查询系统日志
      /// <para>get all of SystemLog by startDate and endDate and operator from table SytemLog</para>
      /// </summary>
      /// <param name="startDate">startDate</param>
      /// <param name="endDate">endDate</param>
      /// <param name="op">operator</param>
      /// <returns>return the list of SystemLog if query success and it is not null,else if return null</returns>
      public List<SystemLog> FindAllByStartDateAndOperated(DateTime startDate, DateTime endDate, string op)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              List<SystemLog> odws =null;
              if(op==null)
                odws = entities.SystemLog.Where(sl => sl.CreateDatetime > startDate && sl.CreateDatetime < endDate).OrderBy(s => s.Id).ToList();
              else
              {
                  odws = entities.SystemLog.Where(sl => sl.CreateDatetime > startDate && sl.CreateDatetime < endDate&&op.Equals(sl.Actor)).OrderBy(s => s.Id).ToList();
              }
              if (odws != null && odws.Count > 0)
              {
                  return odws;
              }
          }
          return null;
      }

   }
}
