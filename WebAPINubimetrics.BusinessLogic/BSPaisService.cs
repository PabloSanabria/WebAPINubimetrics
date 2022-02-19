using Newtonsoft.Json;
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
        /// <param name="response"></param>
        /// <returns></returns>
        public PaisDTO ObtenerPais(string response)
        {
            try
            {                
                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response)) {
                    return JsonConvert.DeserializeObject<PaisDTO>(response);
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
