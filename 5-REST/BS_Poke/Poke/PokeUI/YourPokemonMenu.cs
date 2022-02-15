using PokeBL;

namespace PokeUI
{
    public class YourPokemonMenu : IMenu
    {
        private readonly IPlayerBL _playerBL;
        internal static Pokemon _poke;
        private List<Pokemon> _listOfPoke;

        public YourPokemonMenu(IPlayerBL p_playerBL)
        {
            _playerBL = p_playerBL;
            _listOfPoke = _playerBL.GetYourPokemon(MainMenu._player);
        }

        public void Display()
        {
            foreach (Pokemon pokemon in _listOfPoke)
            {
                Console.WriteLine(pokemon);
            }
            Console.WriteLine(@"
[2] Learn an Ability!
[1] Go Back
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
                case "2":
                    Console.WriteLine("Enter Team Id of the pokemon you want to learn an ability");
                    try
                    {
                        int pokeId = Convert.ToInt32(Console.ReadLine());
                        _poke = _listOfPoke.Find(poke => poke.Id == pokeId);
                    }
                    catch (System.FormatException exc)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return MenuType.YourPokemonMenu;
                    }
                    return MenuType.LearnAbilityMenu; 
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.YourPokemonMenu;
            }
        }
    }
}