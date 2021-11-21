namespace BasicBilling.API.Models
{
    public class CreateBillDto
    {
        public int User { get; set; }

        public int Currency { get; set; }

        public int Service { get; set; }

        public int Number { get; set; }
    }
}
