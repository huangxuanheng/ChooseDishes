using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.ChooseDishes
{
    [ServiceContract(Namespace = "www.IShow.com")]
    public interface IDishesWayDataService
    {
        /**添加做法*/
        [OperationContract]
        bool AddDishesWay(DischesWay odw);
        /**根据做法对象作为参数修改做法*/
        [OperationContract]
        bool UpdateDishesWay(DischesWay odw);
        /**根据指定编码删除对应做法*/
        [OperationContract]
        bool DeleteDishesWay(int code);
        /**根据做法类型编号查询做法*/
        [OperationContract]
        List<DischesWay> FindAllDishesWayByTypeCode(string Code);
        /**根据做法编码查找做法*/
        [OperationContract]
        DischesWay FindDishesWayByCode(int code);
        //根据id更新做法删除的状态
        [OperationContract]
        bool UpdateDishesWayDeletedTypeByCode(int Code);

        [OperationContract]
        //添加菜品做法类型
        bool AddDishesWayName(DischesWayName dwn);
        [OperationContract]
        /**根据指定的类型名修改菜品做法类型名*/
        bool UpdateDishesWayName(DischesWayName dwn);
        //根据做法类型id修改删除状态
        [OperationContract]
        bool UpdateDishesWayNameDeletedTypeByCode(string Code);
        //根据做法类型编码删除菜品做法类型
        [OperationContract]
        bool DeleteDishesWayNameByCode(string Code);
        //查询菜品做法类型
        [OperationContract]
        List<DischesWayName> FindAllDishesWayName();
        //根据菜品做法类型id查询菜品做法类型
        [OperationContract]
        DischesWayName FindDishesWayNameById(int id);
        //根据菜品做法类型编号查询菜品做法类型
        [OperationContract]
        DischesWayName FindDishesWayNameByCode(string code);
    }
}
