using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics2.Entity.DTO;
using WebAPINubimetrics2.Interface;

namespace WebAPINubimetrics2.BusinessLogic
{
    public class BSCurrencyService: IBSCurrency
    {

        public List<Currency> ObtenerMonedas(string response)
        {
            try
            {

                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<List<Currency>>(response);
                }
                else
                    throw new BSErrorCurrencyException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public CurrencyConversion ObtenerMonedaConversion(string response)
        {
            try
            {
                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<CurrencyConversion>(response);
                }
                else
                    throw new BSErrorCurrencyException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public List<Currency> ObtenerMonedasConConversion(string responseCurrency, string responseCurrencyConv)
        //{
        //    try
        //    {
        //        //obtener monedas
        //        var listaMonedas = ObtenerMonedas(responseCurrency);
        //        //obtener convesion monedas 
        //        var monedaConvertida = ObtenerMonedaConversion(responseCurrencyConv);
        //        //fusionar

        //        //si obtengo datos desde la API los convierto a un objeto y los retorno
        //        if (!string.IsNullOrEmpty(idMoneda))
        //        {
        //            var dataObj = JObject.Parse(idMoneda);
        //            return dataObj.ToObject<List<Currency>>();
        //        }
        //        else
        //            throw new BSErrorPaisException();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
