using BasicBilling.API.Context.Entities;
using BasicBilling.API.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BasicBilling.API.Validations
{
    public class GetBillsDtoValidator<CONTEXT> : BaseValidator<CONTEXT, GetBillsDto>
        where CONTEXT : DbContext
    {
        public GetBillsDtoValidator(CONTEXT context) : base(context)
        {
        }
        public override void CreateValidations()
        {
           // RuleFor(x => x.User).GreaterThan(0).WithMessage("Max. number of team members must be greater than 0");
            RuleFor(x => x.User).NotNull().WithMessage("Not null");
            RuleFor(x => x.User).Must(ValidateUser).WithMessage("Don´t Exist");
            //RuleFor(x => x.Service).GreaterThan(0).WithMessage("Max. number of team members must be greater than 0");
            RuleFor(x => x.Service).NotNull().WithMessage("Not null");
            RuleFor(x => x.Service).Must(ValidateService).WithMessage("Don´t Exist");
            //RuleFor(x => x.State).GreaterThan(0).WithMessage("Max. number of team members must be greater than 0");
            RuleFor(x => x.State).NotNull().WithMessage("Not null");
            RuleFor(x => x.State).Must(ValidateState).WithMessage("Don´t Exist");
        }
    }
}