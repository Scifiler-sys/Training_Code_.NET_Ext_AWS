using RRModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RRDL
{
    /// <summary>
    /// Implementation details of the IRepository interface
    /// </summary>
    public class Repository : IRepository
    {
        private const string _filePath = "./Database/Restaurant.json";
        private string _jsonString;
        public Restaurant AddRestaurant(Restaurant p_rest)
        {
            List<Restaurant> listOfRestaurants = GetAllRestaurant();
            listOfRestaurants.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfRestaurants, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, _jsonString);
            return p_rest;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            try
            {
                //We read the json file from out database
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found. Please provide the right file path.");
                return new List<Restaurant>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown exception was thrown");
                throw;
            }

            //We deserialize it into a list of restaurants
            return JsonSerializer.Deserialize<List<Restaurant>>(_jsonString);
        }

        public Restaurant GetRestaurant(Restaurant p_rest)
        {
            //LINQ expressions has a handful of methods for us to utilize (GO RESEARCH IT SINCE IT WILL MAKE YOUR CODING LIFE EASIER)
            //FirstOrDefault allows us to grab one instance from the List given some sort of condition we set
            return GetAllRestaurant().FirstOrDefault(rest => rest.Equals(p_rest)); //=> gives a lambda operator
            //Create the equals method in the model so it makes more sense what we are comparing
        }
    }
}
