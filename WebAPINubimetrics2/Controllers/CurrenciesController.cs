using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Interface;
using WebAPINubimetrics2.Entity.DTO;
using WebAPINubimetrics2.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPINubimetrics2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly IBSExternalServices _externalServices;
        private readonly IBSCurrency _currencyService;
        private readonly IBSConexionApi _conexionApi;

        public CurrenciesController(IBSExternalServices externalServices, IBSCurrency currencyService, IBSConexionApi conexionApi)
        {
            _externalServices = externalServices;
            _currencyService = currencyService;
            _conexionApi = conexionApi;
        }

        // GET: api/<CurrenciesController>
        [HttpGet]
        public ActionResult<IEnumerable<Currency>> Get()
        {
            try
            {
                var currencyData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "Currency");


                if (currencyData != null)
                {       //obtenermos datos del primer endpoint
                    var listaMonedas = _currencyService.ObtenerMonedas(_conexionApi.ConectarApi(currencyData.BaseUrl));

                    //Se quitan estos objetos de la lista, ya que la API devuelve Forbiden
                    listaMonedas = listaMonedas.Where(x => x.Id != "VEF" && x.Id != "VES").ToList();
         

                    foreach (var moneda in listaMonedas)
                    {      
                        var currencyConvData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "CurrencyConversion");
                        if (currencyConvData != null)
                        {
                            //obtengo datos del 2do endpoint
                            var monedaConv = _currencyService.ObtenerMonedaConversion(_conexionApi.ConectarApi(currencyConvData.BaseUrl, moneda.Id));

                            //asigno el valor obtenido de la conversion a la propiedad 
                            moneda.ToDolar = monedaConv;
                        }
                    }

                    //TODO: grabar en disco, json 

                    //TODO: grabar en disco, CSV

                    return listaMonedas;

                }
                else
                    throw new BSJsonDataException();

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<CurrenciesController>/Monedas/{idMoneda}
        //[HttpGet("{idMoneda}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


    }
}
