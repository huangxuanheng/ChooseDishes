
using IShow.ChooseDishes.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.ChooseDishes
{
   
    public interface IDishService
    {
        #region 菜品类别

        /**查询所有类型*/
        List<DishType> LoadType();

        /**查询所有子类*/
        List<DishType> LoadSubType();

        /**查询所有大类*/
        List<DishType> LoadFatherType();

        /**根据ID查询其下子类**/
        List<DishType> LoadSubTypeById(int Id);

        /**根据ID查询其父类*/
        DishType LoadFatherTypeById(int Id);

        /**根据ID查询类型*/
        DishType LoadTypeById(int id);

        /**新增类型*/
        Hashtable SaveType(DishType type);

        /**修改类型*/
        bool UpdateType(DishType type);

        /*删除类型*/
        bool DeleteType(int typeId);
        #endregion


        #region 菜品單位
         List<DishUnit> QueryAllDishesUnits();

         int[] BatchAddDishesUnit(DishUnit[] dishesUnits);
        

         int AddDishesUnit(DishUnit dishesUnit);

        bool RemoveDishesUnitById(int dishUnitId);
        #endregion 菜品單位

    }
}
