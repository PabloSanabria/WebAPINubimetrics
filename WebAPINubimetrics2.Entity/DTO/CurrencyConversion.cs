using System;

namespace WebAPINubimetrics2.Entity.DTO
{
    public class CurrencyConversion
    {
        public string Currency_Base { get; set; }
        public string Currency_Quote { get; set; }
        public float Ratio { get; set; }
        public float Rate { get; set; }
        public float Inv_Rate { get; set; }
        public string Creation_Date { get; set; }
        public string Valid_Until { get; set; }
    }
}
