//Global using so that any c# classes we make inside this project will implicitly start using PokeModel
global using PokeModel;


/*
    Data Layer project is responsible for directly accessing our database and doing any CRUD operations we want to it

    CRUD?
    Create resources
    Delete resources
    Read resources
    Update resources
*/
namespace PokeDL
{
    /*
        We create an interface first to follow abstraction
        More importantly, it is also to follow dependency injection design pattern (which we will cover later)
    */
    public interface IRepository
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

        /// <summary>
        /// Will get all abilities of a Pokemon by pokemon Id
        /// </summary>
        /// <param name="p_pokeId">Pokemon</param>
        /// <returns>Returns list of ability object from the pokemon</returns>
        List<Ability> GetAbilityByPokeId(int p_pokeId);
    }
}