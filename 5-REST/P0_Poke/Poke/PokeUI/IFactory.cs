namespace PokeUI
{
    public interface IFactory
    {
        /// <summary>
        /// Creates the menu, if menu doesn't exist return Main Menu
        /// </summary>
        /// <param name="p_menu">What menu to create</param>
        /// <returns>Menu Object</returns>
        IMenu CreateMenu(MenuType p_menu);
    }
}