using System;

namespace PokeUI
{
    //enum to make our switch cases make more sense
    public enum MenuType
    {
        MainMenu,
        BattleMenu,
        FightMenu,
        Exit
    }
    //The purpose of the interface is to ensure every menu that we create will have a start method
    public interface IMenu
    { 
        //as an interface, it will automatically fill in public (access-modifier) and abstract (non-access modifier)
        /// <summary>
        /// Will display the overall menu of the project and the choices you can make
        /// </summary>
        void Menu();

        /// <summary>
        /// This method will record the user's choice and change your menu based on the end-user's choice
        /// </summary>
        /// <returns> Returns a MenuType that the user picked</returns>
        MenuType YourChoice();
    }
}
