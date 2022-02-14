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
        public void Display()
        {
            Console.WriteLine
(
@"
You have encountered a Pokemon!
What would you like to do?
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
                    return MenuType.CapturePokemonMenu;
                //Default is the same as an else
                case "4":
                    return MenuType.GetPokeAbility;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}