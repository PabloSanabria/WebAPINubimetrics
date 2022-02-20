using System.Collections.Generic;
using WebAPINubimetrics.Entity.DTO;

namespace WebAPINubimetrics.TEST
{
    public static class DataUsuarioTest
    {
        /// <summary>
        /// Obtiene un objeto del tipo usuario
        /// </summary>
        /// <returns></returns>
        public static UsuarioDTO GetUsuario()
        {
            return new UsuarioDTO()
            { 
                Id = 1, Nombre = "Pablo", Apellido = "Sanabria", Email = "pablosanabria_1986@hotmail.com", Password="123456"
            };
        }

        /// <summary>
        /// Obtiene un objeto del tipo usuario con datos incorrectos
        /// </summary>
        /// <returns></returns>
        public static UsuarioDTO GetUsuarioIncorrecto()
        {
            return new UsuarioDTO()
            {
                Id = -1,
                Nombre = "Pablo",
                Apellido = "Sanabria",
                Email = "pablosanabria_1986@hotmail.com",
                Password = "123456"
            };
        }

        /// <summary>
        /// Obtiene un bojeto del tipo usuario null
        /// </summary>
        /// <returns></returns>
        public static UsuarioDTO GetUsuarioNulo()
        {
            UsuarioDTO usr = null;
            return usr;
        }            
            
        /// <summary>
        /// Obtiene on bojeto del tipo lista de usuarios
        /// </summary>
        /// <returns></returns>
        public static List<UsuarioDTO> GetUsuarios()
        {
            return new List<UsuarioDTO>
            {
               new UsuarioDTO(){ Id = 1, Nombre = "Pablo", Apellido = "Sanabria", Email = "pablosanabria@hotmail.com", Password="123456" },
               new UsuarioDTO(){ Id = 2, Nombre = "Leonardo", Apellido = "Perez", Email = "loePerez@hotmail.com", Password="123456" },
               new UsuarioDTO(){ Id = 3, Nombre = "Daniela", Apellido = "Lopez", Email = "danlopez@hotmail.com", Password="123456" }
            };
        }
    }

}
