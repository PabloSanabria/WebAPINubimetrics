using System.Collections.Generic;
using WebAPINubimetrics2.Entity.DTO;

namespace WebAPINubimetrics2.Interface
{
    public interface IBSCurrency
    {
        List<Currency> ObtenerMonedas(string response);
        CurrencyConversion ObtenerMonedaConversionUSD(string response);
        void WriteCVS(string fileName, float data);
        void WriteJSON(string fileName, List<Currency> listaMonedas);
        List<Currency> QuitarMonedas(ref List<Currency> listaMonedas, List<string> listaMonedasNoValidas);
        List<string> ObtenerMonedasNoValidas();
    }
}
