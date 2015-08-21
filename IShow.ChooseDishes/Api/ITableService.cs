
using IShow.ChooseDishes.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
//using IShow.Service.Services;

namespace IShow.ChooseDishes
{

    public interface ITableService
    {
        //餐桌类型
        #region 餐桌类型
        /// <summary>
        /// 获取所有的餐桌类型及其下的所有餐桌和餐桌对应的餐桌状态
        /// </summary>
        /// <returns>如果有数据，则返回所有的餐桌类型，否则返回null</returns>
        List<TableType> GetAllTypes();
        //查询所有桌类
        List<TableType> LoadAllTableType();
        //根据ID查询桌类
        TableType LoadTableTypeById(int typeId);
        //新增桌类
        int SaveTableType(TableType type);

        /// <summary>
        /// 新增桌类，包括服务费设置、低消设置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="serverFeeDetail"></param>
        /// <param name="lowConsumerDetail"></param>
        /// <returns>餐桌类型ID</returns>
        int SaveTableTypeAll(TableType type, TableTypeDetail serverFeeDetail, TableTypeDetail lowConsumerDetail);

        //修改桌类
        void UpdateTableType(TableType type);

        /// <summary>
        /// 修改餐桌类型，包括服务费设置、低消设置
        /// </summary>
        /// <param name="type">餐桌类型</param>
        /// <param name="serverFeeDetail">餐桌类型服务费设置</param>
        /// <param name="lowConsumerDetail">餐桌类型低消设置</param>
        void UpdateTableTypeAll(TableType type, TableTypeDetail serverFeeDetail, TableTypeDetail lowConsumerDetail);

        /**删除桌类,逻辑删除**/
        void DeleteTableType(int typeId);

        #endregion

        #region 餐桌特殊时段
        /// <summary>
        /// 查询餐桌类型中所有时段收费设置
        /// 
        /// </summary>
        /// <returns></returns>
        List<TableTypeDetail> LoadAllTableTypeDetails(int tableTypeId);


        /// <summary>
        /// 查询餐桌类型中时段收费设置
        /// type为1: 查询服务费特殊时段
        /// type为2：查询低消特殊时段
        /// type为3：查询时间单位服务费设置
        /// </summary>
        /// <returns></returns>
        List<TableTypeDetail> LoadTableTypeDetails(int tableTypeId, int type);

        /// <summary>
        /// 根据ID查询餐桌类别详细设置
        /// </summary>
        /// <param name="tableTypeDetailId"></param>
        /// <returns></returns>
        TableTypeDetail LoadTableTypeDetailById(int tableTypeDetailId);

        /// <summary>
        /// 新增服务费时间单位设置
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        bool SaveTableTypeDetail(TableTypeDetail detail);

        /// <summary>
        /// 修改餐桌类别详细设置
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        bool UpdateTableTypeDetail(TableTypeDetail detail);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        bool DeleteTableTypeDetail(int detailId);

        #endregion

        #region 餐桌
        //查询所有桌类
        List<Table> LoadAllTable();
        //根据ID查询桌类
        Table LoadTableById(int tableId);
        //根据餐类ID查询餐桌
        List<Table> LoadTableByTypeId(int typeId);
        /// <summary>
        /// 根据餐桌类型id查询所有餐桌及其下餐桌状态
        /// </summary>
        /// <param name="typeId">typeId 餐桌类型id</param>
        /// <returns></returns>
        List<Table> LoadTableAndRefByTypeId(int typeId);
        //新增桌类
        Hashtable SaveTable(Table table);
        //修改桌类
        bool UpdateTable(Table table);
        /**删除桌类,逻辑删除**/
        bool DeleteTable(int tableId);

        #endregion

        #region 按区域查询餐桌
        /// <summary>
        /// 获取所有的区域及其下的所有餐桌及餐桌状态
        /// </summary>
        /// <returns>如果查找到，则返回区域集合，否则返回null</returns>
        List<Location> GetAllLocation();
        /// <summary>
        /// 根据区域id获取其下的所有餐桌及餐桌状态
        /// </summary>
        /// <returns>如果查找到，则返回区域集合，否则返回null</returns>
        Location GetLocationById(int Id);
        #endregion
    }
}
