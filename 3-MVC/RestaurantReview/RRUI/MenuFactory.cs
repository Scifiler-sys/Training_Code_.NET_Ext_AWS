using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RRBL;
using RRDL;

namespace RRUI
{
    public class MenuFactory : IFactory
    {
        public IMenu getMenu(MenuType p_menu)
        {
            //Get the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) //Set our path to the current directory
                .AddJsonFile("appsetting.json") //Gets the JSON file
                .Build();

            string connectionString = configuration.GetConnectionString("Reference2DB");

            //We are using DbContext to create the DbContextOptions to be passed on our SPDBContext
            DbContextOptions<RRDBContext> options = new DbContextOptionsBuilder<RRDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            //Passing the options we just build 
            var context = new RRDBContext(options);

            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.RestaurantMenu:
                    return new RestaurantMenu();
                case MenuType.ShowRestaurantMenu:
                    return new ShowRestaurantMenu(new RestaurantBL(new Repository(context)));
                case MenuType.AddRestaurantMenu:
                    return new AddRestaurantMenu(new RestaurantBL(new Repository(context)));
                default:
                    return null;
            }
        }
    }
}