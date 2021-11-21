using BasicBilling.API.ContextMemory;
using BasicBilling.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BasicBilling.API.Business.Parameters;
using BasicBilling.API.Context.Entities;

namespace BasicBilling.API.Tests
{
    [TestClass()]
    public class ServicesParameterTests
    {
        [TestMethod()]
        public void CreateServiceTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillServiceType>(context).Create(new ParameterDto { Name = "Service Test" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void UpdateServiceTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillServiceType>(context).Update(new ParameterDto { Code = 1, Name = "Service Test Modified" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void DeleteServiceTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillServiceType>(context).Delete(new ParameterDto { Code = 1, State = true });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Contains("Success")) ? true : false, true);
            }
        }

        [TestMethod()]
        public void GetServicesTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillServiceType>(context).Get();
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Any()) ? true : false, true);
            }
        }
    }
}