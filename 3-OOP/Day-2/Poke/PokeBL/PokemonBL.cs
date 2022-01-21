using PokeDL;
using PokeModel;


namespace PokeBL
{
    public class PokemonBL : IPokemonBL
    {
        //We created dependency injection to essentially specify to whoever use this class
        //It will depend on another class to achieve its functionalities
        //We exclusively used interfaces to abstract the implementation details
        //It will also immensely make it easy to update other projects without affecting another project
        private IRepository _repo;
        public PokemonBL(IRepository p_repo)
        {
            _repo = p_repo;
        }



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
                throw new Exception("Cannot have more than 4 pokemon!");
            }
        }
    }
}