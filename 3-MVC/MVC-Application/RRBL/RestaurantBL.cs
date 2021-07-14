using System;
using System.Collections.Generic;
using RRDL;
using RRModels;

namespace RRBL
{
    public class RestaurantBL : IRestaurant
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
            else
            {
                _repo.AddRestaurant(p_rest);
            }
            return p_rest;
        }

        public Restaurant DeleteRestaurant(Restaurant p_rest)
        {
            Restaurant rest = _repo.GetRestaurant(p_rest);
            if (rest == null)
            {
                throw new Exception("Restaurant doesn't exists!");
            }
            else
            {
                _repo.DeleteRestaurant(rest);
            }
            return p_rest;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return _repo.GetAllRestaurant();
        }

        public Restaurant GetRestaurant(Restaurant p_rest)
        {
            Restaurant found = _repo.GetRestaurant(p_rest);

            if(found == null)
                throw new Exception("Restaurant was not found");

            return found;
        }

        public Restaurant GetRestaurantById(int p_id)
        {
            Restaurant found = _repo.GetRestaurantById(p_id);
            
            if(found == null)
                throw new Exception("Restaurant was not found");

            return found;
        }

        public Restaurant UpdateRestaurant(Restaurant p_rest)
        {
            Restaurant found = _repo.GetRestaurantById(p_rest.Id);

            if (found == null)
            {
                throw new Exception("Restaurant was not found");
            }
            else
            {
                _repo.UpdateRestaurant(p_rest);
            }
            return p_rest;
        }
    }
}