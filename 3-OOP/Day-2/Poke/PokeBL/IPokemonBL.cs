using PokeModel;

namespace PokeBL
{
    /// <summary>
    /// Business Layer is responsible for further validation or processing of the data obtained from the database
    /// What kind of processing? That all depends on the type of functionality you will be doing
    /// </summary>
    public interface IPokemonBL
    {
        /// <summary>
        /// Will add a pokemon data to the database
        /// Initial addition of a pokemon will give it some sort of randomize stats
        /// Can only have a total of 4 pokemon
        /// </summary>
        /// <param name="p_poke">The pokemon data being added to the database</param>
        /// <returns>Gives the added pokemon data back</returns>
        Pokemon AddPokemon(Pokemon p_poke);
    }
}