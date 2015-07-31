using IShow.Service.Data;
using IShow.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShowOrderUnitTest
{
    [TestClass]
    public class TakeoutOrderUnitTest
    {
        //添加外卖客户信息
        [TestMethod]
        public void AddTakeoutClientInfo()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();
            int m=new Random().Next(100);
            TakeoutClientInfo tc = new TakeoutClientInfo()
            {
                OrderPeopleId=m,
                Order_people = "huangxianheng",
                Telephone = "0777578663",
                Mobile = "1599464343",
                Address="深圳市福田区泰然九路海松大厦",
                Create_by=1,
                Create_datetime=DateTime.Now,
                Deleted=0,
                Status=0
            };

            Assert.IsTrue(at.AddTakeoutClientInfo(tc));
        }
        //修改修改外卖客户信息
        [TestMethod]
        public void UpdateTakeoutClientInfo()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();
            TakeoutClientInfo tc = new TakeoutClientInfo()
            {
                OrderPeopleId = 2,
                Order_people = "liening",
                Telephone = "0777578663" ,
                Mobile = "15994643437",
                Address = "深圳市福田区泰然九路海松大厦",
                Deleted = 1,
                Status = 0,
                Update_datetime=DateTime.Now,
                Update_by=1
            };

            Assert.IsTrue(at.UpdateTakeoutClientInfo(tc));
        }
        //删除外卖客户信息
        [TestMethod]
        public void DeletedTakeoutClientInfo()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();
            Assert.IsTrue(at.DeletedTakeoutClientInfo(2));
        }
        //查询全部外卖客户信息
        [TestMethod]
        public void FindAllTakeoutClientInfo()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();
            Assert.IsNotNull(at.FindAllTakeoutClientInfo());
        }
        //根据指定id查询外卖人信息
        [TestMethod]
        public void FindTakeoutClientInfo()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();
            Assert.IsNotNull(at.FindTakeoutClientInfoById(15));
        }




        //添加外卖订单
        [TestMethod]
        public void AddTakeoutOrder()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();
            TakeoutOrder to = new TakeoutOrder()
            {
                OrderId=new Random().Next(10000)+1,
                OrderPeopleId=15,
                DeliveryManNum="000b",
                Num="001",
                AdvanceAmount=200,
                DeliverTime=DateTime.Now,
                SendTime=DateTime.Now,
                CreateBy=1,
                CreateDatetime=DateTime.Now,
                Status=0,
                Deleted=0
            };
            Assert.IsTrue(at.AddTakeoutOrder(to));
        }
        //修改外卖订单
        [TestMethod]
        public void UpdateTakeoutOrder()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();
            TakeoutOrder to = new TakeoutOrder()
            {
                OrderId = 1694,
                TakeoutId=1,
                OrderPeopleId=14,
                DeliveryManNum = "aaa",
                Num = "003",
                AdvanceAmount = 500,
                DeliverTime = DateTime.Today,
                SendTime = DateTime.Today,
                Status = 0,
                Deleted = 0,
                UpdateBy=1,
                UpdateDatetime=DateTime.Now
            };
            Assert.IsTrue(at.UpdateTakeoutOrder(to));
        }
        //删除外卖订单
        [TestMethod]
        public void DeletedTakeoutOrder()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();

            Assert.IsTrue(at.DeletedTakeoutOrder(6));
        }
        //查询全部外卖订单
        [TestMethod]
        public void FindAllTakeoutOrder()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();

            Assert.IsNotNull(at.FindAllTakeoutOrder());
        }
        //根据指定订单号查询订单
        [TestMethod]
        public void FindTakeoutOrder()
        {
            TakeoutOrderDataService at = new TakeoutOrderDataService();

            Assert.IsNotNull(at.FindTakeoutOrderByOrderId(1694));
        }
    }
}
