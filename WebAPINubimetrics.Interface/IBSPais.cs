using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.Interface
{
    public interface IBSPais
    {
        public PaisDTO ObtenerPais(string baseUrl, string idPais);

    }
}
