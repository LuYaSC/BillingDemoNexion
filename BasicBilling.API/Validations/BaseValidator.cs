using BasicBilling.API.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BasicBilling.API.Validations
{
    public abstract class BaseValidator<CONTEXT, MODEL> : AbstractValidator<MODEL>
        where MODEL : class
        where CONTEXT : DbContext
    {
        CONTEXT context;
        public BaseValidator(CONTEXT context)
        {
            this.context = context;
            CreateValidations();
        }

        public abstract void CreateValidations();
        
        public  bool ValidateUser(int userId) => context.Set<User>().Where(x => (userId == 0 || x.Id == userId)).FirstOrDefault() == null ? false : true;

        public bool ValidateService(int serviceId) => context.Set<BillServiceType>().Where(x => (serviceId == 0 || x.Id == serviceId)).FirstOrDefault() == null ? false : true;

        public bool ValidateState(int stateId) => context.Set<BillState>().Where(x => (stateId == 0 ||x.Id == stateId)).FirstOrDefault() == null ? false : true;
    }
}
