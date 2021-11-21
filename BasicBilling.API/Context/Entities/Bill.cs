using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicBilling.API.Context.Entities
{
    public class Bill : Base
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual BillCurrency BillCurrency { get; set; }

        [Column(TypeName = "decimal(19, 2)")]
        public decimal Amount { get; set; }

        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual BillState BillState { get; set; }

        public int ServiceTypeId { get; set; }

        [ForeignKey("ServiceTypeId")]
        public virtual BillServiceType BillServiceType { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }
    }
}
