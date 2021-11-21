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
    public class UsersParameterTests
    {
        [TestMethod()]
        public void CreateUserTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, User>(context).Create(new ParameterDto { Name = "User Test" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, User>(context).Update(new ParameterDto { Code = 100, Name = "User Test Modified" });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body == "Success") ? true : false, true);
            }
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, User>(context).Delete(new ParameterDto { Code = 100, State = true });
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Contains("Success")) ? true : false, true);
            }
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            using (var context = new DbContextMemory(new DbContextOptionsBuilder<DbContextMemory>().UseInMemoryDatabase(databaseName: "BDBills").Options))
            {
                context.DataGenerator(context);
                var result = new ParameterBusiness<DbContextMemory, User>(context).Get();
                context.Dispose(context);
                Assert.AreEqual(!result.IsOk ? false : (result.IsOk && result.Body.Any()) ? true : false, true);
            }
        }
    }
}