namespace RRUI
{
    public enum MenuType
    {
        MainMenu,
        RestaurantMenu,
        ShowRestaurantMenu,
        AddRestaurantMenu,
        Exit
    }
    public interface IMenu
    {
        /// <summary>
        /// Will display the overall menu of the class and the choices you can make in that menu class
        /// </summary>
        void Menu();

        /// <summary>
        /// This methog will record the user's choice and change your meny based on their input
        /// </summary>
        /// <returns>Returns a value that will dictate what menu to change to</returns>
        MenuType YourChoice();
    }
}