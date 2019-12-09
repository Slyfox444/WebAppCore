using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAppCore.Data;
using WebAppCore.Models;

namespace DummyData
{
    class Dummydata
    {
        public static void Initialize(IApplicationBuilder app)

        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())

            {

                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //context.Database.Migrate();



                // Look for any teams.

                if (context.Teams.Any())

                {

                    return;   // DB has already been seeded

                }



                var teams = DummyData.GetTeams().ToArray();

                context.Teams.AddRange(teams);

                context.SaveChanges();



                var players = DummyData.GetPlayers(context).ToArray();

                context.Players.AddRange(players);

                context.SaveChanges();

            }

        }



        public static List<Team> GetTeams()

        {

            List<Team> teams = new List<Team>() {

            new Team() {

                TeamName="Barcelona",

                City="Madrid",

                Country="Spain",

            },

       

            new Team() {

                TeamName="Levsi",

                City="Sofia",

                Country="Bulgaria",

            },
          
 
            new Team() {

                TeamName="Liverpool",

                City="Merseyside",

                Country="England",

            },

        };



            return teams;

        }



        public static List<Player> GetPlayers(ApplicationDbContext context)

        {

            List<Player> players = new List<Player>() {

           
            new Player {

                FirstName = "Ivan",

                LastName = "Rakitić",

                TeamName = context.Teams.Find("Barcelona").TeamName,

                Position = "Midfielder"

            },

            new Player {

                FirstName = "Ivan",

                LastName = "Goranov",

                TeamName = context.Teams.Find("Levski").TeamName,

                Position = "Right Wing"

            },

            new Player {

                FirstName = "Joël",

                LastName = "Matip",

                TeamName = context.Teams.Find("Liverpool").TeamName,

                Position = "Defense"

            },

        };



            return players;

        }

    }

}

