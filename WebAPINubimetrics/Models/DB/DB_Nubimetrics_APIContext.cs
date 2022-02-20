using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPINubimetrics.Models.DB
{
    public partial class DB_Nubimetrics_APIContext : DbContext
    {
        public DB_Nubimetrics_APIContext()
        {
        }

        public DB_Nubimetrics_APIContext(DbContextOptions<DB_Nubimetrics_APIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPINubimetrics.Entity.DTO.UsuarioDTO> User { get; set; }
    }
}
