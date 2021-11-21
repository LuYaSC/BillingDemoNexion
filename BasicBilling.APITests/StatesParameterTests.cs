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
    public class StatesParameterTests
    {
        [TestMethod()]
        public void CreateStateTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillState>(context).Create(new ParameterDto { Name = "State Test" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillState>(context).Update(new ParameterDto { Code = 1, Name = "State Test Modified" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void DeleteStateTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillState>(context).Delete(new ParameterDto { Code = 1, State = true });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Contains("Success")) ? true : false, true);
            }
        }

        [TestMethod()]
        public void GetStatesTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillState>(context).Get();
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Any()) ? true : false, true);
            }
        }
    }
}