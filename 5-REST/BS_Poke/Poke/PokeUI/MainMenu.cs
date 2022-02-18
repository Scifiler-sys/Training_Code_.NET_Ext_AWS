namespace PokeUI
{
     /*
        - Since MainMenu inherits IMenu, anything IMenu has, MainMenu will have
        - However, since it is an interface, MainMenu must implement some code for those methods

        - This gives us the capability to force MainMenu to have two methods 
        and force it to also give those two methods some implementation
        but why?
    */
    public class MainMenu : IMenu
    {
        internal static Player _player = new Player();
        public void Display()
        {
            Console.WriteLine("Welcome to the world of Pokemon!");
            Console.WriteLine("What would you like to do?");
            if (_player.Name == null)
            {
                Console.WriteLine
(
@"
[3] Login
[2] Register
[1] Exit
"
);
            }
            else
            {
                Console.WriteLine($"Trainer info - Name: {_player.Name}");
                Console.WriteLine
                (
@"
[6] Capture a pokemon!
[5] Check your team
[4] Battle
[1] Exit
"
                );
            }
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            //Switch is just a more optimized version of if and elseifs and else
            switch (userInput)
            {
                //Cases are the same as else ifs
                case "1":
                    return MenuType.Exit;
                case "2":
                    return MenuType.RegisterMenu;
                case "3":
                    return MenuType.LoginMenu;
                case "4":
                    return MenuType.BattleMenu;
                case "5":
                    return MenuType.YourPokemonMenu;
                //Default is the same as an else
                case "6":
                    return MenuType.CapturePokemonMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}