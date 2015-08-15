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
        bool Add(DischesWay odw);
        /**根据做法对象作为参数修改做法*/
        [OperationContract]
        bool Modify(DischesWay odw);
        /**根据指定编码删除对应做法*/
        [OperationContract]
        bool Deleted(int code);
        /**根据做法类型编号查询做法*/
        [OperationContract]
        List<DischesWay> FindAllDishesWayByTypeId(int Code);
        /**根据做法编码查找做法*/
        [OperationContract]
        DischesWay FindDishesWayByCode(string code);
        
        /// <summary>
        /// 根据id更新做法删除的状态
        /// </summary>
        /// <param name="id">做法id</param>
        /// <param name="deletedStatus">删除状态</param>
        /// <returns>删除成功返回true，否则false</returns>
        [OperationContract]
        bool UpdateDeletedById(int id,int deletedStatus);
        /// <summary>
        /// 查询所有的做法，包括状态为删除的
        /// query all of DishesWay 
        /// </summary>
        /// <returns>reutrn list of DishesWay</returns>
        [OperationContract]
        List<DischesWay> FindAll();

        [OperationContract]
        //添加菜品做法类型
        bool AddDishesWayName(DischesWayName dwn);
        [OperationContract]
        /**根据指定的类型名修改菜品做法类型名*/
        bool UpdateDishesWayName(DischesWayName dwn);
        //根据做法类型id修改删除状态
        [OperationContract]
        bool UpdateDishesWayNameDeletedTypeById(int id);
        //根据做法类型编码删除菜品做法类型
        [OperationContract]
        bool DeleteDishesWayNameByCode(int id);
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
