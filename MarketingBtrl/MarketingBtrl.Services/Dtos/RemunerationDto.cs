
namespace MarketingBtrl.Services.Dtos
{
    public class RemunerationDto
    {
        public int Id { get; set; }
        public string Product { get; set; }

        public string Retailer { get; set; }


        public int Month { get; set; }

        public int Year { get; set; }

        public int Bonus { get; set; }

        public int ProductId { get; set; }

        public int RetailerId { get; set; }
    }
}
