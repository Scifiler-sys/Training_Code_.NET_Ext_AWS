using System;
using static RRUI.Program;

namespace RRUI
{
    public enum MenuType
    {
        MainMenu,
        RestaurantMenu,
        Exit
    }
    //The purpose of the interface is to ensure every menu that we create will have a start method
    public interface IMenu
    { 
        //as an interface, it will automatically fill in public (access-modifier) and abstract (non-access modifier)
        void Menu();

        MenuType YourChoice();
    }
}
