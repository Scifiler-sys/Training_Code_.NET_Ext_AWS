global using PokeModel;

/// <summary>
/// Business Layer is responsible for further validation or processing of data obtained from either the database or the user
/// What kind of processing? That all depends on the type of functionality you will be doing
/// </summary>
namespace PokeBL
{
    public interface IPokemonBL
    {
        /// <summary>
        /// Will add a restaurant in the database 
        /// </summary>
        /// <param name="p_poke">The pokemon that will be added</param>
        /// <returns>Will return the saved pokemon</returns>
        Pokemon AddPokemon(Pokemon p_poke);

        /// <summary>
        /// Will get all the pokemon in the database
        /// </summary>
        /// <returns>List of pokemons</returns>
        List<Pokemon> GetAllPokemon();
    }
}