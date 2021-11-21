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
    public class CurrenciesParameterTests
    {
        [TestMethod()]
        public void CreateCurrencyTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillCurrency>(context).Create(new ParameterDto { Name = "Currency Test" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void UpdateCurrencyTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillCurrency>(context).Update(new ParameterDto { Code = 1, Name = "Currency Test Modified" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void DeleteCurrencyTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillCurrency>(context).Delete(new ParameterDto { Code = 1, State = true });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Contains("Success")) ? true : false, true);
            }
        }

        [TestMethod()]
        public void GetCurrencysTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, BillCurrency>(context).Get();
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Any()) ? true : false, true);
            }
        }
    }
}