using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.Interface;

namespace WebAPINubimetrics.BusinessLogic
{
    public class BSBusquedaService:IBSBusqueda
    {

        public ProductoDTO ObtenerProducto(string baseUrl, string producto)
        {
            try
            {
                //conexion con API
                var client = new WebClient();
                var url = baseUrl.Replace("#Texto#", producto);
                var response = client.DownloadString(url);

                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response))
                {
                    var dataObj = JObject.Parse(response);

                    //JToken outer = JToken.Parse(response.Content);

                    //desde aqui obtenemos los datos necesarios 
                    JObject campos = dataObj["fields"].Value<JObject>();

                    ProductoDTO prod = new ProductoDTO();

                    prod.Id = campos.Properties().Where(p => p.Name == "project").Children().Values("key").FirstOrDefault().ToString() ?? "";
                    prod.Title = campos.Properties().Where(p => p.Name == "project").Children().Values("name").FirstOrDefault().ToString() ?? "";
                    //prod.Resumen = campos.Properties().Where(p => p.Name == "summary").Values().FirstOrDefault().ToString() ?? "";
                    //prod.Descripcion = campos.Properties().Where(p => p.Name == "description").Values().FirstOrDefault().ToString() ?? "";
                    //prod.Estado = campos.Properties().Where(p => p.Name == "status").Children().Values("name").FirstOrDefault().ToString() ?? "";
                    //prod.Responsable = campos.Properties().Where(p => p.Name == "assignee").Children().Values("displayName").FirstOrDefault().ToString() ?? "";
                    //prod.HorasIncurridas = campos.Properties().Where(p => p.Name == "timespent").Values().FirstOrDefault().ToString() ?? "";

                    //if ((campos["customfield_10500"]).HasValues)
                    //    prod.CodCliente = campos.Properties().Where(p => p.Name == "customfield_10500").Children().Values("value").FirstOrDefault().ToString() ?? "";
                    //else
                    //    prod.CodCliente = "";

                    //prod.CodProyecto = campos.Properties().Where(p => p.Name == "customfield_10501").Values().FirstOrDefault().ToString() ?? "";
                    //prod.IdModulo = campos.Properties().Where(p => p.Name == "customfield_10502").Values().FirstOrDefault().ToString() ?? "";


                    return prod;//JsonConvert.SerializeObject(prod);

                    //return prod.ToObject<ProductoDTO>();
                }
                else
                    throw new BSErrorBusquedaException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
