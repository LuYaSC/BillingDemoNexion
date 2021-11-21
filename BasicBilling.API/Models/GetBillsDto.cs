using System.ComponentModel.DataAnnotations;

namespace BasicBilling.API.Models
{
    public class GetBillsDto
    {
        public int User { get; set; }

        public int State { get; set; }

        public int Service { get; set; }

        public int Currency { get; set; }
    }
}
