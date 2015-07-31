using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using IShow.Service.Data;

namespace IShow.Service
{
    [ServiceContract(Namespace = "www.IShow.com", CallbackContract = typeof(IChooseDishesDataServiceCallback))]
    public interface IChooseDishesDataService
    {
        [OperationContract]
        bool Login(string name, string password);
        [OperationContract]
        IEnumerable<string> GetAllName();

        [OperationContract]
        List<Location> queryByLocation();
        [OperationContract]
        int addLocation(string name, string no);
        [OperationContract]
        int editByLocation(string id, string name, string no);
        [OperationContract]
        int delByLocation(string id);

        //加载所有的收银方式  传入收银类型编号
        [OperationContract]
        List<CashType> findCashType(int CashBaseTypeId);
        //添加收银方式 返回添加成功后的收银方式
        [OperationContract]
        CashType addCashType(CashType cashType);
        //修改收银方式  返回修改成功后的方式
        [OperationContract]
        CashType updateCashType(CashType cashType);
        //删除收银方式 返回true 为修改成功
        [OperationContract]
        bool deleteCashType(int Id);
    }
}
