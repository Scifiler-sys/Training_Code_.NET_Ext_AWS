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
        public PokemonBL(IRepository<Pokemon> p_pokeRepo)
        {
            _pokeRepo = p_pokeRepo;
        }
        //============================

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