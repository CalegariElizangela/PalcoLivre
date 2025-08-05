using Microsoft.EntityFrameworkCore;

namespace PalcoLivre.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cantor> Cantores { get; set; }
    }
}