using System;

namespace PokeUI
{
    class Program
    {
        static void Main(string[] args)
        {
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
