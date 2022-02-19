using Newtonsoft.Json;
using System;
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
        /// <param name="response"></param>
        /// <returns></returns>
        public BusquedaDTO ObtenerProducto(string response)
        {
            try
            {
                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<BusquedaDTO>(response);
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
