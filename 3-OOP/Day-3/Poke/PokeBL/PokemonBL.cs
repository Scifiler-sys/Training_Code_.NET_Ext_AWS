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

        public List<Pokemon> SearchPokemon(string p_name)
        {
            List<Pokemon> listOfPokemon = GetAllPokemon();
            
            //Fancy way of doing it using LINQ library
            //I do not expect you to know this but if you are curious this is another way
            //LINQ is just a very fancy library that is incredibly useful for querying information
            return listOfPokemon.Where(poke => poke.Name.Contains(p_name)).ToList();

            //Another perfectly fine logic is to use a normal for loop and go through the collection to find the right pokemon
        }
    }
}
