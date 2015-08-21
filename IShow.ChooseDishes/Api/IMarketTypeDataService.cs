using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Api
{
    public interface IMarketTypeDataService
    {
        /// <summary>
        /// 查找MarketType表中所有的记录
        /// <para>find all of MarketType object from database which table is MarketType</para> 
        /// </summary>
        /// <returns><para>如果查询到记录，则返回List集合，否则返回null</para>return List of the MarketType if the record nor null,else if return null </returns>
        List<MarketType> FindAllMarketType();
        /// <summary>
        /// 查找MarketType表中所有的没有被标记为删除的记录
        /// <para>find all of MarketType object from database which table is MarketType where Deleted=0</para> 
        /// </summary>
        /// <returns><para>如果查询到记录，则返回List集合，否则返回null</para>return List of the MarketType if the record nor null,else if return null</returns>
        List<MarketType> FindAllMarketTypeByDeletedStatus();
        /// <summary>
        /// 根据传入参数MarketType对象，向数据表中新增数据
        /// <para>According to the parameter MarketType object,which will be insert to table MarketType </para>
        /// </summary>
        /// <param name="mt">MarketType 对象</param>
        /// <returns>
        /// 写入数据库成功后将返回该对象，如果写入数据库失败，则返回null
        /// <para>return MarketType object if insert to database success,else return null</para>
        /// </returns>
        MarketType AddMarketType(MarketType mt);
        /// <summary>
        /// 根据传入参数MarketType对象，修改数据表中的对应字段的数据
        /// <para>according to the parameter MarketType object which will be update table MarketType</para>
        /// </summary>
        /// <param name="mt">MarketType 对象</param>
        /// <returns>
        /// 修改数据库成功后将返回该对象，如果修改数据库失败，则返回null
        /// <para>return MarketType object if update to database success,else return null</para>
        /// </returns>
        MarketType UpdateMarketType(MarketType mt);
        /// <summary>
        /// 根据id删除表中数据
        /// <para>deleted table MarketType where Id=id</para>
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>
        /// 删除数据库成功后将返回true，如果删除数据库失败，则返回false
        /// <para>return true if deleted success,else return false</para>
        /// </returns>
        bool DeleteMarketTypeById(int id);
        /// <summary>
        /// 根据id查询表中数据
        /// <para>find table MarketType where Id=id</para>
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>
        /// 查询到数据，则返回该数据对象，否则返回null
        /// <para>return MarketType object if query success,else return null</para>
        /// </returns>
        MarketType FindMarketTypeById(int id);
        /// <summary>
        /// 根据当前时间获取当前市别
        /// <para>get the current MarketType from all of the table MarketType by the currentTime </para>
        /// </summary>
        /// <param name="dt">currentTime</param>
        /// <returns>
        /// <para>遍历表中所有对象，对两个对象的创建时间与当前时间进行判断，如果在该区域内，则返回上一个市别，否则返回null</para>
        /// return the current MarketType by the time from the range which Two MarketType Object's createTime had,else if return null
        /// </returns>
        MarketType FindCurrentMarketTypeByDateTime(DateTime currentTime);
    }
}
