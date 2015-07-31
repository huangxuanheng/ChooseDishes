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
            var f = dd.AddDischesWayName(dw);

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
            var f = dd.UpdateDischesWayName(dw);

        }
        [TestMethod]
        public void TestMethoddeleteDischesWayName()
        {
            DischesWayNameDataService dd = new DischesWayNameDataService();
            var f = dd.DeleteDischesWayName(1);

        }
        [TestMethod]
        public void TestMethodfindAllDischesWayName()
        {
            DischesWayNameDataService dd = new DischesWayNameDataService();
            var f = dd.FindAllDischesWayName();
        }


        [TestMethod]
        public void TestMethodAddDischesWay()
        {
            DischesWayDataService dd = new DischesWayDataService();
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
            var f = dd.AddDischesWay(dw);

        }

        [TestMethod]
        public void TestMethodupdateDischesWay()
        {
            DischesWayDataService dd = new DischesWayDataService();
            DischesWay dw = new DischesWay()
            {
                DischesWayId = 1,
                DischesWayNameId = 2,
                UpdateDatetime = DateTime.Now,
                UpdateBy = 1,
                Code = 1,
                AddPrice = 2,
                Deleted = 0,
                Name = "三分熟",
                Status = 0,
                AddPriceByNum = 0,
                PingYing = "sfsjl",
                WayDetail = "要三分熟"
            };
            var f = dd.UpdateDischesWay(dw);

        }
        [TestMethod]
        public void TestMethodDeleteDischesWay()
        {
            DischesWayDataService dd = new DischesWayDataService();
            var f = dd.DeleteDischesWay(1);

        }
    }
}
