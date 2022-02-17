using Newtonsoft.Json.Linq;
using System;
using System.Net;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.Interface;

namespace WebAPINubimetrics.BusinessLogic
{
    public class BSPaisService : IBSPais
    {

       
        /// <summary>
        /// Metdodo utilizado para conectarse con la API de ML y obtener un pais por medio de su Id
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="idPais"></param>
        /// <returns></returns>
        public PaisDTO ObtenerPais(string baseUrl, string idPais)
        {
            try
            {
                //conexion con API
                var client = new WebClient();
                var url = baseUrl.Replace("#IdPais#", idPais);
                var response = client.DownloadString(url);

                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response)) {
                    var dataObj = JObject.Parse(response);
                    return dataObj.ToObject<PaisDTO>();
                }
                else
                    throw new BSErrorPaisException();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
