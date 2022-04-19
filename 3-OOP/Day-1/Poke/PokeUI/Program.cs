// See https://aka.ms/new-console-template for more information
using PokeUI;
bool repeat = true;
IMenu menu = new MainMenu();

//Will repeat the menu so it doesn't stop abruptly
while (repeat)
{

    Console.Clear(); //Clears terminals
    menu.Display(); //Displays menu
    string ans = menu.UserChoice(); //Ask for user choice

    //Main place where we change our pages
    switch (ans)
    {
        case "Exit":
            repeat = false;
            break;
        case "AddPokemon":
            menu = new AddPokemon();
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        default:
            Console.WriteLine("Page does not exist");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}