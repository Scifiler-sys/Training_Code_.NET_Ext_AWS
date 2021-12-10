using System;
using System.Collections.Generic;
using RRBL;
using RRModel;

namespace RRUI
{
    public class ShowRestaurantMenu : IMenu
    {
        private IRestaurantBL _restBL;
        public ShowRestaurantMenu(IRestaurantBL p_rest)
        {
            _restBL = p_rest;
        }
        public void Menu()
        {
            Console.WriteLine("List of Restaurants");

            List<Restaurant> restaurants = _restBL.GetAllRestaurant();

            foreach (Restaurant rest in restaurants)
            {
                Console.WriteLine("=============================");
                Console.WriteLine(rest);
                Console.WriteLine("=============================");
            }

            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.RestaurantMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowRestaurantMenu;
            }
        }
    }
}