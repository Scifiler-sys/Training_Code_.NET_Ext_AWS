using System;
using System.Threading;
using RRBL;
using RRModel;

namespace RRUI
{
    public class AddRestaurantMenu : IMenu
    {
        private static Restaurant _newRest = new Restaurant();
        private IRestaurantBL _restBL;
        public AddRestaurantMenu(IRestaurantBL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine(@"  /$$$$$$        /$$       /$$");
            Console.WriteLine(@" /$$__  $$      | $$      | $$");
            Console.WriteLine(@"| $$  \ $$  /$$$$$$$  /$$$$$$$");
            Console.WriteLine(@"| $$$$$$$$ /$$__  $$ /$$__  $$");
            Console.WriteLine(@"| $$__  $$| $$  | $$| $$  | $$");
            Console.WriteLine(@"| $$  | $$| $$  | $$| $$  | $$");
            Console.WriteLine(@"| $$  | $$|  $$$$$$$|  $$$$$$$");
            Console.WriteLine(@"|__/  |__/ \_______/ \_______/");
            Console.WriteLine();
            Console.WriteLine("[4] Name - "+_newRest.Name);
            Console.WriteLine("[3] City - "+ _newRest.City);
            Console.WriteLine("[2] State - "+_newRest.State);
            Console.WriteLine("[1] Add Restaurant");
            Console.WriteLine("[0] Go back");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.RestaurantMenu;
                case "1":
                    _restBL.AddRestaurant(_newRest);
                    return MenuType.RestaurantMenu;
                case "2":
                    _newRest.State = Console.ReadLine();
                    return MenuType.AddRestaurantMenu;
                case "3":
                    try
                    {
                        _newRest.City = Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("City cannot hold numbers!");
                        Thread.Sleep(1000);
                    }
                    return MenuType.AddRestaurantMenu;
                case "4":
                    _newRest.Name = Console.ReadLine();
                    return MenuType.AddRestaurantMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddRestaurantMenu;
            }
        }
    }
}