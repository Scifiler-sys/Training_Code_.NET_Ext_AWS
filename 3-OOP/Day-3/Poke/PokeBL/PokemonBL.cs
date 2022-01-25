using PokeDL;

namespace PokeBL
{
    public class PokemonBL : IPokemonBL
    {
        //Dependency injection
        //Why? because PokemonBL depends on Repository to be able to do its functionality
        //Why interfaces? It will make more sense once we start changing our files around
        private readonly IRepository _repo;
        public PokemonBL(IRepository p_repo)
        {
            this._repo = p_repo;
        }
        public Pokemon AddPokemon(Pokemon p_poke)
        {
            if (this.GetAllPokemon().Count < 4)
            {
                return _repo.AddPokemon(p_poke);
            }
            else
            {
                throw new Exception("You can no longer add anymore pokemon to your team!");
            }
        }

        public List<Pokemon> GetAllPokemon()
        {
            return _repo.GetAllPokemon();
        }
    }
}
