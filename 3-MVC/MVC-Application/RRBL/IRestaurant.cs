using System;
using System.Collections.Generic;
using RRModels;

namespace RRBL
{
    public interface IRestaurant
    {
        Restaurant AddRestaurant(Restaurant p_rest);
        Restaurant DeleteRestaurant(Restaurant p_rest);
        List<Restaurant> GetAllRestaurant();
        Restaurant GetRestaurant(Restaurant p_rest);
        Restaurant GetRestaurantById(int p_id);
        Restaurant UpdateRestaurant(Restaurant p_rest);
    } 
}
