using System.Text.Json;

namespace PokeDL
{
    public class Repository : IRepository
    {
        private readonly string _filePath = "../PokeDL/Data/pokemon.json";
        private string? _jsonString;
        public Pokemon AddPokemon(Pokemon p_poke)
        {
            List<Pokemon> listOfPoke = this.GetAllPokemon();
            listOfPoke.Add(p_poke);

            this._jsonString = JsonSerializer.Serialize(listOfPoke);
            File.WriteAllText(_filePath, _jsonString);
            
            return p_poke;
        }

        public List<Pokemon> GetAllPokemon()
        {
            try
            {
                this._jsonString = File.ReadAllText(_filePath);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine("File was not found. Please check file path is correct");
                throw exc;
            }

            //There is a possibility it might return a null
            List<Pokemon>? listOfPoke = JsonSerializer.Deserialize<List<Pokemon>>(_jsonString);

            //If statement takes that into account
            if (listOfPoke == null)
            {
                throw new Exception("List of Pokemon is null");
            }
            else
            {
                return listOfPoke;
            }
        }
    }
}