using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.Interface
{
    public interface IBSBusqueda
    {
        ProductoDTO ObtenerProducto(string baseUrl, string producto);
    }
}
