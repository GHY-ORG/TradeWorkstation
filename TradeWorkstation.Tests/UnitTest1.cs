using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSource;
using DAL;

namespace TradeWorkstation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BuyHandler buy = new BuyHandler();

            var item2 = new Item {
                IID=Guid.NewGuid(),
                Title="Test",
                CID=6,
                UID = Guid.NewGuid(),
                Type=1,
                Detail="Test.....",
                Bargain=0,
                Priority=0,
                EndTime=DateTime.Now
            };
            Console.WriteLine(buy.Create(item2));
        }
    }
}
