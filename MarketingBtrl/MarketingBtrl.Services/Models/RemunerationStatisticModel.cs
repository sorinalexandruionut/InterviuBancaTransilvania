namespace MarketingBtrl.Services.Models
{
    public class RemunerationStatisticModel
    {
        public int Month { get; set; }
        public int Year { get; set; }

        public string Retailer { get; set; }
        public string Product { get; set; }

        public int ProductsNr { get; set; }
    }
}
