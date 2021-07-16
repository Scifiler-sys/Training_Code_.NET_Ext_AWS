using RRModels;
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
        /// Gets a specific restaraunt that matches with the restaurant object we give
        /// </summary>
        /// <param name="p_rest">The object that will get compared</param>
        /// <returns>Returns the matching restaurant</returns>
        Restaurant GetRestaurant(Restaurant p_rest);
        /// <summary>
        /// It will get a specific restaurant based on id
        /// </summary>
        /// <param name="p_id">the id to look for</param>
        /// <returns></returns>
        Restaurant GetRestaurant(int p_id);

        /// <summary>
        /// Gives a list of restaurants stored in our database
        /// </summary>
        /// <returns>Returns a List of restaurant</returns>
        List<Restaurant> GetAllRestaurant();

        /// <summary>
        /// Will add a restaurant in our database
        /// </summary>
        /// <param name="p_rest">The restaurant object that will get added</param>
        /// <returns>Returns the added restaurant</returns>
        Restaurant AddRestaurant(Restaurant p_rest);
        /// <summary>
        /// It will update a restaurant in our database
        /// </summary>
        /// <param name="p_rest">Passes the restaurant we will update</param>
        /// <returns></returns>
        Restaurant UpdateRestaurant(Restaurant p_rest);
        /// <summary>
        /// It will delete a restaurant in our database
        /// </summary>
        /// <param name="p_rest">The restaurant it will delete</param>
        /// <returns></returns>
        Restaurant DeleteRestaurant(Restaurant p_rest);
    }
}
