using System;
using System.Threading;
using RRBL;
using RRModels;

namespace RRUI
{
    public class AddRestaurantMenu : IMenu
    {
        private static Restaurant _newRest = new Restaurant();
        private IRestaurantBL _restBL;

        public AddRestaurantMenu(IRestaurantBL p_rest)
        {
            _restBL = p_rest;
        }
        public void Menu()
        {
            Console.WriteLine("[4]Name - " + _newRest.Name);
            Console.WriteLine("[3]City - " + _newRest.City);
            Console.WriteLine("[2]State - " + _newRest.State);
            Console.WriteLine("[1]Finish");
            Console.WriteLine("[0]Go Back");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.RestaurantMenu;
                case "1":
                    //Checks if there are values in the properties
                    if (_newRest.Name == null || _newRest.City == null || _newRest.State == null)
                    {
                        Console.WriteLine("Please fill all of the fields listed above");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        _restBL.AddRestaurant(_newRest);

                        Console.WriteLine("Finished adding restaurant!");
                        Thread.Sleep(1000);
                        //Removing our past values
                        _newRest = new Restaurant();

                        return MenuType.RestaurantMenu;
                    }

                    return MenuType.AddRestaurantMenu;
                case "2":
                    Console.WriteLine("Please enter the State of your Restaurant:");
                    _newRest.State = Console.ReadLine();
                    return MenuType.AddRestaurantMenu;
                case "3":
                    Console.WriteLine("Please enter the City of your Restaurant:");

                    //Will try to change the city properties
                    try
                    {
                        _newRest.City = Console.ReadLine();
                    }
                    catch (System.Exception e) //Catches the exception that our BL class throws
                    {
                        Console.WriteLine(e.Message);
                        Thread.Sleep(1000);
                    }
                    return MenuType.AddRestaurantMenu;
                case "4":
                    Console.WriteLine("Please enter the Name of your Restaurant:");
                    _newRest.Name = Console.ReadLine();
                    return MenuType.AddRestaurantMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Thread.Sleep(1000);
                    return MenuType.RestaurantMenu;
            };
        }
    }
}