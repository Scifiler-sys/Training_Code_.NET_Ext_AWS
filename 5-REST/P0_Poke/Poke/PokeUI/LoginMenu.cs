using PokeBL;

namespace PokeUI
{
    public class LoginMenu : IMenu
    {
        private readonly IPlayerBL _playerBL;
        public LoginMenu(IPlayerBL p_playerBL)
        {
            _playerBL = p_playerBL;
        }
        public void Display()
        {
            Console.WriteLine($"[3] Name - {MainMenu._player.Name}\n[2] Login\n[1] Go Back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            //Switch is just a more optimized version of if and elseifs and else
            switch (userInput)
            {
                //Cases are the same as else ifs
                case "1":
                    MainMenu._player.Name = null;
                    MainMenu._player.Gender = false;
                    return MenuType.MainMenu;
                case "2":
                    try
                    {
                        MainMenu._player = _playerBL.Login(MainMenu._player);
                    }
                    catch (System.Exception exc)
                    {
                        MainMenu._player.Name = null;
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return MenuType.MainMenu;
                case "3":
                    Console.WriteLine("Please enter a name");
                    MainMenu._player.Name = Console.ReadLine();
                    return MenuType.LoginMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.LoginMenu;
            }
        }
    }
}