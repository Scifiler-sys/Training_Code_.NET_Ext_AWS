using PokeBL;

namespace PokeUI
{
    public class LearnAbilityMenu : IMenu
    {
        private readonly IPokemonBL _pokeBL;

        public LearnAbilityMenu(IPokemonBL p_pokeBL)
        {
            _pokeBL = p_pokeBL;
        }

        public void Display()
        {
            List<Ability> currentAbility = _pokeBL.GetAbilityFromPokemon(YourPokemonMenu._poke);

            Console.WriteLine("===Current Ability of " + YourPokemonMenu._poke.Name + "===");
            foreach (var item in currentAbility)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========Ability you can learn==========");
            List<Ability> listOfAbility = _pokeBL.GetAllAbilities(YourPokemonMenu._poke);
            foreach (var item in listOfAbility)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("[2] Select ability by Id\n[1] Go Back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            //Switch is just a more optimized version of if and elseifs and else
            switch (userInput)
            {
                //Cases are the same as else ifs
                case "1":
                    return MenuType.YourPokemonMenu;
                case "2":
                    try
                    {
                        Console.WriteLine("Please enter Ability Id");
                        int abId = Convert.ToInt32(Console.ReadLine());
                        _pokeBL.AddAbilityToPokemon(YourPokemonMenu._poke, new Ability{Id = abId});

                        Console.WriteLine("Ability was successfully added!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    catch(System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}