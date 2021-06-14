using System;
using System.Threading;

namespace RRUI
{
    public class RestaurantMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Restaurant Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Give list of Restaurant");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.ShowRestaurant;
                default:
                    Console.WriteLine("Please input a valid response");
                    Thread.Sleep(1000);
                    return MenuType.RestaurantMenu;
            };
        }
    }
}