using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.Service
{
    [ServiceContract(Namespace = "www.IShow.com")]
    public interface IDishesWayNameDataService
    {
        [OperationContract]
        //添加菜品做法类型
        bool AddDishesWayName(DischesWayName dwn);
        [OperationContract]
        /**根据指定的类型名修改菜品做法类型名*/
        bool UpdateDishesWayName(DischesWayName dwn);
        //根据做法类型编码删除菜品做法类型
        [OperationContract]
        bool DeleteDishesWayName(int id);
        //查询菜品做法类型
        [OperationContract]
        List<DischesWayName> FindAllDishesWayName();
        //根据菜品做法类型id查询菜品做法类型
        [OperationContract]
        DischesWayName FindDishesWayNameById(int id);
    }
}
