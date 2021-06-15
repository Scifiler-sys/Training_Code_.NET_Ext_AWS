using RRDL;
using RRModels;
using System;
using System.Collections.Generic;

namespace RRBL
{
    public class RestaurantBL : IRestaurantBL
    {
        private IRepository _repo;

        /// <summary>
        /// We are defining the dependencies this class needs in the constructor
        /// We do it this way (with interfaces) because we can easily switch out which implementation we will be using later on
        /// Such as later on, (next week) we will switch out our data storage to instead of file storage, we will connect to a cloud service
        /// </summary>
        /// <param name="p_repo">Passes the repository object from our DLs</param>
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
