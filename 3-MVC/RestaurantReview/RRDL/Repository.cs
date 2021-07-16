using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RRModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RRDL
{
    public class Repository : IRepository
    {
        private RRDBContext _context;
        public Repository(RRDBContext p_context)
        {
            _context = p_context;
        }
        public Restaurant AddRestaurant(Restaurant p_rest)
        {
            _context.Restaurants.Add(p_rest);
            _context.SaveChanges();
            return p_rest;
        }

        public Review AddReview(Restaurant p_rest, Review p_rev)
        {
            Restaurant found = GetRestaurant(p_rest);
            p_rev.RestaurantId = found.Id; 

            _context.Reviews.Add(p_rev);
            _context.SaveChanges();

            return p_rev;
        }

        public Restaurant DeleteRestaurant(Restaurant p_rest)
        {
            Restaurant found = GetRestaurant(p_rest);

            _context.Restaurants.Remove(found);
            _context.SaveChanges();

            return p_rest;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            //Method Syntax way
            return _context.Restaurants.Select(rest => rest).ToList();
        }

        public Restaurant GetRestaurant(Restaurant p_rest)
        {
            Restaurant found = _context.Restaurants
                                .AsNoTracking() //Removes the entity id to being tracked (Helps us avoid that tracking error when we start using multiple repository methods in a sequence)
                                .FirstOrDefault(rest => rest.Name == p_rest.Name
                                                && rest.City == p_rest.City
                                                && rest.State == p_rest.State);

            if (found == null)
            {
                //Be careful with this since you might get null exception in your code because you are getting null
                return null;
            }

            return found;
        }

        public Restaurant GetRestaurant(int p_id)
        {
            Restaurant found = _context.Restaurants
                .AsNoTracking()
                .FirstOrDefault(rest => rest.Id == p_id);

            if (found == null)
            {
                return null;
            }

            return found;
        }


        public List<Review> GetReviews(Restaurant p_rest)
        {
            return _context.Reviews.Where( //Filter the list of reviews we will get
                    rev => rev.RestaurantId == GetRestaurant(p_rest).Id
                ).Select( //Select each review from the list after the filtering
                    rev => rev
                ).ToList(); //Convert it to a List collection
        }

        public Restaurant UpdateRestaurant(Restaurant p_rest)
        {
            _context.Restaurants.Update(p_rest);
            _context.SaveChanges();
            return p_rest;
        }
    }
}