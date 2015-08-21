using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Api
{
    [ServiceContract(Namespace = "www.IShow.com")]
    public interface IRawUnitDataService
    {
        //添加原料单位
        [OperationContract]
        RawUnit AddRawUnit(RawUnit rw);
        /**修改原料单位*/
        [OperationContract]
        bool UpdateRawUnit(RawUnit rw);
        /**根据原料单位id做物理删除*/
        [OperationContract]
        bool UpdateRawUnitDeletedStatusById(int Id, int DeletedStatus);
        /**根据原料单位id删除原料单位*/
        [OperationContract]
        bool DeleteRawUnit(int id);
        /**根据原料单位编号查找所有的原料单位*/
        [OperationContract]
        List<RawUnit> FindAllRawUnit();
        /**根据原料单位编号查找原料单位*/
        [OperationContract]
        RawUnit FindRawUnitById(int Id);
        /// <summary>
        /// 查找所有未被进行物理删除的单位
        /// find all of RawUnit from database where Deleted=0
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>return the List of RawUnit by DeletedStatus from database</returns>
        [OperationContract]
        List<RawUnit> FindRawUnitByDeletedStatus();
        /// <summary>
        /// 根据名字查找数据库记录
        /// find all of the RawUnit from database where Name=name,if the list of RawUnit size bigger zero,will be return by it
        /// </summary>
        /// <param name="name">单位名称</param>
        /// <returns></returns>
        [OperationContract]
        List<RawUnit> FindRawUnitByName(string name);
    }
}
