using System;
using RRBL;
using RRDL;

namespace RRUI
{
    public class MenuFactory : IFactory
    {
        public IMenu getMenu(MenuType p_menu)
        {
            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.RestaurantMenu:
                    return new RestaurantMenu();
                case MenuType.ShowRestaurantMenu:
                    return new ShowRestaurantMenu(new RestaurantBL(new Repository()));
                default:
                    return null;
            }
        }
    }
}