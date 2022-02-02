namespace PokeUI
{
     /*
        - Since MainMenu inherits IMenu, anything IMenu has, MainMenu will have
        - However, since it is an interface, MainMenu must implement some code for those methods

        - This gives us the capability to force MainMenu to have two methods 
        and force it to also give those two methods some implementation
        but why?
    */
    public class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to Pokemon!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] Search Pokemon");
            Console.WriteLine("[1] Add Pokemon to your team");
            Console.WriteLine("[0] Exit");
            
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            //Switch is just a more optimized version of if and elseifs and else
            switch (userInput)
            {
                //Cases are the same as else ifs
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.AddPokemon;
                case "2":
                    return MenuType.SearchPokemon;
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