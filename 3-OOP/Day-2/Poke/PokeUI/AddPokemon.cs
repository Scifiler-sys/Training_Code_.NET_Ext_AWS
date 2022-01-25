using PokeBL;
using PokeModel;

namespace PokeUI
{
    public class AddPokemon : IMenu
    {
        private static Pokemon _newPoke = new Pokemon();
        
        //Dependency Injection
        //==========================
        private IPokemonBL _pokeBL;
        public AddPokeMenu(IPokemonBL p_pokeBL)
        {
            _pokeBL = p_pokeBL;
        }
        //==========================
        
        public void Display()
        {
            Console.WriteLine("Enter Pokemon information");
            Console.WriteLine("[3] Name - " + _newPoke.Name);
            Console.WriteLine("[2] Level - " + _newPoke.Level);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }
       public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    try
                    {
                        _pokeBL.AddPokemon(_newPoke);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    
                    return MenuType.MainMenu;
                case "2":
                    Console.WriteLine("Enter Level");
                    _newPoke.Level = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddPokemon;
                case "3":
                    Console.WriteLine("Enter Name");
                    _newPoke.Name = Console.ReadLine();
                    return MenuType.AddPokemon;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddPokemon;
            }
        }
    }
}