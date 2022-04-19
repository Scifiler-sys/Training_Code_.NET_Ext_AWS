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
        private IRepository _repo;
        public PokemonBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        //============================

        public Pokemon AddPokemon(Pokemon p_poke)
        {
            Random rand = new Random();

            //Processing data to meet conditions
            //It will either substract or add a range from -5 to 5
            p_poke.Attack += rand.Next(-5,5);
            p_poke.Defense += rand.Next(-5,5);
            p_poke.Health += rand.Next(-5,5);

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

        public List<Ability> GetAbilityByPokeId(int p_pokeId)
        {
            return _repo.GetAbilityByPokeId(p_pokeId);
        }

        public List<Pokemon> SearchPokemon(string p_name)
        {
            List<Pokemon> listOfPokemon = _repo.GetAllPokemon();


            // LINQ library
            return listOfPokemon
                        .Where(poke => poke.Name.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that our method needs to return

            // foreach (Pokemon poke in listOfPokemon)
            // {
            //     if (poke.Name.Contains(p_name))
            //     {
            //         //Add to another list
            //     }
            // }

            // //return the filtered/another list
        }
    }
}