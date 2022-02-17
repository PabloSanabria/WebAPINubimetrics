using Newtonsoft.Json;
using System.Linq;
using System.Net;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.Interface;

namespace WebAPINubimetrics.BusinessLogic
{
    public class BSConexionApiService : IBSConexionApi
    {

        /// <summary>
        /// Método utilizado para obtener los datos de un archivo Json
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="nombreCon"></param>
        /// <returns></returns>
        public ExternalServiceDataDTO ObtenerDatosJson(string jsonData, string nombreCon)
        {
            try
            {
                ExternalServiceDTO extServ = JsonConvert.DeserializeObject<ExternalServiceDTO>(jsonData);

                //Obtengo el dato que me interesa del objeto
                return extServ.ExternalServices.FirstOrDefault(x => x.Nombre == nombreCon);
            }
            catch (System.Exception)
            {
                throw new BSErrorConexionException();
            }
        }

        /// <summary>
        /// Método utilizado para conectarse con la API y obtener datos a partir de la url y un parametro
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="texto"></param>
        /// <returns></returns>
        public string ConectarApi(string baseUrl, string texto)
        {
            try
            {
                var client = new WebClient();
                var url = baseUrl.Replace("#Texto#", texto);
                return client.DownloadString(url);
            }
            catch (System.Exception)
            {
                throw new BSErrorConexionException();
            }
        }
    }
}
