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
        /// Also randomize the level up to 100
        /// Will also randomize the abilities they have
        /// </summary>
        /// <returns>Pokemon object</returns>
        Pokemon GetRandomPokemon();

        /// <summary>
        /// Will return available abilities for the pokemon based on type from the database
        /// Also checks if Pokemon already has the ability
        /// </summary>
        /// <returns>Ability list collection</returns>
        List<Ability> GetAllAbilities(Pokemon p_poke);

        /// <summary>
        /// Gets current ability from Pokemon
        /// </summary>
        /// <param name="p_poke">The pokemon to get the current ability</param>
        /// <returns>Ability list collection</returns>
        List<Ability> GetAbilityFromPokemon(Pokemon p_poke);
        
        /// <summary>
        /// Adds an ability for a pokemon
        /// </summary>
        /// <param name="p_poke">The pokemon that will be added to an ability</param>
        /// <param name="p_ab">The ability that will be added to</param>
        /// <returns>Ability object being added</returns>
        Ability AddAbilityToPokemon(Pokemon p_poke, Ability p_ab);
        
        /// <summary>
        /// Will randomly give ability to a pokemon based on its type
        /// </summary>
        /// <param name="p_poke">The pokemon being given an ability to</param>
        /// <returns>list of ability given</returns>
        Ability GetRandomAbility(Pokemon p_poke);
    }
}

