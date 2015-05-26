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
            user_item_pic good = SellService.ShowDetail(new Guid("a5c5ca86-122b-4bc4-8256-74345624c75f"));

            Console.WriteLine(SellService.ShowItemByUID(good.UID, 1).Count);
        }
    }
}
