using BasicBilling.API.Models;
using System.Collections.Generic;

namespace BasicBilling.API.Business
{
    public interface IBillingBusiness
    {
        Result<string> CreateBill(CreateBillDto dto);

        Result<List<BillsResult>> GetBills(GetBillsDto dto);

        Result<string> PayBill(PayBillDto dto);

        Result<string> PayBillById(PayBillByIdDto dto);
    }
}
