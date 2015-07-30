using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IShow.Service;
using IShow.Service.Data;

namespace IShowOrderUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAddDischesWayName()
        {
            DischesWayNameDataService dd=new DischesWayNameDataService();
            DischesWayName dw = new DischesWayName()
            {
                DischesWayNameId=2,
                Code="124",
                Name="avv",
                CreateBy=2,
                CreateDatetime=DateTime.Now,
                UpdateBy=1,    
                Status=0
            };
            var f = dd.AddDishesWayName(dw);

        }
        [TestMethod]
        public void TestMethodupdateDischesWayName()
        {
            DischesWayNameDataService dd = new DischesWayNameDataService();
            DischesWayName dw = new DischesWayName()
            {
                DischesWayNameId = 2,
                Code = "123",
                Name = "是的该死的",
                UpdateBy = 2,
                Status=1,
                UpdateDatetime=DateTime.Now
            };
            var f = dd.UpdateDishesWayName(dw);
        }
        [TestMethod]
        public void TestMethoddeleteDischesWayName()
        {
            DischesWayNameDataService dd = new DischesWayNameDataService();
            var f = dd.DeleteDishesWayName(1);
            Console.WriteLine(f+"");
        }
        [TestMethod]
        public void TestMethodfindAllDischesWayName()
        {
            DischesWayNameDataService dd = new DischesWayNameDataService();
            var f = dd.FindAllDishesWayName();
        }


        [TestMethod]
        public void TestMethodAddDischesWay()
        {
            DishesWayDataService dd = new DishesWayDataService();
            DischesWay dw = new DischesWay()
            {
               DischesWayId=1,
               DischesWayNameId=2,
               CreateDatetime=DateTime.Now,
               CreateBy=1,
               Code=1,
               AddPrice=2,
               Deleted=0,
               Name="三分熟加辣",
               Status=0,
               AddPriceByNum=0,
               PingYing="sfsjl",
               WayDetail="要三分熟就可以了"
            };

            var f = dd.AddDishesWay(dw);
            var d = dd.AddDishesWay(null);
        }

        [TestMethod]
        public void TestMethodupdateDischesWay()
        {
            DishesWayDataService dd = new DishesWayDataService();
            DischesWay dw = new DischesWay()
            {
                DischesWayId = 2,
                DischesWayNameId = 2,
                UpdateDatetime = DateTime.Now,
                UpdateBy = 1,
                Code = 1,
                AddPrice = 2,
                Deleted = 0,
                Name = "三分熟1111",
                Status = 0,
                AddPriceByNum = 0,
                PingYing = "sfsjl",
                WayDetail = "要三分熟5555"
            };
            var f = dd.UpdateDishesWay(dw);

        }
        [TestMethod]
        public void TestMethodDeleteDischesWay()
        {
            DishesWayDataService dd = new DishesWayDataService();
            var f = dd.DeleteDishesWay(2);
            Assert.IsFalse(f);
        }

    }
}
