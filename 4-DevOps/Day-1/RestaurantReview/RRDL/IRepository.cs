using System;
using System.Collections.Generic;
using RRModels;

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
        List<Restaurant> GetAllRestaurant();

        /// <summary>
        /// It will get a specific restaurant
        /// </summary>
        /// <param name="p_rest">This restaurant object will be used to check the properties that should match in the database</param>
        /// <returns>Will return the restaurant object from the database</returns>
        Restaurant GetRestaurant(Restaurant p_rest);
        /// <summary>
        /// It will get a specific restaurant based on id
        /// </summary>
        /// <param name="p_id">the id to look for</param>
        /// <returns></returns>
        Restaurant GetRestaurant(int p_id);

        /// <summary>
        /// It will add a restaurant in our database
        /// </summary>
        /// <param name="p_rest">This is the restaurant object that will be added to the database</param>
        /// <returns>Will return the restaurant object we just added</returns>
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
        /// <summary>
        /// It will add a review and attach it to a restaurant
        /// </summary>
        /// <param name="p_rest">Passes the restaurant we will attach the review to</param>
        /// <param name="p_rev">The review we will add to the restaurant</param>
        /// <returns></returns>
        Review AddReview(Restaurant p_rest, Review p_rev);
        /// <summary>
        /// It will get all the reviews
        /// </summary>
        /// <param name="p_rest">Gets the reviews that is attached to that restaurant</param>
        /// <returns></returns>
        List<Review> GetReviews(Restaurant p_rest);
    }
}
