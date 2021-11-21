using BasicBilling.API.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.Validations
{
    public class PayBillDtoValidator<CONTEXT> : BaseValidator<CONTEXT, PayBillDto>
        where CONTEXT: DbContext
    {
        public PayBillDtoValidator(CONTEXT context) : base(context)
        {
        }

        public override void CreateValidations()
        {
            RuleFor(x => x.User).NotEmpty().WithMessage("Not Empty");
            RuleFor(x => x.User).GreaterThan(0).WithMessage("Max. number of team members must be greater than 0");
            RuleFor(x => x.User).NotNull().WithMessage("Not null");
            RuleFor(x => x.User).Must(ValidateUser).WithMessage("Don´t Exist");
            RuleFor(x => x.DateBill).NotEmpty().WithMessage("Not Empty"); ;
            RuleFor(x => x.DateBill).NotNull().WithMessage("Not null");
            RuleFor(x => x.DateBill).Length(6, 7).WithMessage("Values between 6 and 7");
            RuleFor(x => x.ServiceBill).NotEmpty().WithMessage("Not Empty");
            RuleFor(x => x.ServiceBill).GreaterThan(0).WithMessage("Max. number of team members must be greater than 0");
            RuleFor(x => x.ServiceBill).NotNull().WithMessage("Not null");
            RuleFor(x => x.ServiceBill).Must(ValidateService).WithMessage("Don´t Exist");
        }
    }
}
