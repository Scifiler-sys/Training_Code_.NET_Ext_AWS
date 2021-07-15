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
            //We used our BLs to get information for our UI
            //Our UI should NEVER interact with our DL
            //Since BL might have futher data clean up and we want that rather than the raw data from DL
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
                    return MenuType.ShowRestaurantMenu;
            };
        }
    }
}
