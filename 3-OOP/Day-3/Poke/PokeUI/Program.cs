// See https://aka.ms/new-console-template for more information
// using PokeModel;

// Console.Clear();
// //Checking if creating out models is working
// Pokemon poke1 = new Pokemon();
// Console.WriteLine(poke1);
// Console.WriteLine(poke1.Abilities[0]);
// // List<Ability> abilityList = new List<Ability>();
// // poke1.Abilities = abilityList; //Our validation is working
// Console.WriteLine("Defend value: " + poke1.DefendMove());

// Ability ability1 = new Ability();
// // ability1.PP = 0; //Our validation is working
// Console.WriteLine(ability1);

// //Checking if inheritance works
// GrassType bulbasaur = new GrassType();
// Console.WriteLine(bulbasaur); //GrassType class has everything from Pokemon class
// Console.WriteLine("Defend value: " + bulbasaur.DefendMove()); //Grasstype overrides the defendmove from pokemon class
// Console.WriteLine("Defend value: " + bulbasaur.DefendMove(300)); //Grasstype overloads the defendmove to also take in a integer parameter

// //Checking if User-defined conversion works
// string name = "Bayleef";
// int attack = 70;
// GrassType Bayleef = name;
// GrassType Bayleef2 = (GrassType)attack;
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
        case MenuType.AddPokemon:
            Log.Information("Diplaying AddPokemon menu");
            menu = new AddPokemon(new PokemonBL(new Repository()));
            break;
        case MenuType.MainMenu:
            Log.Information("Displaying MainMenu");
            menu = new MainMenu();
            break;
        case MenuType.SearchPokemon:
            Log.Information("Displaying SearchPokemon menu");
            menu = new SearchPokemon(new PokemonBL(new Repository()));
            break;
        default:
            Log.Information("Rerouted to page that doesn't exist");
            Console.WriteLine("Page does not exist");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}