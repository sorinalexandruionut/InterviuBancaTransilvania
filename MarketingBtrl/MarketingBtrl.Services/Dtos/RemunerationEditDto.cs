using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingBtrl.Services.Dtos
{
    public class RemunerationEditDto
    {
        public int? Id { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int ProductId { get; set; }

        public int RetailerId { get; set; }

        public int Bonus { get; set; }
    }
}
