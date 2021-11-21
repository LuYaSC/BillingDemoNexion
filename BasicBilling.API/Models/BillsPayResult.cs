using System;

namespace BasicBilling.API.Models
{
    public class BillsPayResult
    {
        public string AssingedUserName { get; set; }

        public string PayUserName { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Service { get; set; }

        public string State { get; set; }

        public DateTime PayDate { get; set; }
    }
}
