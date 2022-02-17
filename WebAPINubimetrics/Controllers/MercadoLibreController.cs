﻿using Microsoft.AspNetCore.Mvc;
using System;
using WebAPINubimetrics.Entity.Enums;
using WebAPINubimetrics.Interface;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using System.Collections.Generic;

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
        private readonly IBSConexionApi _conexionApi;

        public MercadoLibreController(IBSExternalServices externalServices, IBSPais paisService, IBSBusqueda busquedaService, IBSConexionApi conexionApi)
        {
            _externalServices = externalServices;
            _paisService = paisService;
            _busquedaService = busquedaService;
            _conexionApi = conexionApi;
        }

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
                    var extServData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "Countries");

                    if (extServData != null)
                    {                        
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
        public ActionResult<List<ProductoDTO>> GetBusqueda(string producto)
        {
            try
            {
                if (string.IsNullOrEmpty(producto))
                    return NotFound("Producto vacio o nulo");
                else
                {
                    var extServData = _conexionApi.ObtenerDatosJson(_externalServices.GetData("../WebAPINubimetrics/ExternalServices.json"), "Search");

                    if (extServData != null)
                    {
                        return Ok(_busquedaService.ObtenerProducto(_conexionApi.ConectarApi(extServData.BaseUrl, producto.ToUpper().Trim())));

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
    }
}
