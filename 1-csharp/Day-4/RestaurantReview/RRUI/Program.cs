using System;
using System.Threading;
using RRBL;
using RRDL;
using RRModels;

namespace RRUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMenu restMenu = new MainMenu();
            MenuType currentMenu = MenuType.MainMenu;
            bool repeat = true;

            //Will keep repeating until we choose to exit out of it
            while (repeat)
            {
                //Can use this method for any menu classes if they inherit the inteface since it is gaurantee that
                //they will have these methods and will not break my program class in anyway
                Console.Clear();
                restMenu.Menu();
                currentMenu = restMenu.YourChoice();

                //switch is like a series of ifs statement
                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        restMenu = new MainMenu();
                        break;
                    case MenuType.RestaurantMenu:
                        restMenu = new RestaurantMenu();
                        break;
                    case MenuType.Exit:
                        Console.WriteLine("Good bye!");
                        Thread.Sleep(1000); //Thread class has a static method to "stop" the program for x amount of milliseconds
                        repeat = false; //We switch repeat to false to stop the while loop
                        break;
                    default:
                        Console.WriteLine("Please put a valid response");
                        currentMenu = MenuType.MainMenu;
                        break;
                }
            }
        }
    }
}
