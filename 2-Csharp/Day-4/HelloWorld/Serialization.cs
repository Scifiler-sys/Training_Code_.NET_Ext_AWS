using System;
using System.IO;
using System.Text.Json;
using CarFunction;

namespace HelloWorld
{
    public class Serialization
    {
        private const string _filePath = "./StoredFile/House.json";
        public static void SerialMain() 
        {
            //Created car object to be serialized
            Car car1 = new Car()
            {
                Color = "Blue",
                Fuel = 10000,
                GallonPerMile = 10
            };

            //declared a string var and point it to the serialized version of the house1
            //We added JsonSerializerOptions to format it better for us (it uses more memory though thats why by default it is a single line to save space)
            string jsonString = JsonSerializer.Serialize(car1, new JsonSerializerOptions {WriteIndented = true});

            //Seeing the string
            Console.WriteLine(jsonString);

            //Storing our string into a JSON file
            File.WriteAllText(_filePath, jsonString);

            //Deserialize the object we just stored
            try
            {
                //ReadAllText method might throw an error if it isn't able to find the filepath
                //We will handle it 
                jsonString = File.ReadAllText(_filePath);//+"askljhfe");
                Car car2 = JsonSerializer.Deserialize<Car>(jsonString);
                Console.WriteLine(car2);
                // throw new Exception("unknown error");
            }
            catch (FileNotFoundException)
            {
                //Will catch the error if the file can't be found by the given filePath
                //Console.WriteLine(e);
                Console.WriteLine("The file could not be found. Please give the correct file path");
                // throw new Exception("The file could not be found. Please give the correct file path");
            }
            catch(Exception) //It is the base class that all exception classes inherits from
            {
                Console.WriteLine("Code went through some unknown error");
            }

            //Documentation
            //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0
        }
    }
}