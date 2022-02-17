using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.Interface;

namespace WebAPINubimetrics.BusinessLogic
{
    public class BSBusquedaService:IBSBusqueda
    {

        /// <summary>
        /// Método obtener una lista de productos
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public List<ProductoDTO> ObtenerProducto(string response)
        {
            try
            {
                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response))
                {
                    var dataObj = JObject.Parse(response);

                    var results = dataObj["results"].ToObject<List<JObject>>();

                    List<ProductoDTO> prodList = new();

                    foreach (var item in results)
                    {
                        //desde aqui obtenemos los datos necesarios
                        ProductoDTO prod = item.ToObject<ProductoDTO>();
                       
                        prodList.Add(prod);
                    }

                    return prodList;
                }
                else
                    throw new BSErrorBusquedaException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
