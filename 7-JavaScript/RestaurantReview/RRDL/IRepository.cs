using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RRModel;

namespace RRDL
{
    /// <summary>
    /// It is responsible for accessing our database (in this case it will be a JSON file stored in our folder)
    /// </summary>
    public interface IRepository
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
        /// It will get a specific restaurant based on id Async
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
        /// <summary>
        /// It will add a review and attach it to a restaurant
        /// </summary>
        /// <param name="p_rest">Passes the restaurant we will attach the review to</param>
        /// <param name="p_rev">The review we will add to the restaurant</param>
        /// <returns></returns>
        Task<Review> AddReviewAsync(Restaurant p_rest, Review p_rev);
        /// <summary>
        /// It will get all the reviews
        /// </summary>
        /// <param name="p_rest">Gets the reviews that is attached to that restaurant</param>
        /// <returns></returns>
        Task<List<Review>> GetReviewsAsync(Restaurant p_rest);
    }
}
