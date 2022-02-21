using PokeModel;

namespace PokeBL
{
    public interface IPlayerBL
    {
        /// <summary>
        /// Add player to the database
        /// </summary>
        /// <param name="p_player">player object that is being added</param>
        /// <returns>Player object added</returns>
        Player AddPlayer(Player p_player);

        /// <summary>
        /// Checks if player exists in database
        /// </summary>
        /// <param name="p_player">Player being checked</param>
        /// <returns>Found player</returns>
        Player Login(Player p_player);

        /// <summary>
        /// Capture attempt of the player
        /// Capture attempt lessens as the higher the poke level (exponentially harder and impossible at max level)
        /// </summary>
        /// <returns>Successful or failure</returns>
        
        /// <summary>
        /// Capture attempt of the player
        /// Capture attempt lessens as the higher the poke level (exponentially harder and impossible at max level)
        /// </summary>
        /// <param name="p_poke">Pokemon object that is trying to be captured</param>
        /// <param name="p_player">Player object that is doing the capturing</param>
        /// <returns>Successful or not</returns>
        bool CaptureAttempt(Pokemon p_poke, Player p_player);

        /// <summary>
        /// Gets the pokemon of the player
        /// </summary>
        /// <param name="p_player">The player that is getting their pokemon</param>
        /// <returns>Gives a list of pokemon objects</returns>
        List<Pokemon> GetYourPokemon(Player p_player);
    }
}