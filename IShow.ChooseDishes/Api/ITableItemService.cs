using IShow.ChooseDishes.Data;
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
        TableItem Add(int TableId, int CreateTableId);
        /// <summary>
        /// 根据桌台id和开台id完成物理删除
        /// </summary>
        /// <param name="TableId">桌台id</param>
        /// <param name="CreateTableId">开台id</param>
        /// <returns></returns>
        bool Remove(int TableId, int CreateTableId);
        /// <summary>
        /// 根据桌台id和开台id修改状态
        /// </summary>
        /// <param name="TableId">桌台id</param>
        /// <param name="CreateTableId">开台id</param>
        /// <returns></returns>
        TableItem ModifyStatusBy(int TableId, int CreateTableId, int Status);

    }
}
