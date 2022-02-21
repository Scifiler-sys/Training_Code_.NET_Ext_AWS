using Microsoft.Extensions.Configuration;
using PokeBL;
using PokeDL;

namespace PokeUI
{
    public class FactoryMenu : IFactory
    {
        private readonly string _connection;
        public FactoryMenu()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) //Sets the current path relative to where PokeUI folder is
            .AddJsonFile("appsettings.json") //Grabs our JSON file
            .Build(); //Builds the configuration object

            //Storing the connection string to a string variable
            _connection = configuration.GetConnectionString("Reference2DB");
        }
        public IMenu CreateMenu(MenuType p_menu)
        {
            switch (p_menu)
            {
            case MenuType.RegisterMenu:
                Log.Information("Displaying Register Menu");
                return new RegisterMenu(CreatePlayerBL());
            case MenuType.LoginMenu:
                Log.Information("Displaying Login Menu");
                return new LoginMenu(CreatePlayerBL());
            case MenuType.CapturePokemonMenu:
                Log.Information("Displaying Capture Menu");
                return new CapturePokemonMenu(CreatePokeBL(), CreatePlayerBL());
            case MenuType.YourPokemonMenu:
                Log.Information("Displaying User's Pokemon");
                return new YourPokemonMenu(CreatePlayerBL());
            case MenuType.LearnAbilityMenu:
                Log.Information("Displaying Learn Ability Menu");
                return new LearnAbilityMenu(CreatePokeBL());
            case MenuType.BattleMenu:
                Log.Information("Displaying Battle Menu");
                return new BattleMenu(CreatePokeBL(), CreatePlayerBL());
            default:
                Log.Information("Displaying MainMenu");
                return new MainMenu();
            }
        }

        private IPokemonBL CreatePokeBL()
        {
            return new PokemonBL(new PokemonRepo(_connection), new AbilityRepo(_connection), new ArsenalRepo(_connection), new TeamRepo(_connection));
        }

        private IPlayerBL CreatePlayerBL()
        {
            return new PlayerBL(new PlayerRepo(_connection), new TeamRepo(_connection), new PokemonRepo(_connection));
        }
    }
}