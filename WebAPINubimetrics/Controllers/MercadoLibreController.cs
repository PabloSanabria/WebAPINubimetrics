using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPINubimetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoLibreController : ControllerBase
    {
      

        // GET api/<MercadoLibreController>/Paises/PAIS
        [HttpGet("Paises/{Pais}")]
        public ActionResult<string> GetPaises(string Pais)
        {
            try
            {
                if (Pais != "AR")//TODO: hacer enum de codiogos de paises
                  return Unauthorized("pais no autorizado");
                else
                    return Ok();
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
                if (!string.IsNullOrEmpty(Producto))//TODO: hacer enum de codiogos de paises
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
