using System;
using System.ComponentModel.DataAnnotations;

namespace BasicBilling.API.Context.Entities
{
    public class BillState : BaseLogicalDelete , IDescription
    {
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
