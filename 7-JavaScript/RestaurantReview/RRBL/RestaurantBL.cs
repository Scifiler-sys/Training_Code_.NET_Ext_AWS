using RRDL;
using RRModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<Restaurant> AddRestaurantAsync(Restaurant p_rest)
        {
            if (await _repo.GetRestaurantAsync(p_rest) != null)
            {
                throw new Exception("Restaurant already exists!");
            }

            return await _repo.AddRestaurantAsync(p_rest);
        }

        public async Task<Restaurant> DeleteRestaurantAsync(Restaurant p_rest)
        {
            if (await _repo.GetRestaurantAsync(p_rest) == null)
            {
                throw new Exception("Restaurant does not exist");
            }

            return await _repo.DeleteRestaurantAsync(p_rest);
        }

        public async Task<List<Restaurant>> GetAllRestaurantAsync()
        {
            //In this case, we have no BL logic to getting all restaurant so we will just return the list as is
            return await _repo.GetAllRestaurantAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(Restaurant p_rest)
        {
            Restaurant found = await _repo.GetRestaurantAsync(p_rest);

            if (found == null)
            {
                throw new Exception("Restaurant is not found");
            }

            return found;
        }

        public async Task<Restaurant> GetRestaurantAsync(int p_id)
        {
            Restaurant found = await _repo.GetRestaurantAsync(p_id);

            if (found == null)
            {
                throw new Exception("Restaurant is not found");
            }

            return found;
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant p_rest)
        {
            await _repo.UpdateRestaurantAsync(p_rest);
            return p_rest;
        }
    }
}
