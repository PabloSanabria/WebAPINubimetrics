using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.Interface
{
    public interface IBSBusqueda
    {
        BusquedaDTO Buscar(string response);
    }
}
