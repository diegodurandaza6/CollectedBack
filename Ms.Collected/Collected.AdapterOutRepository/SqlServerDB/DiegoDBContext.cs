
using Microsoft.EntityFrameworkCore;

namespace Collected.AdapterOutRepository.SqlServerDB
{
    public class DiegoDBContext : DbContext
    {
        public DiegoDBContext(DbContextOptions<DiegoDBContext> options) : base(options) { }

        public virtual DbSet<Entities.Recaudos> Recaudos { get; set; }
        public virtual DbSet<Entities.ControlDate> ControlDate { get; set; }
        public virtual DbSet<Entities.JwtAuth> JwtAuth { get; set; }

    }
}
