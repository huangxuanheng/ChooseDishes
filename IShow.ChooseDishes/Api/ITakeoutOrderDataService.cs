using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.Service.Services
{
    [ServiceContract(Namespace = "www.IShow.com")]
    public interface ITakeoutOrderDataService
    {
        //添加外卖客户信息
        [OperationContract]
        bool AddTakeoutClientInfo(TakeoutClientInfo info);
        //根据外卖客户id修改外卖客户信息
        [OperationContract]
        bool UpdateTakeoutClientInfo(TakeoutClientInfo info);
        //根据外卖客户id删除外卖客户信息
        [OperationContract]
        bool DeletedTakeoutClientInfoById(int id);
        //根据外卖客户id查找外卖客户信息
        [OperationContract]
        TakeoutClientInfo FindTakeoutClientInfoById(int id);
        //查找全部的外卖客户信息
        [OperationContract]
        List<TakeoutClientInfo> FindAllTakeoutClientInfo();
        //根据外卖客户id修改外卖客户Deleted状态
        [OperationContract]
        bool UpdateTakeoutClientDeletedById(int id, int DeletedStatas);
        //根据订餐人电话号码查找订餐人信息
        [OperationContract]
        TakeoutClientInfo FindTakeoutClientByTelephone(string phone);
        //根据订餐人电话号码进行模糊查询所有外卖客户人的信息
        [OperationContract]
        List<TakeoutClientInfo> FindTakeoutClientListByTelephone(string phone);


        //添加外卖单
        [OperationContract]
        bool AddTakeoutOrder(TakeoutOrder To);
        //修改外卖单
        [OperationContract]
        bool UpdateTakeoutOrder(TakeoutOrder To);
        //根据指定外卖单号删除外卖单
        [OperationContract]
        bool DeletedTakeoutOrder(int id);
        //查询所有外卖单
        [OperationContract]
        List<TakeoutOrder> FindAllTakeoutOrder();
        //根据指定外卖单号查询外卖单
        [OperationContract]
        TakeoutOrder FindTakeoutOrderByOrderId(int id);
    }
}
