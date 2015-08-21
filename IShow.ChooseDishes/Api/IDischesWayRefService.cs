using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Api
{
    public interface IDischesWayRefService
    {
        /// <summary>
        /// 根据菜品id、做法id、做法价格添加菜品做法关联
        /// <para>According  DishesId and DishesWayId and Price to insert data to the table  DischesWay</para>
        /// </summary>
        /// <param name="dishesId">dishesId 菜品id</param>
        /// <param name="DischesWayId">DishesWayId 做法id</param>
        /// <returns>insert success will return true ,else if return false</returns>
        bool Add(int dishesId, int DishesWayId);
        /// <summary>
        /// 获取全部的DischesWayRef对象
        /// <para>get all of DischesWayRef object</para>
        /// </summary>
        /// <returns>return the list of DischesWayRef if result if is nor null,else if return null</returns>
        List<DischesWayRef> QueryAll();
        /// <summary>
        /// 修改价格
        /// </summary>
        /// <param name="dishesId">dishesId 菜品id</param>
        /// <param name="DishesWayId">DishesWayId 做法id</param>
        /// <param name="price">price 价格</param>
        /// <returns>return true if modify success,else if return false</returns>
        bool ModifyByPrice(int dishesId, int DishesWayId, double price);
        /// <summary>
        /// 根据菜品id和做法id修改删除状态
        /// <para>modify the Deleted by the </para>
        /// </summary>
        /// <param name="deleted">deleted 删除状态，0表示正常 1表示删除</param>
        /// <returns>return true if modify success,else if return false</returns>
        bool ModifyDeleted(int dishesId, int DishesWayId);
        /// <summary>
        /// 根据菜品id查找全部的做法关联
        /// </summary>
        /// <param name="dishesId">菜品id</param>
        /// <returns>return the list of DischesWayRef if result if is nor null,else if return null</returns>
        List<DischesWayRef> QueryAllByDishesId(int dishesId);
    }
}
