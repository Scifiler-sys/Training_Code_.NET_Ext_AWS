using PokeDL;

namespace PokeBL
{
    public class PokemonBL : IPokemonBL
    {
        //Dependency injection
        //Why? because PokemonBL depends on Repository to be able to do its functionality
        //Why interfaces? It will make more sense once we start changing our files around
        private readonly IRepository _repo;
        private readonly Random _rand;
        public PokemonBL(IRepository p_repo, Random p_rand)
        {
            this._repo = p_repo;
            this._rand = p_rand;
        }
        public Pokemon AddPokemon(Pokemon p_poke)
        {
            //Processing data to meet conditions
            //It will either substract or add a range from -5 to 5
            p_poke.Attack += _rand.Next(-5,5);
            p_poke.Defense += _rand.Next(-5,5);
            p_poke.Health += _rand.Next(-5,5);

            //Validation process
            List<Pokemon> listOfPoke = _repo.GetAllPokemon();
            if (listOfPoke.Count < 4)
            {
                return _repo.AddPokemon(p_poke);
            }
            else
            {
                throw new Exception("You cannot have more than 4 pokemons!");
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
