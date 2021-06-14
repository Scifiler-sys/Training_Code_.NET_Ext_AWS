using System;
using System.IO;
using System.Text.Json;
using HouseFunction;

namespace HelloWorld
{
    public class Serialization
    {
        private const string _filePath = "./StoredFile/House.json";
        public static void SerialMain()
        {
            //Created house object to be serialized
            House house1 = new House()
            {
                Color = "red",
                Price = 100000
            };

            //declared a string var and point it to the serialized version of the house1
            string jsonString = JsonSerializer.Serialize(house1);

            //Seeing the string
            Console.WriteLine(jsonString);

            //Storing our string into a JSON file
            File.WriteAllText(_filePath, jsonString);

            //Deserialize the object we just stored
            try
            {
                jsonString = File.ReadAllText(_filePath);
                House house2 = JsonSerializer.Deserialize<House>(jsonString);
                Console.WriteLine(house2);
            }
            catch (FileNotFoundException e)
            {
                //Will catch the error if the file can't be found by the given filePath
                Console.WriteLine(e);
                throw;
            }
        }
    }
}