using Newtonsoft.Json.Linq;
using System;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.Interface;

namespace WebAPINubimetrics.BusinessLogic
{
    public class BSPaisService : IBSPais
    {
       
        /// <summary>
        /// Método utilizado para obtener un pais
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="idPais"></param>
        /// <returns></returns>
        public PaisDTO ObtenerPais(string response)
        {
            try
            {                
                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response)) {
                    var dataObj = JObject.Parse(response);
                    return dataObj.ToObject<PaisDTO>();
                }
                else
                    throw new BSErrorPaisException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

    }
}
