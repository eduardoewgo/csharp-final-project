using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class SeedData
    {
        public static void Populate(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if(!context.Clubs.Any())
            {
                context.Clubs.AddRange(
                    new Club() { Name = "Real Madrid", League = "ESP1" },
                    new Club() { Name = "Barcelona", League = "ESP1" },
                    new Club() { Name = "Bayern Munich", League = "GER1" }
                    );
            }
            if (!context.Players.Any())
            {
                context.Players.AddRange(
                    new Player() { Name = "Marcelo", Age = 30, Overall = 88 },
                    new Player() { Name = "Sergio Ramos", Age = 32, Overall = 92 },
                    new Player() { Name = "Karim Benzema", Age = 31, Overall = 85 },
                    new Player() { Name = "Messi", Age = 29, Overall = 89 },
                    new Player() { Name = "Philippe Coutinho", Age = 26, Overall = 88 },
                    new Player() { Name = "Gareth Bale", Age = 29, Overall = 89 },
                    new Player() { Name = "Robert Lewandowski", Age = 30, Overall = 92 },
                    new Player() { Name = "Arjen Robben", Age = 35, Overall = 85 },
                    new Player() { Name = "James Rodriguez", Age = 27, Overall = 88 }
                    );
            }
            
            context.SaveChanges();

            // Wait for clubs to be saved.
            if (!context.Fixtures.Any())
            {
                Club c1 = context.Clubs.FirstOrDefault(c => c.ClubId == 1);
                Club c2 = context.Clubs.FirstOrDefault(c => c.ClubId == 2);

                if (c1 != null && c2 != null)
                {
                    context.Fixtures.AddRange(
                        new Fixture() { Home = c1, Away = c2, MatchTime = DateTime.Now.AddMinutes(2) },
                        new Fixture() { Home = c2, Away = c1, MatchTime = DateTime.Today.AddDays(5) }
                        );
                }                
            }

            context.SaveChanges();
        }
    }
}
