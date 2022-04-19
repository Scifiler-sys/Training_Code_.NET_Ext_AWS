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
            Console.WriteLine($"Opponent: {_opponentPoke.Name} Lv. {_opponentPoke.Level} HP: {_opponentPoke.Health}");
            Console.WriteLine($"You: {_selectedPoke.Name} Lv. {_selectedPoke.Level} HP: {_selectedPoke.Health}");
            Console.WriteLine(
                @"
What do you want to do?
[3] Fight
[2] Swap Pokemon
[1] Flee
                ");

        }

        private Pokemon PickPokemon()
        {
            _currentTeam = _playerBL.GetYourPokemon(MainMenu._player);
            
            foreach (var item in _currentTeam)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Choose your pokemon!");

            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    Console.WriteLine("Enter Team Id of poke");
                    int teamId = Convert.ToInt32(Console.ReadLine());
                    tryAgain = false;

                    Pokemon found = _currentTeam.Find(poke => poke.TeamId == teamId);
                    found.Abilities = _pokeBL.GetAbilityFromPokemon(found);
                    return found;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                }
                catch (System.Exception exc)
                {
                    Console.WriteLine(exc.Message);
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
                    return MenuType.MainMenu;
                case "2":
                    return MenuType.BattleMenu;
                case "3":
                    return Battle();;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }

        //Displays battle screen
        private MenuType Battle()
        {
            Ability selectedAb = new Ability();
            foreach (var item in _selectedPoke.Abilities)
            {
                Console.WriteLine(item);
            }
            try
            {
                Console.WriteLine("Select an ability Id!");
                int abId = Convert.ToInt32(Console.ReadLine());
                selectedAb = _selectedPoke.Abilities.Find(ab => ab.Id == abId);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Battle();
            }

            Random rand = new Random();
            //Damage based on attack and selected ability
            //Actually got the equation from a website
            int damagePoke1 = (int)Math.Round(((((2.0*_selectedPoke.Level)/5.0)+2.0)*selectedAb.Power*(_selectedPoke.Attack/_opponentPoke.Defense))/50.0+2.0*(rand.Next(217,255)/255.0)*1.5*8);
            Ability opponentAb = _opponentPoke.Abilities[rand.Next(0,_opponentPoke.Abilities.Count)];
            int damagePoke2 = (int)Math.Round(((((2.0*_opponentPoke.Level)/5.0)+2.0)*opponentAb.Power*(_opponentPoke.Attack/_selectedPoke.Defense))/50.0+2.0*(rand.Next(217,255)/255.0)*1.5*8);

            if (_selectedPoke.Speed > _opponentPoke.Speed)
            {
                _opponentPoke.Health -= damagePoke1;
                Console.WriteLine($"{_selectedPoke.Name} Lv. {_selectedPoke.Level} attacked with {damagePoke1}!!");
                Thread.Sleep(2000);
                if (_opponentPoke.Health < 0)
                {
                    _opponentPoke = null;
                    Console.WriteLine("You win!");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
                }
                _selectedPoke.Health -= damagePoke2;
                Console.WriteLine($"{_opponentPoke.Name} Lv. {_opponentPoke.Level} attacked with {damagePoke2}!!");
                Thread.Sleep(2000);
                if (_selectedPoke.Health < 0)
                {
                    _opponentPoke = null;
                    Console.WriteLine("You Lose!");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
                }

                return MenuType.BattleMenu;
            }
            else
            {
                _selectedPoke.Health -= damagePoke2;
                Console.WriteLine($"{_opponentPoke.Name} Lv. {_opponentPoke.Level} attacked with {damagePoke2}!!");
                Thread.Sleep(2000);
                if (_selectedPoke.Health < 0)
                {
                    _opponentPoke = null;
                    Console.WriteLine("You Lose!");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
                }
                _opponentPoke.Health -= damagePoke1;
                Console.WriteLine($"{_selectedPoke.Name} Lv. {_selectedPoke.Level} attacked with {damagePoke1}!!");
                Thread.Sleep(2000);
                if (_opponentPoke.Health < 0)
                {
                    _opponentPoke = null;
                    Console.WriteLine("You win!");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
                }

                return MenuType.BattleMenu;
            }
        }
    }
}