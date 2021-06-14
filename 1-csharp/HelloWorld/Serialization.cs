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
                //ReadAllText method might throw an error if it isn't able to find the filepath
                //We will handle it 
                jsonString = File.ReadAllText(_filePath+ "sedf");//+"askljhfe");
                House house2 = JsonSerializer.Deserialize<House>(jsonString);
                Console.WriteLine(house2);
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
        }
    }
}