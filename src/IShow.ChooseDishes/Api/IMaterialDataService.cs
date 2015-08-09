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
    public interface IMaterialDataService
    {
        //添加原料
        [OperationContract]
        bool AddRawMaterial(RawMaterial rw);
        /**修改原料*/
        [OperationContract]
        bool UpdateRawMaterial(RawMaterial rw);
        /**根据原料id做物理删除*/
        [OperationContract]
        bool UpdateRawMaterialDeletedStatusById(int Id,int DeletedStatus);
        /**根据原料id删除原料*/
        [OperationContract]
        bool DeleteRawMaterial(int id);
        /**根据小类编号查找所有的原料*/
        [OperationContract]
        List<RawMaterial> FindAllRawMaterialByRawId(int RawId);
        /// <summary>
        /// 根据小类id 查找所有的未被物理删除的 原料资料
        /// find the List of RawMaterial Object by rawId and the DeletedStatus of this
        /// </summary>
        /// <param name="RawId"> 原料小类id</param>
        /// <returns> </returns>
        [OperationContract]
        List<RawMaterial> FindAllRawMaterialByRawIdAndDeletedStatus(int RawId);
        /**根据原料单位编号查找所有的原料*/
        [OperationContract]
        List<RawMaterial> FindAllRawMaterialByRawUnitId(int RawUnitId);
        /**根据原料编号查找原料*/
        [OperationContract]
        RawMaterial FindRawMaterialById(int Id);
        /// <summary>
        /// 根据名称查找原料资料
        /// </summary>
        /// <param name="name"> 传入原料资料名称</param>
        /// <returns> List<RawMaterial> 集合</returns>
        [OperationContract]
        List<RawMaterial> FindRawMaterialByName(string name);
        /// <summary>
        /// 查找所有的原料资料
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<RawMaterial> FindAllRawMaterial();


        /// <summary>
        /// 查找所有未被进行物理删除的原料
        /// </summary>
        /// <returns> List<RawMaterial> </returns>
        [OperationContract]
        List<RawMaterial> FindAllRawMaterialByDeleted();
        //添加类别
        [OperationContract]
        bool AddRaw(Raw rw);
        /**修改原料类别*/
        [OperationContract]
        bool UpdateRaw(Raw rw);
        //**根据原料类型id做物理删除*/
        [OperationContract]
        bool UpdateRawDeletedStatusById(int Id, int DeletedStatus);
        /// <summary>
        /// 根据大类id查找所有的没有被进行物理删除的小类
        /// </summary>
        /// <param name="BigRawId"> 大类id</param>
        /// <returns> return List of the Raw</returns>
        [OperationContract]
        List<Raw> FindAllRawByBigRawIdAndDeletedStatus(int BigRawId);
        /**根据原料id删除原料*/
        [OperationContract]
        bool DeleteRaw(int id);
        /**根据大类编号查找所有的小类原料*/
        [OperationContract]
        List<Raw> FindAllRawByBigRawId(int BigRawId);
        /**根据原料大类编号查找原料大类*/
        [OperationContract]
        Raw FindRawById(int Id);
        /**find all the Raw Object from database*/
        [OperationContract]
        List<Raw> FindAllBigRaw();
        /// <summary>
        /// find all the big raw Collection Object  where Deleted==0 from database
        /// </summary>
        /// <returns>return List of the Raw </returns>
        [OperationContract]
        List<Raw> FindAllBigRawByDeletedStatus();
    }
}
