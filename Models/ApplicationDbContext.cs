using Microsoft.EntityFrameworkCore;

namespace Monsterpedia.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Monster> Monsters { get; set; }
    }
}