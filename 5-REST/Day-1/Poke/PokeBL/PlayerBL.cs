using PokeDL;
using PokeModel;

namespace PokeBL
{
    public class PlayerBL :  IPlayerBL
    {
        private readonly IRepository<Player> _playerRepo;
        public PlayerBL(IRepository<Player> p_playerRepo)
        {
            _playerRepo = p_playerRepo;
        }
        public Player AddPlayer(Player p_player)
        {
            List<Player> listOfPlayer = _playerRepo.GetAll();

            //Logic that checks if player already exists
            if (listOfPlayer.Where(player => player.Name == p_player.Name).Count() == 1)
            {
                throw new Exception("Player name already exists!");
            }
            else if (p_player.Name == null)
            {
                throw new Exception("Player name was not defined!");
            }
            else
            {
                return _playerRepo.Add(p_player);
            }
        }

        public bool CaptureAttempt()
        {
            throw new NotImplementedException();
        }

        public Player Login(Player p_player)
        {
            List<Player> listOfPlayer = _playerRepo.GetAll();
            Player? found = listOfPlayer.FirstOrDefault(player => player.Name == p_player.Name);

            if (found == null)
            {
                throw new Exception("Player was not found!");
            }
            else
            {
                return found;
            }
        }
    }
}