using System;
using System.ComponentModel.DataAnnotations;

namespace BasicBilling.API.Context.Entities
{
    public class BillServiceType : BaseLogicalDelete, IDescription
    {
        [MaxLength(60)]
        public string Name { get; set; }

    }
}
