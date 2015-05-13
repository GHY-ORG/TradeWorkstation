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
                IID=new Guid(),
                Title="Test"
            };
            buy.Create(item2);
        }
    }
}
