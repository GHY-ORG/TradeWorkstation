using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;

namespace TradeWorkstation.Tests.Common
{
    [TestClass]
    public class LoggerTest
    {
        private ILogger logger = Logger.GetImpl();
        [TestMethod]
        public void TestAddLog()
        {
            Assert.IsTrue(logger.AddLog("系统故障~！"));
        }
    }
}
