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
        /// </summary>
        /// <returns>Successful or failure</returns>
        bool CaptureAttempt();
    }
}