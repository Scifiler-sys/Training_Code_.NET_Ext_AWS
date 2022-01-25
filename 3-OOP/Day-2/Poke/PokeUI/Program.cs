// See https://aka.ms/new-console-template for more information
using PokeBL;
using PokeDL;
using PokeUI;

bool repeat = true;
IMenu menu = new MainMenu();

//Will repeat the menu so it doesn't stop abruptly
while (repeat)
{

    Console.Clear(); //Clears terminals
    menu.Display(); //Displays menu
    MenuType ans = menu.UserChoice(); //Ask for user choice

    //Main place where we change our pages
    switch (ans)
    {
        case MenuType.Exit:
            repeat = false;
            break;
        case MenuType.AddPokemon:
            menu = new AddPokemon(new PokemonBL(new Repository()));
            break;
        case MenuType.MainMenu:
            menu = new MainMenu();
            break;
        default:
            Console.WriteLine("Page does not exist");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}