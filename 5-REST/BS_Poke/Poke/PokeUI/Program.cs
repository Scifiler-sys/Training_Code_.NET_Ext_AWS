// See https://aka.ms/new-console-template for more information
global using PokeModel; //global using tells the compiler to implicitly use that namespace for all C# file inside of this project
global using Serilog;
using Microsoft.Extensions.Configuration;
using PokeBL;
using PokeDL;
using PokeUI;

//Creating and configuring our logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") //Where we are saving our logs to
    .CreateLogger(); //Just a method that will create the logger for us after we have configured it

//Grabbing our safely stored connection string from a JSON file
//Using Configuration package to manage it (why the complexity and not just use File.ReadAllText?)
//Later down the line, more complex projects using a configuration object to manage grabbing sensitive/configuration information
//So good to understand what it is doing here
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()) //Sets the current path relative to where PokeUI folder is
        .AddJsonFile("appsettings.json") //Grabs our JSON file
        .Build(); //Builds the configuration object

//Storing the connection string to a string variable
string _connection = configuration.GetConnectionString("Reference2DB");

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
            Log.Information("Exiting Application");
            Log.CloseAndFlush(); //To close our logger resource
            repeat = false;
            break;
        case MenuType.MainMenu:
            Log.Information("Displaying MainMenu");
            menu = new MainMenu();
            break;
        case MenuType.RegisterMenu:
            Log.Information("Displaying Register Menu");
            menu = new RegisterMenu(new PlayerBL(new PlayerRepo(_connection), new TeamRepo(_connection), new PokemonRepo(_connection)));
            break;
        case MenuType.LoginMenu:
            Log.Information("Displaying Login Menu");
            menu = new LoginMenu(new PlayerBL(new PlayerRepo(_connection), new TeamRepo(_connection), new PokemonRepo(_connection)));
            break;
        case MenuType.CapturePokemonMenu:
            Log.Information("Displaying Capture Menu");
            menu = new CapturePokemonMenu(new PokemonBL(new PokemonRepo(_connection)), new PlayerBL(new PlayerRepo(_connection), new TeamRepo(_connection), new PokemonRepo(_connection)));
            break;
        case MenuType.YourPokemonMenu:
            Log.Information("Displaying User's Pokemon");
            menu = new YourPokemonMenu(new PlayerBL(new PlayerRepo(_connection), new TeamRepo(_connection), new PokemonRepo(_connection)));
            break;
        default:
            Log.Information("Rerouted to page that doesn't exist");
            Console.WriteLine("Page does not exist");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}