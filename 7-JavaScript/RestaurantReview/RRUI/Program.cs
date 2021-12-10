using System;
using RRBL;
using RRDL;
using RRModel;

namespace RRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu restMenu = new MainMenu();
            bool repeat = true;
            MenuType currentMenu = MenuType.MainMenu;
            IFactory menuFactory = new MenuFactory();

            
            while (repeat)
            {
                Console.Clear();
                restMenu.Menu();
                currentMenu = restMenu.YourChoice();

                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        restMenu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.RestaurantMenu:
                        restMenu = menuFactory.GetMenu(MenuType.RestaurantMenu);
                        break;
                    case MenuType.ShowRestaurantMenu:
                        restMenu = menuFactory.GetMenu(MenuType.ShowRestaurantMenu);
                        break;
                    case MenuType.AddRestaurantMenu:
                        restMenu = menuFactory.GetMenu(MenuType.AddRestaurantMenu);
                        break;
                    case MenuType.Exit:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Cannot process what you want please try again");
                        break;
                }
            }
        }
    }
}
