using PokeBL;

namespace PokeUI
{
     /*
        - Since MainMenu inherits IMenu, anything IMenu has, MainMenu will have
        - However, since it is an interface, MainMenu must implement some code for those methods

        - This gives us the capability to force MainMenu to have two methods 
        and force it to also give those two methods some implementation
        but why?
    */
    public class CapturePokemonMenu : IMenu
    {
        private IPokemonBL _pokeBL;
        private IPlayerBL _playerBL;
        private static Pokemon _randPoke;
        public CapturePokemonMenu(IPokemonBL p_pokeBL, IPlayerBL p_playerBL)
        {
            _pokeBL = p_pokeBL;
            _playerBL = p_playerBL;
        }
        public void Display()
        {
            _randPoke = _pokeBL.GetRandomPokemon();
            Console.WriteLine
            (
            $"You have encountered {_randPoke.Name} Lv.{_randPoke.Level}\n"
            +
@"What would you like to do?
[3] Try to catch
[2] Flee
[1] Go back
            "
            );
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
                    return MenuType.CapturePokemonMenu;
                case "3":
                    if (_playerBL.GetYourPokemon(MainMenu._player).Count < 7 && _playerBL.CaptureAttempt(_randPoke, MainMenu._player))
                    {
                        Console.WriteLine("You successfully capture the pokemon and has been added to your team!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You failed to capture the pokemon");
                        Console.WriteLine("Note - you will always fail capture if you have more than 6 pokemons");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return MenuType.CapturePokemonMenu;
                //Default is the same as an else
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CapturePokemonMenu;
            }
        }
    }
}