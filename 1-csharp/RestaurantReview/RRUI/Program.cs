using System;
using System.Threading;
using RRBL;
using RRDL;
using RRModels;

namespace RRUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            //We can set our property values this way (kinda makes constructor overloading not needed)
            // Restaurant rest = new Restaurant()
            // {
            //     City = "Houston",
            //     State = "Texas"
            // };
            // Console.WriteLine(rest.City);

            IMenu restMenu = new MainMenu();
            IRestaurantBL restBL = new RestaurantBL(new Repository());
            MenuType currentMenu = MenuType.MainMenu;
            bool repeat = true;

            //Will keep repeating until we choose to exit out of it
            while (repeat)
            {
                Console.Clear();
                restMenu.Menu();
                currentMenu = restMenu.YourChoice();
                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        restMenu = new MainMenu();
                        break;
                    case MenuType.RestaurantMenu:
                        restMenu = new RestaurantMenu();
                        break;
                    case MenuType.ShowRestaurant:
                        restMenu = new ShowRestaurantMenu(restBL);
                        break;
                    case MenuType.Exit:
                        Console.WriteLine("Good bye!");
                        Thread.Sleep(1000);
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please put a valid response");
                        currentMenu = MenuType.MainMenu;
                        break;
                }
            }
        }
    }
}
