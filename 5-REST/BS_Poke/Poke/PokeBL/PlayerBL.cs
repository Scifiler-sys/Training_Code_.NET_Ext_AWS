using PokeDL;
using PokeModel;

namespace PokeBL
{
    public class PlayerBL :  IPlayerBL
    {
        private readonly IRepository<Player> _playerRepo;
        private readonly IRepository<Pokemon> _pokeRepo;
        private readonly IRepository<Team> _teamRepo;
        public PlayerBL(IRepository<Player> p_playerRepo, IRepository<Team> p_teamRepo, IRepository<Pokemon> p_pokeRepo)
        {
            _playerRepo = p_playerRepo;
            _teamRepo = p_teamRepo;
            _pokeRepo = p_pokeRepo;
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

        public bool CaptureAttempt(Pokemon p_poke, Player p_player)
        {
            Random rand = new Random();

            //Algorithm to compute your chances
            int successChance = (int)Math.Max(0,rand.Next(0,100) - (Math.Pow(p_poke.Level,2)/100));

            //Must be above 30 to have a chance of capturing
            if (successChance > 30)
            {
                _teamRepo.Add(new Team{
                    PlayerId = p_player.Id,
                    PokeId = p_poke.Id,
                    PokeLevel = p_poke.Level
                });
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Pokemon> GetYourPokemon(Player p_player)
        {
            List<Pokemon> yourPokeList = (from pokemon in _pokeRepo.GetAll()
                                join team in _teamRepo.GetAll() on pokemon.Id equals team.PokeId
                                join player in _playerRepo.GetAll() on team.PlayerId equals player.Id
                                select new Pokemon {
                                    Id = pokemon.Id,
                                    TeamId = team.TeamId,
                                    Attack = PokeRealStatCalculator(pokemon.Attack, team.PokeLevel),
                                    Defense = PokeRealStatCalculator(pokemon.Defense, team.PokeLevel),
                                    Health = PokeRealStatCalculator(pokemon.Health, team.PokeLevel),
                                    Speed = PokeRealStatCalculator(pokemon.Speed, team.PokeLevel),
                                    Level = team.PokeLevel,
                                    Type = pokemon.Type,
                                    Name = pokemon.Name
                                }).ToList();


            return yourPokeList;
        }



        //Calculates pokemon real stat based on their level
        //Base stats is their scaling (higher the base stat, the better the scaling)
        //For math nerds: pokemon's level*base_stat/50 + current base state
        private int PokeRealStatCalculator(int p_stat, int p_level)
        {
            return (int)Math.Round(p_stat + p_level*((double)p_stat/50));
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