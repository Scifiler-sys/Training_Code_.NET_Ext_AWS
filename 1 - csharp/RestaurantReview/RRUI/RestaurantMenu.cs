using System;
using System.Threading;

namespace RRUI
{
    public class RestaurantMenu
    {

        //This method will start our UI
        public void Start()
        {
            bool repeat = true;

            //Will keep repeating until we choose to exit out of it
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Welcome to my Restaurant!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid response");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}