using System;
using RRBL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRModels;
using System.Threading;

namespace RRUI
{
    class ShowRestaurantMenu : IMenu
    {
        private IRestaurantBL _restBL;

        public ShowRestaurantMenu(IRestaurantBL p_rest)
        {
            _restBL = p_rest;
        }
        public void Menu()
        {
            Console.WriteLine("List of Restaurant");
            List<Restaurant> restaurants = _restBL.GetAllRestaurant();
            foreach (Restaurant item in restaurants)
            {
                Console.WriteLine("=============================");
                Console.WriteLine(item);
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
                    Console.WriteLine("Please input a valid response");
                    Thread.Sleep(1000);
                    return MenuType.ShowRestaurant;
            };
        }
    }
}
