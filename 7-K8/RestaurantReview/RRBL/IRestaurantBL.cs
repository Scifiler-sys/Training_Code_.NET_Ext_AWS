using RRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRBL
{
    /// <summary>
    /// Handles all the business logic for the restaurant model
    /// They are in charge of further processing/ sanitizing/ further validating data
    /// Any logic to accessing the data is exclusive for Data Access Layer (DO NOT PUT THE LOGIC HERE)
    /// Ex: The logic could depend such as maybe whenever you add a restaurant to manipulate one of the propeties before you add it to the database
    /// </summary>
    public interface IRestaurantBL
    {
        /// <summary>
        /// Gets a list of Restaurants stored in our database
        /// </summary>
        /// <returns>Returns a list of Restaurant</returns>
        Task<List<Restaurant>> GetAllRestaurantAsync();

        /// <summary>
        /// It will get a specific restaurant
        /// </summary>
        /// <param name="p_rest">This restaurant object will be used to check the properties that should match in the database</param>
        /// <returns>Will return the restaurant object from the database</returns>
        Task<Restaurant> GetRestaurantAsync(Restaurant p_rest);
        /// <summary>
        /// It will get a specific restaurant based on id
        /// </summary>
        /// <param name="p_id">the id to look for</param>
        /// <returns></returns>
        Task<Restaurant> GetRestaurantAsync(int p_id);

        /// <summary>
        /// It will add a restaurant in our database
        /// </summary>
        /// <param name="p_rest">This is the restaurant object that will be added to the database</param>
        /// <returns>Will return the restaurant object we just added</returns>
        Task<Restaurant> AddRestaurantAsync(Restaurant p_rest);
        /// <summary>
        /// It will update a restaurant in our database
        /// </summary>
        /// <param name="p_rest">Passes the restaurant we will update</param>
        /// <returns></returns>
        Task<Restaurant> UpdateRestaurantAsync(Restaurant p_rest);
        /// <summary>
        /// It will delete a restaurant in our database
        /// </summary>
        /// <param name="p_rest">The restaurant it will delete</param>
        /// <returns></returns>
        Task<Restaurant> DeleteRestaurantAsync(Restaurant p_rest);
    }
}
