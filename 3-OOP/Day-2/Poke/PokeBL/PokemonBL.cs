using PokeDL;

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
        //===========================

        public Pokemon AddPokemon(Pokemon p_poke)
        {
            //Processing data
            //We randomize the potential stats we get when we add a pokemon to the database
            //This is an example of a further processing of data that should only belong in BL project
            //Don't put it on the UI (as tempting as it might be) or the DL
            Random rand = new Random();
            p_poke.Attack += rand.Next(-5,5);
            p_poke.Defense += rand.Next(-5,5);
            p_poke.Health += rand.Next(-5,5);

            //Validation of data
            //Making sure you can only add up to 4 pokemon
            List<Pokemon> listOfCurrentPokemon = _repo.GetAllPokemon();

            if (listOfCurrentPokemon.Count < 4)
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
