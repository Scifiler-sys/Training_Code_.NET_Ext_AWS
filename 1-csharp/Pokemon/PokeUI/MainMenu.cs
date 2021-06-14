using System;
using System.Threading;

namespace PokeUI
{
    public class MainMenu : IMenu
    {
        //This method will start our UI
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] Add Pokemon"); //Just an example, might add implementation depending on time
            Console.WriteLine("[1] Go to Battle Menu");
            Console.WriteLine("[0] Exit");
        }
        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.BattleMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Thread.Sleep(1000);
                    return MenuType.MainMenu;
            };
        }
    }
}