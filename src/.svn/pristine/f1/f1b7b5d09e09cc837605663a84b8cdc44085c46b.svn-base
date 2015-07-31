using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.Service
{
    [ServiceContract(Namespace = "www.IShow.com", CallbackContract = typeof(IChooseDishesDataServiceCallback))]
    public interface IDischesWayNameDataService
    {
        [OperationContract]
        //添加菜品做法类型
        bool AddDischesWayName(DischesWayName dwn);
        [OperationContract]
        /**根据指定的类型名修改菜品做法类型名*/
        bool UpdateDischesWayName(DischesWayName dwn);
        //根据做法类型编码删除菜品做法类型
        bool DeleteDischesWayName(int id);
        //查询菜品做法类型
        List<DischesWayName> FindAllDischesWayName();
    }
}
