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
    }
}
