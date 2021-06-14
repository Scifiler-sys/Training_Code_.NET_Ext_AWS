using System;
using System.Threading;
using RRModels;

namespace PokeUI
{
    public class BattleMenu : IMenu
    {
        private static Pokemon _poke1;
        private static Pokemon _poke2;
        public void Menu()
        {
            Console.WriteLine("Welcome to the Battle Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[3] Choose Pokemon 1 to battle");
            Console.WriteLine("[2] Choose Pokemon 2 to battle");
            Console.WriteLine("[1] Fight!");
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
                    return MenuType.FightMenu;
                case "2":
                    return MenuType.BattleMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Thread.Sleep(1000);
                    return MenuType.MainMenu;
            };
        }
    }
}