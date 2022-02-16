using PokeDL;
using PokeModel;

namespace PokeBL
{
    public class PokemonBL : IPokemonBL
    {

        //Dependency Injection Pattern
        //- This is the main reason why we created interface first before the class
        //- This will save you time on re-writting code that breaks if you updated a completely separate class
        //- Main reason is to prevent us from re-writting code that already existed on (potentailly) 50 files or more without
        //the compiler helping us
        //===========================
        private IRepository<Pokemon> _pokeRepo;
        private IRepository<Ability> _abRepo;
        private IRepository<Arsenal> _arRepo;
        private IRepository<Team> _teamRepo;
        public PokemonBL(IRepository<Pokemon> p_pokeRepo, IRepository<Ability> p_abRepo, IRepository<Arsenal> p_arRepo, IRepository<Team> p_teamRepo)
        {
            _pokeRepo = p_pokeRepo;
            _abRepo = p_abRepo;
            _arRepo = p_arRepo;
            _teamRepo = p_teamRepo;
        }

        public Ability AddAbilityToPokemon(Pokemon p_poke, Ability p_ab)
        {
            List<Ability> currentAbilities = GetAbilityFromPokemon(p_poke);

            if (currentAbilities.Where(ab => ab.Id == p_ab.Id).Count() > 0)
            {
                throw new Exception("This pokemon already has that ability!");
            }
            else
            {
                _arRepo.Add(new Arsenal{
                    AbId = p_ab.Id,
                    TeamId = p_poke.TeamId,
                    CurrentPP = p_ab.PP
                });
                return p_ab;
            }
        }

        public List<Ability> GetAbilityFromPokemon(Pokemon p_poke)
        {
            List<Ability> yourAbility = (from team in _teamRepo.GetAll()
                                        join arsenal in _arRepo.GetAll() on team.TeamId equals arsenal.TeamId
                                        join ability in _abRepo.GetAll() on arsenal.AbId equals ability.Id
                                        where team.TeamId == p_poke.TeamId
                                        select new Ability {
                                            Id = ability.Id,
                                            Accuracy = ability.Accuracy,
                                            Name = ability.Name,
                                            Power = ability.Power,
                                            PP = arsenal.CurrentPP,
                                            Type = ability.Type
                                        }
                                        )
                                        .ToList();
            
            return yourAbility;
        }

        public List<Ability> GetAllAbilities(Pokemon p_poke)
        {
            List<Ability> listOfAbility = _abRepo.GetAll();

            return listOfAbility.Where(ability => ability.Type == p_poke.Type 
                                || ability.Type == "Neutral")
                                .ToList();
        }

        public Ability GetRandomAbility(Pokemon p_poke)
        {
            Random rand = new Random();
            List<Ability> listOfAbility = GetAllAbilities(p_poke);

            return listOfAbility[rand.Next(0,listOfAbility.Count)];
        }

        public Pokemon GetRandomPokemon()
        {
            Random rand = new Random();
            List<Pokemon> listOfPokemon = _pokeRepo.GetAll();

            Pokemon randPoke = listOfPokemon[rand.Next(0, listOfPokemon.Count)];
            randPoke.Level = rand.Next(1,100);

            return randPoke;
        }

        
    }
}