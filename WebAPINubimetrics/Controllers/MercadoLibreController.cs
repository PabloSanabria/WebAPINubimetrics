using Microsoft.AspNetCore.Mvc;
using System;
using WebAPINubimetrics.Entity.Enums;
using System.Linq;
using WebAPINubimetrics.Interface;
using Newtonsoft.Json;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.BusinessLogic.Exceptions;

namespace WebAPINubimetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoLibreController : ControllerBase
    {
        //private readonly DbApiContext _contextBD;
        private readonly IBSExternalServices _externalServices;
        private readonly IBSPais _paisService;
        private readonly IBSBusqueda _busquedaService;

        public MercadoLibreController(IBSExternalServices externalServices, IBSPais paisService, IBSBusqueda busquedaService)
        {
            _externalServices = externalServices;
            _paisService = paisService;
            _busquedaService = busquedaService;
        }

        // GET api/<MercadoLibreController>/Paises/PAIS
        [HttpGet("Paises/{idPais}")]
        public ActionResult<PaisDTO> GetPaises(string idPais)
        {
            try
            {
                if (idPais.ToUpper().Trim() != IDPaises.ARGENTINA)
                    return Unauthorized();//"paises no autorizados"
                else
                {
                    var jsonData = _externalServices.GetData("../WebAPINubimetrics/ExternalServices.json");

                    ExternalServiceDTO extServ = JsonConvert.DeserializeObject<ExternalServiceDTO>(jsonData);

                    //Obtengo el dato que me interesa del objeto
                    var extServData = extServ.ExternalServices.FirstOrDefault(x => x.Nombre == "Countries");

                    if (extServData != null)
                    {
                        return _paisService.ObtenerPais(extServData.BaseUrl, idPais.ToUpper().Trim());

                    }
                    else
                        throw new BSJsonDataException();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET api/<MercadoLibreController>/Busqueda
        [HttpGet("Busqueda/{producto}")]
        public ActionResult<ProductoDTO> GetBusqueda(string producto)
        {
            try
            {
                if (string.IsNullOrEmpty(producto))
                    return NotFound("RESPONSE CODE: 404 - Producto vacio o nulo");
                else
                {
                    var jsonData = _externalServices.GetData("../WebAPINubimetrics/ExternalServices.json");

                    ExternalServiceDTO extServ = JsonConvert.DeserializeObject<ExternalServiceDTO>(jsonData);

                    //Obtengo el dato que me interesa del objeto
                    var extServData = extServ.ExternalServices.FirstOrDefault(x => x.Nombre == "Search");

                    if (extServData != null)
                    {
                        return _busquedaService.ObtenerProducto(extServData.BaseUrl, producto.ToUpper().Trim());

                    }
                    else
                        throw new BSJsonDataException();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
