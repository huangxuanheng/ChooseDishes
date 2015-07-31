
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
   
    public interface IDishService
    {
        #region
        
        List<DishType> LoadType(DishType type);

       
        Hashtable SaveType(DishType type);

        
        bool UpdateType(DishType type);

        
        bool DeleteType(DishType type);

        
        List<DishType> LoadTypeById(int id);
        #endregion
    }
}
