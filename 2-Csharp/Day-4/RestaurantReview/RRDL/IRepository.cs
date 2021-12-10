using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRDL
{
    /// <summary>
    /// Responsible for accessing our database (for this case our database for now will be a json file)
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets a specific restaraunt that matches with the restaurant object we give
        /// </summary>
        /// <param name="p_rest">The object that will get compared</param>
        /// <returns>Returns the matching restaurant</returns>
        Restaurant GetRestaurant(Restaurant p_rest);

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
    }
}
