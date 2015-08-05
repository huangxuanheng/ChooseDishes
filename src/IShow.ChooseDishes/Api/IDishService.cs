
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
        #region
        
        List<DishType> LoadType(DishType type);

        List<DishType> LoadSubType(DishType type);

        Hashtable SaveType(DishType type);

        
        bool UpdateType(DishType type);

        
        bool DeleteType(DishType type);

        
        List<DishType> LoadTypeById(int id);
        #endregion


        #region 菜品單位
         List<DishUnit> QueryAllDishesUnits();

         int[] BatchAddDishesUnit(DishUnit[] dishesUnits);
        

         int AddDishesUnit(DishUnit dishesUnit);

        bool RemoveDishesUnitById(int dishUnitId);
        #endregion 菜品單位

    }
}
