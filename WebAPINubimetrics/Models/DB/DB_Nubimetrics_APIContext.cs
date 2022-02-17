using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public DbSet<WebAPINubimetrics.Models.DB.Usuario> User { get; set; }
    }
}
