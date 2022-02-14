using PokeModel;

namespace PokeBL
{
    /// <summary>
    /// Business Layer is responsible for further validation or processing of data obtained from either the database or the user
    /// What kind of processing? That all depends on the type of functionality you will be doing
    /// </summary>
    public interface IPokemonBL
    {
        /// <summary>
        /// Will return a randomize pokemon from a list of pokemon from the database
        /// Also randomize the level up to 3
        /// </summary>
        /// <returns>Pokemon object</returns>
        Pokemon GetRandomPokemon();
    }
}

