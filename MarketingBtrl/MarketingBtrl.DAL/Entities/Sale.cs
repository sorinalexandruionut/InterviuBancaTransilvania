namespace MarketingBtrl.DAL.Entities
{
    public class Remuneration
    {
        public int Id { get; set; }

        public int RetailerId { get; set; }

        public Retailer Retailer { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int Bonus { get; set; }
    }
}
