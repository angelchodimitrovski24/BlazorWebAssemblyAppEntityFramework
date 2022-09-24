using Microsoft.EntityFrameworkCore;

namespace WebStore.Server
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Shared.Models.Client> Clients { get; set; } = null!;
    }
}
