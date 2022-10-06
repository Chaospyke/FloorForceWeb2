using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// using FloorForce2.Data;
using System;
using System.Linq;

namespace FloorForce2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcFloorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcFloorContext>>()))
            {
                // Look for any movies.
                if (context.Floor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Floor.AddRange(
                    new Floor
                    {
                        Name = "Mahogany",
                        Desc = "Lorem ipsum",
                        Price = 19.99M
                    },
                    new Floor
                    {
                        Name = "Cherry Wood",
                        Desc = "Lorem ipsum",
                        Price = 21.99M
                    },
                    new Floor
                    {
                        Name = "Mapel",
                        Desc = "Lorem ipsum",
                        Price = 17.99M
                    },
                    new Floor
                    {
                        Name = "White Oak",
                        Desc = "Lorem ipsum",
                        Price = 18.99M
                    },
                    new Floor
                    {
                        Name = "Red Wood",
                        Desc = "Lorem ipsum",
                        Price = 25.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}