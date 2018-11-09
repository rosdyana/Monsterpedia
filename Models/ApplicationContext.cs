using Microsoft.EntityFrameworkCore;

namespace Monsterpedia.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
        public DbSet<Monster> Monsters { get; set; }
    }
}