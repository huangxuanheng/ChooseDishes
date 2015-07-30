using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.Service
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
        List<DischesWay> FindAllDishesWay(int wayId);
    }
}
