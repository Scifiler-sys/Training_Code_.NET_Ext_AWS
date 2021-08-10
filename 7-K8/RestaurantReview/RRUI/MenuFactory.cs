using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RRBL;
using RRDL;
using RRDL.Entities;

namespace RRUI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {

            //Get the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            //Grabs our connectionString from our appsetting.json
            string connectionString = configuration.GetConnectionString("Reference2DB");

            DbContextOptions<DemoDbContext> options = new DbContextOptionsBuilder<DemoDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.RestaurantMenu:
                    return new RestaurantMenu();
                case MenuType.ShowRestaurantMenu:
                    //ShowRestaurantMenu needs a RestaurantBL object in the parameter because it depends on that object to be able to run its functionality
                    //RestaurantBL needs the Repository object in the parameter because it depends on that object to be able to run
                    //This is call Dependency Injection
                    return new ShowRestaurantMenu(new RestaurantBL(new Repository(new DemoDbContext(options))));
                case MenuType.AddRestaurantMenu:
                    return new AddRestaurantMenu(new RestaurantBL(new Repository(new DemoDbContext(options))));
                default:
                    return null;
            }
        }
    }
}