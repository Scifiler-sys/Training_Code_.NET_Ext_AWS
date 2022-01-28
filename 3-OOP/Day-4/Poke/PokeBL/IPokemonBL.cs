global using PokeModel;

/*
    Business layer project is responsible for further processing the data we acquire from the database

    This further processing will really depend on what the functionality you are trying to add
*/
namespace PokeBL
{
    public interface IPokemonBL
    {
        /// <summary>
        /// Will add a pokemon data to the database
        /// Initial addition of a pokemon will give it some sort of a randomize stats
        /// Can only have the total of 4 pokemons in the database
        /// </summary>
        /// <param name="p_poke">Pokemon that is added</param>
        /// <returns>Returns the added pokemon</returns>
        Pokemon AddPokemon(Pokemon p_poke);

        /// <summary>
        /// Will get all the pokemon in the database
        /// </summary>
        /// <returns>List of pokemons</returns>
        List<Pokemon> GetAllPokemon();

        /// <summary>
        /// Will give a list of pokemon that is found in the database
        /// </summary>
        /// <param name="p_name">Uses the name of the pokemon to filter the database</param>
        /// <returns>Return list collection with pokemon founded</returns>
        List<Pokemon> SearchPokemon(string p_name);
    }
}