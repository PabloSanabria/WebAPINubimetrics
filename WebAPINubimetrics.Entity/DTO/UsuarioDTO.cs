using System.ComponentModel.DataAnnotations;

namespace WebAPINubimetrics.Entity.DTO
{
    public class UsuarioDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
