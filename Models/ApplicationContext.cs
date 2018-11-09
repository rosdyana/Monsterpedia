using Microsoft.EntityFrameworkCore;

namespace Monsterpedia.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
        public DbSet<Monsterpedia.Models.Monster> Monsters { get; set; }
    }
}