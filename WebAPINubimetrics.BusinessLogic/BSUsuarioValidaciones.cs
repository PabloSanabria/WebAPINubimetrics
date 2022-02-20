using System.Collections.Generic;
using System.Linq;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.Interface;

namespace WebAPINubimetrics.BusinessLogic
{
    public class BSUsuarioValidaciones: IBSUsuarioValidaciones
    {
        /// <summary>
        /// Valida que exista al menos un usuario en una lista de usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UsuarioExiste(List<UsuarioDTO> usuario, int id) {
        
            return usuario.Any(e => e.Id == id); ;
        }

        /// <summary>
        /// Valida que un objeto de tipo usuario no sea nulo
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool UsuarioNulo(UsuarioDTO usuario)
        {
            return (usuario == null);
        }

        /// <summary>
        /// Valida que los datos ingresados para guardar un usuario sean correctos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool UsuarioValoresCorrectos(UsuarioDTO usuario)
        {
            if (usuario.Id <= 0 || string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Apellido)
                || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.Password))
                return false;

            return true;
        }
    }
}
