// See https://aka.ms/new-console-template for more information
global using PokeModel; //global using tells the compiler to implicitly use that namespace for all C# file inside of this project
global using Serilog;
using PokeBL;
using PokeDL;
using PokeUI;

//Creating and configuring our logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") //Where we are saving our logs to
    .CreateLogger(); //Just a method that will create the logger for us after we have configured it

bool repeat = true;
IMenu menu = new MainMenu();
FactoryMenu factory = new FactoryMenu();

//Will repeat the menu so it doesn't stop abruptly
while (repeat)
{

    Console.Clear(); //Clears terminals
    menu.Display(); //Displays menu
    MenuType ans = menu.UserChoice(); //Ask for user choice

    if (ans != MenuType.Exit)
    {
        menu = factory.CreateMenu(ans);
    }
    else
    {
        repeat = false;
    }
}