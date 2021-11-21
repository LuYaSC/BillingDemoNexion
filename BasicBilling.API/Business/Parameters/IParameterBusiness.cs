using BasicBilling.API.Context.Entities;
using BasicBilling.API.Models;
using System.Collections.Generic;

namespace BasicBilling.API.Business.Parameters
{
    public interface IParameterBusiness<ENTITY>
        where ENTITY : BaseLogicalDelete, IDescription
    {
        Result<string> Create(ParameterDto dto);

        Result<string> Update(ParameterDto dto);

        Result<string> Delete(ParameterDto dto);

        Result<List<ParameterResult>> Get();
    }
}
