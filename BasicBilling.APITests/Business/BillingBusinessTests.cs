using BasicBilling.API.ContextMemory;
using BasicBilling.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BasicBilling.API.Business.Tests
{
    [TestClass()]
    public class BillingBusinessTests
    {
        [TestMethod()]
        public void GetBillsTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new BillingBusiness<DbContextMemory>(context).GetBills(new GetBillsDto { Service = 1, User = 100, State = 1 });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Any()) ? true : false, true);
            }
        }

        [TestMethod()]
        public void GetBillsErrorTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new BillingBusiness<DbContextMemory>(context).GetBills(new GetBillsDto { Service = 6, User = 100, State = 1 });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Any()) ? true : false, false);
            }
        }

        [TestMethod()]
        public void PayBillTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new BillingBusiness<DbContextMemory>(context).PayBill(new PayBillDto { User = 200, ServiceBill = 2, DateBill = DateTime.Now.ToString("yyyyMM") });
                context.Dispose(context);
                Assert.AreEqual(result.IsOk, true);
            }
        }

        [TestMethod()]
        public void PayBillErrorTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new BillingBusiness<DbContextMemory>(context).PayBill(new PayBillDto { User = 600, ServiceBill = 20, DateBill = DateTime.Now.ToString("yyyyMM") });
                context.Dispose(context);
                Assert.AreEqual(result.IsOk, false);
            }
        }
    }
}