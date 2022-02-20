using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Interface;
using WebAPINubimetrics2.Entity.DTO;
using WebAPINubimetrics2.Interface;


namespace WebAPINubimetrics2.Controllers
{
    /// <summary>
    /// Controller utilizado para representar el servicio Currencies
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        #region private members

        private readonly IBSExternalServices _externalServices;
        private readonly IBSCurrency _currencyService;
        private readonly IBSConexionApi _conexionApi;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor del controller Currencies
        /// </summary>
        /// <param name="externalServices"></param>
        /// <param name="currencyService"></param>
        /// <param name="conexionApi"></param>
        public CurrenciesController(IBSExternalServices externalServices, IBSCurrency currencyService, IBSConexionApi conexionApi)
        {
            _externalServices = externalServices;
            _currencyService = currencyService;
            _conexionApi = conexionApi;
        }

        #endregion

        #region endpoints     

        #region punto2Currencies

        // GET: api/<CurrenciesController>
        [HttpGet]
        public ActionResult<IEnumerable<Currency>> Get()
        {
            try
            {
                //obtenemos los datos para realizar la conexion a la API
                var currencyData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "Currency");

                if (currencyData != null)
                {       //obtenermos datos del primer endpoint
                    var listaMonedas = _currencyService.ObtenerMonedas(_conexionApi.ConectarApi(currencyData.BaseUrl));

                    //IMPORTANTE: Se quitan estos objetos de la lista, ya que la API devuelve error: Forbidden
                    listaMonedas = listaMonedas.Where(x => x.Id != "VEF" && x.Id != "VES").ToList();
         

                    foreach (var moneda in listaMonedas)
                    {
                        //obtenemos los datos para realizar la conexion a la API
                        var currencyConvData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "CurrencyConversion");
                        
                        if (currencyConvData != null)
                        {
                            //obtengo datos del 2do endpoint
                            var monedaConv = _currencyService.ObtenerMonedaConversionUSD(_conexionApi.ConectarApi(currencyConvData.BaseUrl, moneda.Id));

                            //asigno el valor obtenido de la conversion a la propiedad 
                            moneda.ToDolar = monedaConv;

                            //creacion archivo CSV
                            _currencyService.WriteCVS(@"C:\Users\psanabria\source\repos\Ratio.csv", moneda.ToDolar.Ratio);
                        }
                    }

                    //creacion archivo JSON
                    _currencyService.WriteJSON(@"C:\Users\psanabria\source\repos\Currencies.json", listaMonedas);

                    return Ok(listaMonedas);

                }
                else
                    throw new BSJsonDataException();

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion

        #endregion

    }
}
