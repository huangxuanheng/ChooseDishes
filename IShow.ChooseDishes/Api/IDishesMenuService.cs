﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;

namespace IShow.ChooseDishes.Api
{
   public interface IDishesMenuService
    {
       List<DishesMenu> QueryAll();

       int Add(string code,string name);
       //修改菜牌
       bool update(int menusId , string code, string name);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="dishesMenuId"></param>

       void Delete(int dishesMenuId);

       /// <summary>
       /// 批量关联菜谱的菜品
       /// </summary>
       /// <param name="menuId"></param>
       /// <param name="dishesIds"></param>
        void BatchAddDishes(int menuId, int[] dishesIds);

        void BatchRemoveDishes(int menuId, int[] dishesIds);

        List<DishesMenuItemModel> FindItemsById(int menuId);
        DishesMenu FindDishesMenuByMenuId(int menuId);

    }
}
