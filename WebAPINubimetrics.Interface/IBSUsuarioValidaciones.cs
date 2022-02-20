using System.Collections.Generic;
using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.Interface
{
    public interface IBSUsuarioValidaciones
    {
        bool UsuarioExiste(List<UsuarioDTO> usuario, int id);
        bool UsuarioNulo(UsuarioDTO usuario);
        bool UsuarioValoresCorrectos(UsuarioDTO usuario);
    }
}
