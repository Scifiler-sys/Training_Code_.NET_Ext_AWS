using System;
using System.Threading;

namespace RRUI
{
    public class MainMenu : IMenu
    {
        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.RestaurantMenu;
                case "1":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("Please input a valid response");
                    Thread.Sleep(1000);
                    return MenuType.MainMenu;
            };
        }

        //This method will start our UI
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] Go to Restaurant Menu");
            Console.WriteLine("[1] Exit");
        }
    }
}