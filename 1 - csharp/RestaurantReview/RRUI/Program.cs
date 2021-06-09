using System;
using RRModels;

namespace RRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // //We can set our property values this way (kinda makes constructor overloading not needed)
            // Restaurant rest = new Restaurant()
            // {
            //     City = "Houston",
            //     State = "Texas"
            // };
            // Console.WriteLine(rest.City);

            RestaurantMenu restMenu = new RestaurantMenu();

            restMenu.Start();
            
        }
    }
}
