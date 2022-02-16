using PokeBL;

namespace PokeUI
{
    public class BattleMenu : IMenu
    {
        private static Pokemon _opponentPoke;
        private static Pokemon _selectedPoke;
        private static List<Pokemon> _currentTeam;
        private readonly IPokemonBL _pokeBL;
        private readonly IPlayerBL _playerBL;

        public BattleMenu(IPokemonBL p_pokeBL, IPlayerBL p_playerBL)
        {
            _pokeBL = p_pokeBL;
            _playerBL = p_playerBL;
        }

        public void Display()
        {
            if (_opponentPoke == null)
            {
                _opponentPoke = _pokeBL.GetRandomPokemon();
                _opponentPoke.Abilities = new List<Ability>(){_pokeBL.GetRandomAbility(_opponentPoke)};
                Console.WriteLine($"You are fighting {_opponentPoke.Name} Lv. {_opponentPoke.Level}!");
                List<Pokemon> yourPoke = _playerBL.GetYourPokemon(MainMenu._player);
                _selectedPoke = PickPokemon();
            }
            else
            {
            Console.WriteLine($"{_opponentPoke.Name} Lv. {_opponentPoke.Level}");
            Console.WriteLine($"Current HP: {_opponentPoke.Health}");
            Console.WriteLine($"{_selectedPoke.Name} Lv. {_selectedPoke.Level}");
            Console.WriteLine($"Current HP: {_selectedPoke.Health}");
            Console.WriteLine(
                @"
What do you want to do?
[3] Fight
[2] Swap Pokemon
[1] Flee
                ");
            }

        }

        private Pokemon PickPokemon()
        {
            Console.WriteLine("Choose your pokemon!");
            
            foreach (var item in _currentTeam)
            {
                Console.WriteLine(item);
            }

            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    Console.WriteLine("Enter Team Id of poke");
                    int teamId = Convert.ToInt32(Console.ReadLine());
                    tryAgain = false;
                    return _currentTeam.Find(poke => poke.TeamId == teamId);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                }
            }

            return null;
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