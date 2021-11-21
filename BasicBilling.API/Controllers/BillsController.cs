using BasicBilling.API.Business;
using BasicBilling.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BillsController : ControllerBase
    {
        IBillingBusiness service;

        public BillsController(IBillingBusiness service) => this.service = service;

        [HttpPost]
        public Result<string> CreateBill([FromBody] CreateBillDto dto) => service.CreateBill(dto);

        [HttpPost]
        public Result<List<BillsResult>> GetBills([FromBody] GetBillsDto dto) => service.GetBills(dto);

        [HttpPost]
        public Result<string> PayBill([FromBody] PayBillDto dto) => service.PayBill(dto);

        [HttpPost]
        public Result<string> PayBillById([FromBody] PayBillByIdDto dto) => service.PayBillById(dto);
    }
}
