
using PokeModel;

namespace PokeDL
{
    /// <summary>
    /// Data layer project is solely responsible for interacting with our database and doing CRUD operations to it
    /// C - Create, U - Update, R - Read, D - Delete
    /// It must not have logical operation that will also manipulate the data it is grabbing
    /// Just think of Data layer as the delivery man of your uber eats. You definitely do not want your delivery man to mess
    /// with the food they are deliverying and just give it to you to do whatever you want afterwards.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Will grab all pokemon data stored in the database
        /// </summary>
        /// <returns>Gives a list collection of pokemon objects</returns>
        List<Pokemon> GetAllPokemon();

        /// <summary>
        /// Will add one pokemon data to the database
        /// </summary>
        /// <param name="p_poke">The pokemon data being added</param>
        /// <returns>Gives the pokemon data that was added</returns>
        Pokemon AddPokemon(Pokemon p_poke);
    }
}
