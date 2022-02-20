using Microsoft.AspNetCore.Mvc;
using System;
using WebAPINubimetrics.Entity.Enums;
using WebAPINubimetrics.Interface;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.BusinessLogic.Exceptions;

namespace WebAPINubimetrics.Controllers
{
    /// <summary>
    /// Controller utilizado para representar el servicio MercadoLibre
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoLibreController : ControllerBase
    {
        #region private members
        
        private readonly IBSExternalServices _externalServices;
        private readonly IBSPais _paisService;
        private readonly IBSBusqueda _busquedaService;
        private readonly IBSConexionApi _conexionApi;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor del controller MercadoLibre
        /// </summary>
        /// <param name="externalServices"></param>
        /// <param name="paisService"></param>
        /// <param name="busquedaService"></param>
        /// <param name="conexionApi"></param>
        public MercadoLibreController(IBSExternalServices externalServices, IBSPais paisService, IBSBusqueda busquedaService, IBSConexionApi conexionApi)
        {
            _externalServices = externalServices;
            _paisService = paisService;
            _busquedaService = busquedaService;
            _conexionApi = conexionApi;
        }

        #endregion

        #region endpoints     

        #region punto1Paises

        // GET api/<MercadoLibreController>/Paises/PAIS
        [HttpGet("Paises/{idPais}")]
        public ActionResult<PaisDTO> GetPaises(string idPais)
        {
            try
            {
                if (idPais.ToUpper().Trim() != IDPaises.ARGENTINA)
                    return Unauthorized(); //"paises no autorizados"
                else
                {
                    //obtenemos los datos para realizar la conexion a la API
                    var extServData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "Countries");

                    if (extServData != null)
                    {                        
                        //se obtiene el pais enviando por parametro el response que devuelve la conexion a la API de ML y el ID del pais ingresado 
                        return _paisService.ObtenerPais(_conexionApi.ConectarApi(extServData.BaseUrl, idPais.ToUpper().Trim()));
                    }
                    else
                        throw new BSJsonDataException();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        // GET api/<MercadoLibreController>/Busqueda
        [HttpGet("Busqueda/{producto}")]
        public ActionResult<BusquedaDTO> GetBusqueda(string producto)
        {
            try
            {
                if (string.IsNullOrEmpty(producto))
                    return NotFound("Producto vacio o nulo");
                else
                {
                    //obtenemos los datos para realizar la conexion a la API
                    var extServData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "Search");

                    if (extServData != null)
                    {
                        //se realiza la busqueda enviando por parametro el response que devuelve la conexion a la API de ML y el texto ingresado
                        return Ok(_busquedaService.Buscar(_conexionApi.ConectarApi(extServData.BaseUrl, producto.ToUpper().Trim())));

                    }
                    else
                        throw new BSJsonDataException();
                }
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
