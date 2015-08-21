using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.ChooseDishes.Api
{

    public interface IDiscountDataService
    {
        #region Observable 折扣方案管理 阙进午
        List<DiscountProgram> queryAll();
        DiscountProgram queryById(int id);
        List<DiscountDetail> queryByDetailId(int id);
        DishType LoadTypeById(int id);
        DishType LoadParentId(int? id);
        List<DishType> LoadSmallTypeAll();
        List<DishType> LoadBigTypeAll();
        int AddProgram(DiscountProgram Program);
        int AddDetail(DiscountDetail Detail);
        int UpdateProgram(DiscountProgram Program);
        int UpdateDetail(DiscountDetail Detail);
        bool DeleteProgram(int typeId);
        bool DeleteDetail(int typeId);
        
        #endregion Observable 折扣方案管理 阙进午



    }
}
