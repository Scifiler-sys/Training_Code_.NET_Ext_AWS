namespace PokeUI
{
    /*
        Interfaces are one of the best way to implement abstraction
        Every method is implicitly abstract meaning you do not have to write any implementation details for it
        Every method is also public
    */
    public interface IMenu
    {
        /// <summary>
        /// Will display the menu and the user choices of a class
        /// </summary>
        void Display();

        /// <summary>
        /// Will record the user's choice and change/route your menu based on the choice
        /// </summary>
        /// <returns>Returns the menu that will be changed into</returns>
        string UserChoice();
    }
}