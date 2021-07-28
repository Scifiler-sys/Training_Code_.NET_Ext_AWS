using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RRModels;

namespace RRBL
{
    public interface IRestaurant
    {
        Restaurant AddRestaurant(Restaurant p_rest);
        Task<Restaurant> AddRestaurantAsync(Restaurant p_rest);
        Restaurant DeleteRestaurant(Restaurant p_rest);
        List<Restaurant> GetAllRestaurant();
        Task<List<Restaurant>> GetAllRestaurantAsync();
        Restaurant GetRestaurant(Restaurant p_rest);
        Restaurant GetRestaurantById(int p_id);
        Restaurant UpdateRestaurant(Restaurant p_rest);
    } 
}
