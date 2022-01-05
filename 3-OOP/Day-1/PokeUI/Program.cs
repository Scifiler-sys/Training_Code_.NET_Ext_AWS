// See https://aka.ms/new-console-template for more information
// using PokeModel;

// //Checking if creating out models is working
// Pokemon poke1 = new Pokemon();
// Console.WriteLine(poke1);
// Console.WriteLine(poke1.Abilities[0]);
// // List<Ability> abilityList = new List<Ability>();
// // poke1.Abilities = abilityList; //Our validation is working

// Ability ability1 = new Ability();
// // ability1.PP = 0; //Our validation is working
// Console.WriteLine(ability1);

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