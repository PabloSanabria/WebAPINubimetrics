using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.Interface
{
    public interface IBSConexionApi
    {
        ExternalServiceDataDTO ObtenerDatosJson(string jsonData, string nombreCon);

        string ConectarApi(string baseUrl, string texto = "");
    }
}
