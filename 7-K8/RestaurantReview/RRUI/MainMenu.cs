using System;

namespace RRUI
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Go to Restaurant Menu");
            Console.WriteLine("[0] Exit");
        }

        public MenuType YourChoice()
        {
            //Console.ReadLine() method will record what you type in the terminal
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.RestaurantMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}