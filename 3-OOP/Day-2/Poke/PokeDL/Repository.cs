using System.Text.Json;
using PokeModel;

namespace PokeDL
{
    public class Repository : IRepository
    {
        //The relative filepath is based on the starting point of your application
        //Since our main entry point is our console app which is our UI then our relative filepath will be the PokeUI project
        private readonly string _filepath = "../PokeDL/Database/Pokemon.json";
        private string _jsonString = "";
        public Pokemon AddPokemon(Pokemon p_poke)
        {
            //This is to initialize and create our Pokemon.json file first
            //We will remove this lines of code and replace it with reading our existing JSON file once it has been created
            // List<Pokemon> firstAddition = new List<Pokemon>();
            // firstAddition.Add(p_poke);

            List<Pokemon> listOfPokemon = GetAllPokemon();
            listOfPokemon.Add(p_poke);

            _jsonString = JsonSerializer.Serialize(listOfPokemon, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath,_jsonString);

            return p_poke;
        }

        public List<Pokemon> GetAllPokemon()
        {
            _jsonString = File.ReadAllText(_filepath);

            return JsonSerializer.Deserialize<List<Pokemon>>(_jsonString);
        }
    }
}