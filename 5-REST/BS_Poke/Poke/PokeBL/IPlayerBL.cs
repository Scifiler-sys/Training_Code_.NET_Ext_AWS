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
    }
}