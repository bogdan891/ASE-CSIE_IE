using System;

namespace Charts.Entities
{
    public class Stock
    {
        public Guid CompanyId { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
    }
}
