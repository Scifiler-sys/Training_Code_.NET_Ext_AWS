using PokeBL;

namespace PokeUI
{
    public class YourPokemonMenu : IMenu
    {
        private readonly IPlayerBL _playerBL;

        public YourPokemonMenu(IPlayerBL p_playerBL)
        {
            _playerBL = p_playerBL;
        }

        public void Display()
        {
            List<Pokemon> listOfPoke = _playerBL.GetYourPokemon(MainMenu._player);

            foreach (Pokemon pokemon in listOfPoke)
            {
                Console.WriteLine(pokemon);
            }
            Console.WriteLine(@"
Learn an Ability!
Go Back
            ");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            //Switch is just a more optimized version of if and elseifs and else
            switch (userInput)
            {
                //Cases are the same as else ifs
                case "1":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.YourPokemonMenu;
            }
        }
    }
}