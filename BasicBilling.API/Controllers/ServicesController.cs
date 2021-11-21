using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Business;
using BasicBilling.API.Business.Parameters;
using BasicBilling.API.Context.Entities;
using BasicBilling.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServicesController : ControllerBase
    {
        IParameterBusiness<BillServiceType> service;

        public ServicesController(IParameterBusiness<BillServiceType> service)
        {
            this.service = service;
        }

        [HttpPost]
        public Result<string> Create([FromBody] ParameterDto dto) => service.Create(dto);

        [HttpPost]
        public Result<string> Update([FromBody] ParameterDto dto) => service.Update(dto);

        [HttpPost]
        public Result<string> Delete([FromBody] ParameterDto dto) => service.Delete(dto);

        [HttpGet]
        public Result<List<ParameterResult>> Get() => service.Get();
    }
}
