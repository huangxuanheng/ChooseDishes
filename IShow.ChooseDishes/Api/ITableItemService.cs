﻿using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Api
{
    public interface ITableItemService
    {
        /// <summary>
        /// 获取所有的餐桌状态(包括餐桌及开台信息)
        /// </summary>
        /// <returns></returns>
        List<TableItem> GetAll();
        /// <summary>
        /// 根据餐桌id和开台id添加记录
        /// </summary>
        /// <param name="TableId">餐桌id</param>
        /// <param name="CreateTableId">开台id</param>
        /// <returns></returns>
        TableItem Add(int TableId);
        /// <summary>
        /// 根据桌台id和开台id完成物理删除
        /// </summary>
        /// <param name="TableId">桌台id</param>
        /// <param name="CreateTableId">开台id</param>
        /// <returns></returns>
        bool Remove(int TableId);
        /// <summary>
        /// 根据桌台id和开台id修改状态
        /// </summary>
        /// <param name="TableId">桌台id</param>
        /// <param name="CreateTableId">开台id</param>
        /// <returns></returns>
        bool ModifyStatus(int TableId,int Status);
        /// <summary>
        /// 根据桌台id获取餐桌状态详情，包括开台信息和餐桌信息
        /// get the detail TableItem by TableId
        /// </summary>
        /// <param name="TableId">餐桌id</param>
        /// <returns></returns>
        List<TableItem> GetDetailByTableId(int TableId);
        /// <summary>
        /// 根据餐桌状态获取餐桌信息详情，包括开台信息和餐桌信息
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        List<TableItem> GetDetailByStatus(int Status);
        /// <summary>
        /// 根据餐桌状态获取对应餐桌的数量
        /// </summary>
        /// <param name="Status">餐桌状态</param>
        /// <returns></returns>
        int GetNumByStatus(int Status);
        /// <summary>
        /// 修改餐桌状态为空闲状态
        /// </summary>
        /// <param name="TableId"></param>
        bool ModifyIdle(int TableId);
        /// <summary>
        /// 修改餐桌状态为正在使用
        /// </summary>
        /// <param name="TableId"></param>
        bool ModifyUsing(int TableId);
        /// <summary>
        /// 修改餐桌状态为待清状态
        /// </summary>
        /// <param name="TableId"></param>
        bool ModifyWaitting(int TableId);
        /// <summary>
        /// 修改餐桌状态为预定状态
        /// </summary>
        /// <param name="TableId"></param>
        bool ModifyScheduled(int TableId);
        /// <summary>
        /// 修改餐桌状态为超额状态
        /// </summary>
        /// <param name="TableId"></param>
        bool ModifyExcess(int TableId);
    }
}
