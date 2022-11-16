using AutoMapper;
using BasicBilling.API.Context.Entities;
using BasicBilling.API.Models;
using BasicBilling.API.Validations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicBilling.API.Business
{
    public class BillingBusiness<CONTEXT> : IBillingBusiness
        where CONTEXT : DbContext
    {
        DateTime start;
        Random gen;
        int range;
        CONTEXT context;
        IMapper mapper;

        public BillingBusiness(CONTEXT context)
        {
            this.context = context;
            start = new DateTime(2020, 1, 1);
            gen = new Random();
            range = (DateTime.Today - start).Days;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bill, BillsResult>()
                    .ForMember(d => d.NumberBill, o => o.MapFrom(s => s.Id))
                    .ForMember(d => d.Currency, o => o.MapFrom(s => s.BillCurrency.Name))
                    .ForMember(d => d.StateBill, o => o.MapFrom(s => s.BillState.Name))
                    .ForMember(d => d.ServiceBill, o => o.MapFrom(s => s.BillServiceType.Name))
                    .ForMember(d => d.DateBill, o => o.MapFrom(s => s.DateCreation))
                    .ForMember(d => d.UserAssigned, o => o.MapFrom(s => s.User.Name));
                cfg.CreateMap<BillPayment, BillsPayResult>()
                    .ForMember(d => d.Currency, o => o.MapFrom(s => s.Bill.BillCurrency.Name))
                    .ForMember(d => d.State, o => o.MapFrom(s => s.Bill.BillState.Name))
                    .ForMember(d => d.Service, o => o.MapFrom(s => s.Bill.BillServiceType.Name))
                    .ForMember(d => d.PayDate, o => o.MapFrom(s => s.DateCreation))
                    .ForMember(d => d.Amount, o => o.MapFrom(s => s.Bill.Amount))
                    .ForMember(d => d.AssingedUserName, o => o.MapFrom(s => s.Bill.User.Name))
                    .ForMember(d => d.PayUserName, o => o.MapFrom(s => s.User.Name));
            });
            mapper = new Mapper(config);
        }

        private DateTime Next() => start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));

        private int GetLastId<ENTITY>()
        where ENTITY : BaseLogicalDelete
        {
            var list = context.Set<ENTITY>().Where(x => !x.IsDeleted).ToList();
            return list.Any() ? list.Last().Id : 1;
        }

        private List<int> GetIds<ENTITY>()
        where ENTITY : BaseLogicalDelete => context.Set<ENTITY>().Where(x => !x.IsDeleted).Select(x => x.Id).ToList();

        private (bool isValid, string errors) ValidationModel<MODEL, VALIDATOR>(MODEL model, VALIDATOR validator)
            where MODEL : class
            where VALIDATOR : AbstractValidator<MODEL>
        {
            bool res = false;
            List<string> errors = new List<string>();
            ValidationResult result = validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    errors.Add($"Error in {error.PropertyName} {error.ErrorMessage}");
                }
            }
            res = result.IsValid;
            return (res, string.Join(",", errors.ToArray()));
        }

        private int PickRandom(List<int> source)
        {
            Random rnd = new Random();
            int randIndex = rnd.Next(source.Count);
            int random = source[randIndex];
            return random;
        }

        public Result<string> CreateBill(CreateBillDto dto)
        {
            var listCurrencies = GetIds<BillCurrency>();
            var listServices = GetIds<BillServiceType>();
            Random rnd = new Random();
            for (int i = 0; i < dto.Number; i++)
            {
                context.Add(new Bill
                {
                    UserId = dto.User,
                    ServiceTypeId = dto.Service == 0 ? PickRandom(listServices) : dto.Service,
                    CurrencyId = dto.Currency == 0 ? PickRandom(listCurrencies) : dto.Currency,
                    DateCreation = Next(),
                    StateId = 1,
                    Amount = new Random().Next(1, 1000)
                });
            }
            context.SaveChanges();
            return Result<string>.SetOk($"Create {dto.Number} Bill Success");
        }



        public Result<List<BillsResult>> GetBills(GetBillsDto dto)
        {
            var validations = ValidationModel(dto, new GetBillsDtoValidator<CONTEXT>(context));
            if (!validations.isValid) return Result<List<BillsResult>>.SetError(validations.errors);

            var listBills = context.Set<Bill>().Include(x => x.User).Include(x => x.BillCurrency).Include(x => x.BillState).Include(x => x.BillServiceType)
                .Where(x => dto.User == 0 || x.UserId == dto.User)
                .Where(x => dto.Service == 0 || x.ServiceTypeId == dto.Service)
                .Where(x => dto.State == 0 || x.StateId == dto.State)
                .Where(x => dto.Currency == 0 || x.CurrencyId == dto.Currency)
                .Where(x => !x.BillCurrency.IsDeleted)
                .Where(x => !x.BillState.IsDeleted)
                .Where(x => !x.BillServiceType.IsDeleted).ToList();
            return listBills.Any() ? Result<List<BillsResult>>.SetOk(mapper.Map<List<BillsResult>>(listBills)) :
                Result<List<BillsResult>>.SetError("No records found");
        }

        public Result<string> PayBill(PayBillDto dto)
        {
            var validations = ValidationModel(dto, new PayBillDtoValidator<CONTEXT>(context));
            if (!validations.isValid) return Result<string>.SetError(validations.errors);

            var bills = context.Set<Bill>().Include(x => x.BillCurrency).Where(x => x.UserId == dto.User
                                           && x.ServiceTypeId == dto.ServiceBill && x.StateId == 1).OrderBy(x => x.DateCreation).ToList();

            string dateSearch = dto.DateBill.Replace("-", string.Empty);
            bills = bills.Where(x => x.DateCreation.ToString("yyyyMM").Contains(dateSearch)).ToList();

            if (!bills.Any()) return Result<string>.SetError($"There are no invoices for the date: {dto.DateBill}");

            foreach (var bill in bills)
            {
                bill.StateId = 2;
                bill.DateModification = DateTime.Now;
                context.Add(new BillPayment { DateCreation = DateTime.Now, IsDeleted = false, UserId = dto.User, BillId = bill.Id });
            }

            context.SaveChanges();
            return Result<string>.SetOk($"all the management bills were paid: {dto.DateBill}");
        }

        public Result<string> PayBillById(PayBillByIdDto dto)
        {
            var billToPay = context.Set<Bill>().Where(x => x.Id == dto.NumberBill).FirstOrDefault();

            if (billToPay == null) return Result<string>.SetError($"Bill not found, Please check");
            billToPay.StateId = 2;

            billToPay.DateModification = DateTime.Now;
            context.Add(new BillPayment { DateCreation = DateTime.Now, IsDeleted = false, UserId = billToPay.UserId, BillId = billToPay.Id });
            context.SaveChanges();

            return Result<string>.SetOk("Payment Success!");
        }
    }
}
