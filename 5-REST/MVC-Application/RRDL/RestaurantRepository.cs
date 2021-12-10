using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RRModels;

namespace RRDL
{
    public class RestaurantRepository : IRepository
    {
        private RestaurantDBContext _context;
        public RestaurantRepository(RestaurantDBContext context)
        {
            _context = context;
        }
        public Restaurant AddRestaurant(Restaurant p_rest)
        {
            _context.Restaurants.Add(p_rest);
            _context.SaveChanges();

            return p_rest;
        }

        public Review AddReview(Restaurant p_rest, Review p_rev)
        {
            p_rev.RestaurantId = p_rest.Id;
            _context.Reviews.Add(p_rev);
            _context.SaveChanges();
            return p_rev;
        }

        public Restaurant DeleteRestaurant(Restaurant p_rest)
        {
            _context.Restaurants.Remove(p_rest);
            _context.SaveChanges();
            return p_rest;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return _context.Restaurants.ToList<Restaurant>();
        }

        public Restaurant GetRestaurant(Restaurant p_rest)
        {
            Restaurant found = _context.Restaurants
                                    .AsNoTracking() //Removes the entity id is being tracked error
                                    .FirstOrDefault(rest => rest.Name == p_rest.Name
                                                    && rest.City == p_rest.City
                                                    && rest.State == p_rest.State);

            if(found == null)
                return null;

            return found;
        }

        public Restaurant GetRestaurantById(int p_id)
        {
            return _context.Restaurants.AsNoTracking().FirstOrDefault(rest => rest.Id == p_id);
        }

        public List<Review> GetReviews(Restaurant p_rest)
        {
            return _context.Reviews.Where(
                rev => rev.RestaurantId == GetRestaurantById(p_rest.Id).Id
            ).Select(
                review => review
            ).ToList();
        }

        public Restaurant UpdateRestaurant(Restaurant p_rest)
        {
            _context.Restaurants.Update(p_rest);
            _context.SaveChanges();
            return p_rest;
        }
    }
}