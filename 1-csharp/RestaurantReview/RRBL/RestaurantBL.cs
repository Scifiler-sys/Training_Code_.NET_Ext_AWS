using RRDL;
using RRModels;
using System;
using System.Collections.Generic;

namespace RRBL
{
    public class RestaurantBL : IRestaurantBL
    {
        private IRepository _repo;

        public RestaurantBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Restaurant AddRestaurant(Restaurant p_rest)
        {
            if (_repo.GetRestaurant(p_rest) != null)
            {
                throw new Exception("Restaurant already exists!");
            }
            return _repo.AddRestaurant(p_rest);
        }

        public List<Restaurant> GetAllRestaurant()
        {
            //In this case, we have no BL logic to getting all restaurant so we will just return the list as is
            return _repo.GetAllRestaurant();
        }

        public Restaurant GetRestaurant(Restaurant p_rest)
        {
            return _repo.GetRestaurant(p_rest);
        }
    }
}
