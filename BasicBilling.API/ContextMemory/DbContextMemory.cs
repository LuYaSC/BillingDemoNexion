using BasicBilling.API.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BasicBilling.API.ContextMemory
{
    public class DbContextMemory : DbContext
    {
        public DbContextMemory(DbContextOptions<DbContextMemory> options)
            : base(options) { }

        public void DataGenerator(DbContextMemory context)
        {
            context.Users.Add(new User { Id = 100, Name = "User Test 1", DateCreation = DateTime.Now, IsDeleted = false });
            context.Users.Add(new User { Id = 200, Name = "User Test 2", DateCreation = DateTime.Now, IsDeleted = false });
            context.Users.Add(new User { Id = 300, Name = "User Test 3", DateCreation = DateTime.Now, IsDeleted = false });

            context.BillCurrencies.Add(new BillCurrency { Id = 1, Name = "USD" });

            context.BillStates.Add(new BillState { Id = 1, Name = "PENDING" });
            context.BillStates.Add(new BillState { Id = 2, Name = "PAID" });

            context.BillServiceTypes.Add(new BillServiceType { Id = 1, Name = "GAS" });
            context.BillServiceTypes.Add(new BillServiceType { Id = 2, Name = "WATER" });
            context.BillServiceTypes.Add(new BillServiceType { Id = 3, Name = "LIGHT" });

            context.Bills.Add(new Bill { Amount = 1, CurrencyId = 1, ServiceTypeId = 1, StateId = 1, DateCreation = DateTime.Now, Id = 1, UserId = 100 });
            context.Bills.Add(new Bill { Amount = 2, CurrencyId = 1, ServiceTypeId = 2, StateId = 1, DateCreation = DateTime.Now, Id = 2, UserId = 200 });
            context.Bills.Add(new Bill { Amount = 3, CurrencyId = 1, ServiceTypeId = 3, StateId = 1, DateCreation = DateTime.Now, Id = 3, UserId = 300 });
            context.Bills.Add(new Bill { Amount = 4, CurrencyId = 1, ServiceTypeId = 1, StateId = 1, DateCreation = DateTime.Now, Id = 4, UserId = 100 });

            context.BillPayments.Add(new BillPayment { BillId = 1, UserId = 100, DateCreation = DateTime.Now, Id = 1, IsDeleted = false });

            context.SaveChanges();
        }

        public void Dispose(DbContextMemory context)
        {
            context.RemoveRange(context.BillPayments);
            context.RemoveRange(context.Bills);
            context.RemoveRange(context.BillStates);
            context.RemoveRange(context.BillCurrencies);
            context.RemoveRange(context.BillServiceTypes);
            context.RemoveRange(context.Users);
            context.SaveChanges();
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<BillCurrency> BillCurrencies { get; set; }

        public DbSet<BillState> BillStates { get; set; }

        public DbSet<BillServiceType> BillServiceTypes { get; set; }

        public DbSet<BillPayment> BillPayments { get; set; }
    }
}
