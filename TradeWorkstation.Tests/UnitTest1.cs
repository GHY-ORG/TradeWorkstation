using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSource;
using DAL;
using BLL;

namespace TradeWorkstation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //user_item_pic good = SellService.ShowDetail(new Guid("a5c5ca86-122b-4bc4-8256-74345624c75f"));
            CarPoolService carPoolService = new CarPoolService();
            var results = carPoolService.ShowItemByTag("西南财经大学柳林校区", 1);
            Console.WriteLine(results.Count);
        }
    }
}