using Microsoft.AspNetCore.Mvc;
using System;
using WebAPINubimetrics.Entity.Enums;
using System.Linq;
using WebAPINubimetrics.Interface;
using Newtonsoft.Json;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.BusinessLogic.Exceptions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPINubimetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoLibreController : ControllerBase
    {
        //private readonly DbApiContext _contextBD;
        //private readonly IBSJiraRequest _jiraRequest;
        private readonly IBSExternalServices _externalServices;
        private readonly IBSPais _paisService;

        public MercadoLibreController(IBSExternalServices externalServices, IBSPais paisService)
        {            
            _externalServices = externalServices;
            _paisService = paisService;
        }

        // GET api/<MercadoLibreController>/Paises/PAIS
        [HttpGet("Paises/{idPais}")]
        public ActionResult<PaisDTO> GetPaises(string idPais)
        {
            try
            {
                if (idPais.ToUpper().Trim() != IDPaises.ARGENTINA)
                  return Unauthorized();//"paises no autorizados"
                else { 
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
        [HttpGet("Busqueda/{Producto}")]
        public ActionResult<string> GetBusqueda(string Producto)
        {
            try
            {
                if (!string.IsNullOrEmpty(Producto))
                    return NotFound("RESPONSE CODE: 404 - Producto vacio o nulo");
                else
                    return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
