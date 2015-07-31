using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.Service
{
    [ServiceContract(Namespace = "www.IShow.com", CallbackContract = typeof(IChooseDishesDataServiceCallback))]
    public interface IDischesWayDataService
    {
        /**添加做法*/
        bool AddDischesWay(DischesWay odw);
        /**根据做法对象作为参数修改做法*/
        bool UpdateDischesWay(DischesWay odw);
        /**根据指定编码删除对应做法*/
        bool DeleteDischesWay(int code);
        /**根据做法类型编号查询做法*/
        List<DischesWay> FindAllDischesWay(int wayId);
    }
}
