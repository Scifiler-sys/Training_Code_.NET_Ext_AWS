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