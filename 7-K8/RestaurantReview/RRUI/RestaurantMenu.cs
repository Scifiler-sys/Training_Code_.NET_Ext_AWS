using System;
using System.Threading;

namespace RRUI
{
    public class RestaurantMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Restaurant Menu!");
            Console.WriteLine("What would you like to do");
            Console.WriteLine("[2] Add a Restaurant");
            Console.WriteLine("[1] Give list of restaurants");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.ShowRestaurantMenu;
                case "2":
                    return MenuType.AddRestaurantMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.RestaurantMenu;
            }
        }
    }
}