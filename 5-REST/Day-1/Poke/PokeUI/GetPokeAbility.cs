using PokeBL;

namespace PokeUI
{
    public class GetPokeAbility : IMenu
    {
        IPokemonBL _pokeBL;
        List<Pokemon> _listOfPoke;
        public GetPokeAbility(IPokemonBL p_pokeBL)
        {
            _pokeBL = p_pokeBL;
            _listOfPoke = _pokeBL.GetAllPokemon();
        }

        public void Display()
        {
            Console.WriteLine("====Current Team====");
            foreach (var item in _listOfPoke)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("[1] Select Pokemon by Id");
            Console.WriteLine("[0] Go back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            //Switch is just a more optimized version of if and elseifs and else

            switch (userInput)
            {
                //Cases are the same as else ifs
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    Console.WriteLine("Enter PokeId: ");
                    try
                    {
                        int pokeId = Convert.ToInt32(Console.ReadLine());
                        List<Ability> listOfAbility = _pokeBL.GetAbilityByPokeId(pokeId);
                        foreach (var item in listOfAbility)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return MenuType.GetPokeAbility;
                    }
                    
                    return MenuType.MainMenu;
                //Default is the same as an else
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}