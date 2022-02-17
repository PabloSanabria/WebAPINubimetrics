using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.Interface
{
    public interface IBSConexionApi
    {
        ExternalServiceDataDTO ObtenerDatosJson(string jsonData, string nombreCon);

        string ConectarApi(string baseUrl, string texto);
    }
}
