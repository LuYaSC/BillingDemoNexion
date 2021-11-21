using BasicBilling.API.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace BasicBilling.API.Models
{
    public class PayBillDto
    {
        public int User { get; set; }

        public int ServiceBill { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "Date length must be between {2} and {1}.", MinimumLength = 6)]
        public string DateBill { get; set; }
    }
}
