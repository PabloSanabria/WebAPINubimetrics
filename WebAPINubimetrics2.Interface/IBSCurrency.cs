﻿using System;
using System.Collections.Generic;
using WebAPINubimetrics2.Entity.DTO;

namespace WebAPINubimetrics2.Interface
{
    public interface IBSCurrency
    {
        List<Currency> ObtenerMonedas(string response);
        CurrencyConversion ObtenerMonedaConversion(string response);
        void WriteCVS(string fileName, float data);
    }
}
