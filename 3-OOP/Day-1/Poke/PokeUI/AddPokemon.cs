using PokeModel;

namespace PokeUI
{
    public class AddPokemon : IMenu
    {
        private static Pokemon newPoke = new Pokemon();
        // public AddPokemon()
        // {
        //     newPoke = new Pokemon();
        // }
        public void Display()
        {
            Console.WriteLine("Enter Pokemon information");
            Console.WriteLine("[3] Name - " + newPoke.Name);
            Console.WriteLine("[2] Level - " + newPoke.Level);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }
       public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "AddPokemon";
                case "2":
                    Console.WriteLine("Enter Level");
                    newPoke.Level = Convert.ToInt32(Console.ReadLine());
                    return "AddPokemon";
                case "3":
                    Console.WriteLine("Enter Name");
                    newPoke.Name = Console.ReadLine();
                    return "AddPokemon";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddPokemon";
            }
        }
    }
}