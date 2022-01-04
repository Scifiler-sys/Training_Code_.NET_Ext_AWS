using System;
using System.IO;
using System.Text.Json;
using CarFunction;

namespace SerializationFunction
{
    /// <summary>
    /// Serialization is the process of converting your objects into a stream of bytes (101001010) or a JSON file or an XML file for storage or transfer.
    /// We will be using JSON files since in this modern world that is one of the most popular file format that is used to store/transfer info
    /// Serialization is helpful to store information that you want to persist even if you close down your program since it will be stored in your harddrive
    /// Anything stored in a collection or in array gets removed the moment you close down your program so they are more useful as a temporary storage in your program
    /// </summary>
    public class Serialization
    {
        
        //We will use a string datatype to store where we will be creating that json file
        private const string _filePath = "./Data/Car.json";
        
        public static void SerialMain() 
        {
            Console.WriteLine("=== Serialization Demo ===");
            //Created car object to be serialized
            Car car1 = new Car()
            {
                Color = "Yellow",
                Fuel = 10000,
                GallonPerMile = 10
            };

            /*
                We will use a premade class called JsonSerializer that was made just for us to convert a C# object (Can also convert some collections)
                JsonSerializer has a Serialize method that converts a C# object into a string datatype that is formatted to be a JSON file
                JsonSerializerOption class is there for us to configure how we want this method to behave (since there is a lot of options you can do)
                One of the options is WriteIndented and that can format your JSON file to look more readable for human eyes
                By default, it is set to false to save memory
            */
            string jsonString = JsonSerializer.Serialize(car1, new JsonSerializerOptions {WriteIndented = true});
            Console.WriteLine(jsonString);

            /*
                We will use a premade class called File that can be used to read/write files 
                WriteAllText will create a file for us that will store the jsonString we generated previously
            */
            File.WriteAllText(_filePath, jsonString);

            /*
                Deserialize method will convert a JSON formatted string back into a C# object
                You must denote what class that object will follow
            */
            try
            {
                //ReadAllText method might throw an error if it isn't able to find the filepath
                //We will handle it 
                jsonString = File.ReadAllText(_filePath);//+"askljhfe");
                Car car2 = JsonSerializer.Deserialize<Car>(jsonString); //<T> is where you denote what class that JSON object will be map to
                Console.WriteLine(car2.Color);
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
            finally
            {
                //This block of code will run regardless if there was an exception or not
                Console.WriteLine("Finally block was executed");
            }

            //Documentation
            //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0
        }
    }
}