using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Monsterpedia.Models
{
    public static class FakeData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Monsters.Any())
                {
                    return;   // DB has been seeded
                }

                context.Monsters.AddRange(
                     new Monster
                     {
                         Name = "Red Khezu",
                         Description = "The Red Khezu behaves much like an ordinary Khezu; however, it is capable of unique neck-thrusting attack.",
                         Type = "Thunder",
                         DateAdded = DateTime.Parse("1989-1-12")
                     },

                     new Monster
                     {
                         Name = "Royal Ludroth",
                         Description = "Using its large, absorbent mane, Royal Ludroth can take on gallons of water for use in its many water-based defences. It can produce mucus-based globules that can be spewed at foes, and can force water out of the mane at high speeds, blasting back nearby enemies.",
                         Type = "Water",
                         DateAdded = DateTime.Parse("1989-1-13")
                     },

                     new Monster
                     {
                         Name = "Pink Rathian",
                         Description = "Her attacks are generally stronger than those of normal Rathian, they are also much faster than its green relative, but that aside the two are identical in many ways.",
                         Type = "Fire",
                         DateAdded = DateTime.Parse("1989-1-14")
                     },

                     new Monster
                     {
                         Name = "Agnator",
                         Description = "Agnaktor are quite aggressive, challenging all others that encroach on its habitat, due to the fact that it has no natural predators at an adult age. The only threat that it encounters is if a monster challenges it for territory or food.",
                         Type = "Fire",
                         DateAdded = DateTime.Parse("1989-1-15")
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
