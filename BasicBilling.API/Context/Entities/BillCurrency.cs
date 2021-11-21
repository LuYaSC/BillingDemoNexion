using System;
using System.ComponentModel.DataAnnotations;

namespace BasicBilling.API.Context.Entities
{
    public class BillCurrency : BaseLogicalDelete, IDescription
    {
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
