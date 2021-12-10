using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RRModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RRDL
{
    public class Repository : IRepository
    {
        private RRDBContext _context;
        public Repository(RRDBContext p_context)
        {
            _context = p_context;
        }
        public async Task<Restaurant> AddRestaurantAsync(Restaurant p_rest)
        {
            await _context.Restaurants.AddAsync(p_rest);
            await _context.SaveChangesAsync();
            return p_rest;
        }

        public async Task<Review> AddReviewAsync(Restaurant p_rest, Review p_rev)
        {
            Restaurant found = await GetRestaurantAsync(p_rest);
            p_rev.RestaurantId = found.Id; 

            await _context.Reviews.AddAsync(p_rev);
            await _context.SaveChangesAsync();

            return p_rev;
        }

        public async Task<Restaurant> DeleteRestaurantAsync(Restaurant p_rest)
        {
            Restaurant found = await GetRestaurantAsync(p_rest);

            _context.Restaurants.Remove(found);
            await _context.SaveChangesAsync();

            return p_rest;
        }

        public async Task<List<Restaurant>> GetAllRestaurantAsync()
        {
            //Method Syntax way
            return await _context.Restaurants.Select(rest => rest).ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(Restaurant p_rest)
        {
            Restaurant found = await _context.Restaurants
                                .AsNoTracking() //Removes the entity id to being tracked (Helps us avoid that tracking error when we start using multiple repository methods in a sequence)
                                .FirstOrDefaultAsync(rest => rest.Name == p_rest.Name
                                                && rest.City == p_rest.City
                                                && rest.State == p_rest.State);

            if (found == null)
            {
                //Be careful with this since you might get null exception in your code because you are getting null
                return null;
            }

            return found;
        }

        public async Task<Restaurant> GetRestaurantAsync(int p_id)
        {
            Restaurant found = await _context.Restaurants
                .AsNoTracking()
                .FirstOrDefaultAsync(rest => rest.Id == p_id);

            if (found == null)
            {
                return null;
            }

            return found;
        }


        public async Task<List<Review>> GetReviewsAsync(Restaurant p_rest)
        {
            return await _context.Reviews.Where( //Filter the list of reviews we will get
                    rev => rev.RestaurantId == GetRestaurantAsync(p_rest).Id
                ).Select( //Select each review from the list after the filtering
                    rev => rev
                ).ToListAsync(); //Convert it to a List collection
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant p_rest)
        {
            _context.Restaurants.Update(p_rest);
            await _context.SaveChangesAsync();
            return p_rest;
        }
    }
}