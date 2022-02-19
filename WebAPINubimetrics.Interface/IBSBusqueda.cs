using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.Interface
{
    public interface IBSBusqueda
    {
        BusquedaDTO ObtenerProducto(string response);
    }
}
