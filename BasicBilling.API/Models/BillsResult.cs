using System;

namespace BasicBilling.API.Models
{
    public class BillsResult
    {
        public int NumberBill { get; set; }

        public string UserAssigned { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string StateBill { get; set; }

        public string ServiceBill { get; set; }

        public DateTime DateBill { get; set; }
    }
}
