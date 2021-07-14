using System;
using System.Collections.Generic;
using RRModels;

namespace RRDL
{
    public interface IRepository
    {
        Restaurant AddRestaurant(Restaurant p_rest);
        Restaurant DeleteRestaurant(Restaurant p_rest);
        List<Restaurant> GetAllRestaurant();
        Restaurant GetRestaurant(Restaurant p_rest);
        Restaurant GetRestaurantById(int p_id);
        Restaurant UpdateRestaurant(Restaurant p_rest);
        Review AddReview(Restaurant p_rest, Review p_rev);
        List<Review> GetReviews(Restaurant p_rest);
    }
}
