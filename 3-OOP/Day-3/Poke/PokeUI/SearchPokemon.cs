using PokeBL;

namespace PokeUI
{
    public class SearchPokemon : IMenu  
    {
        private List<Pokemon> _foundPokemons = new List<Pokemon>();
        private string _nameFilter;
        private IPokemonBL _pokeBL;
        public SearchPokemon(IPokemonBL p_pokeBL)
        {
            _pokeBL = p_pokeBL;
        }
        public void Display()
        {
            Console.WriteLine("Select filter option to choose");
            Console.WriteLine("[1] By name");
            Console.WriteLine("[0] Go back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    //Grabs name from user
                    Console.WriteLine("Please enter a name");
                    _nameFilter = Console.ReadLine();

                    //Uses BL searchPokemon method to find any pokemon
                    _foundPokemons = _pokeBL.SearchPokemon(_nameFilter);

                    //Displays what it found or not found
                    if (_foundPokemons.Count != 0)
                    {
                        Log.Information($"Founded {_foundPokemons.Count} Pokemon(s)");
                        Console.WriteLine($"{_foundPokemons.Count} Pokemon(s) was found!");
                        foreach (var item in _foundPokemons)
                        {
                            Console.WriteLine(item);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Unable to find any pokemons!");
                    }

                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    
                    return MenuType.SearchPokemon;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddPokemon;
            }
        }
    }
}