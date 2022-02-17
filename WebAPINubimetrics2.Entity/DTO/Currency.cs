using System;

namespace WebAPINubimetrics2.Entity.DTO
{
    public class Currency
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public int Decimal_Places { get; set; }
        public CurrencyConversion ToDolar { get; set; }
    }
}
