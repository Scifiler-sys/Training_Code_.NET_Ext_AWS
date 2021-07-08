//We use aliasing in using to differentiate between Entities and Models
using Entity = RRDL.Entities;
using Model = RRModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace RRDL
{
    /// <summary>
    /// Implementation details of the IRepository interface
    /// </summary>
    public class Repository : IRepository
    {
        private Entity.SPDBContext _context;

        public Repository(Entity.SPDBContext context)
        {
            _context = context;
        }
        public Model.Restaurant AddRestaurant(Model.Restaurant p_rest)
        {
            //Biggest annoyance to doing DB first approach
            //EF core doesnt' know how to map the properties from the entity restaurant that is auto generated 
            //to the properties from our restaurant model so we have to do it manually
            //If you did code first approach, you don't have to worry about this
            _context.Restaurants.Add(
                new Entity.Restaurant
                {
                    Name = p_rest.Name,
                    City = p_rest.City,
                    State = p_rest.State
                }
            );

            //This method will save the changes we made to the database
            _context.SaveChanges();
            return p_rest;
        }

        public Model.Review AddReview(Model.Restaurant p_rest, Model.Review p_rev)
        {
            _context.Reviews.Add(
                new Entity.Review
                {
                    Rating = p_rev.rating,
                    Desciption = p_rev.Description,
                    RestaurantId = this.GetRestaurant(p_rest).Id
                }
            );
            _context.SaveChanges();

            return p_rev;
        }

        public List<Model.Restaurant> GetAllRestaurant()
        {
            //Query Syntax way
            var result = (from rest in _context.Restaurants
                        select rest).AsNoTracking();

            List<Model.Restaurant> listOfRest = new List<Model.Restaurant>();
            foreach (var item in result)
            {
                //Mapping the item we get from result into Model.Restaurant
                //And we add it to our List
                listOfRest.Add(new Model.Restaurant{
                    Id = item.Id,
                    Name = item.Name,
                    City = item.City,
                    State = item.State
                });
            }

            return listOfRest;

            //Method Syntax way
            //Select will select each entity
            // return _context.Restaurants
            //     .Select(
            //         rest => new Model.Restaurant{ //We mapped the entity to the model version
            //             Id = rest.Id,
            //             Name = rest.Name,
            //             City = rest.City,
            //             State = rest.State
            //         }
            // ).ToList(); //Changed it into a List for it to be returned
        }

        public Model.Restaurant GetRestaurant(Model.Restaurant p_rest)
        {
            //LINQ expressions has a handful of methods for us to utilize (GO RESEARCH IT SINCE IT WILL MAKE YOUR CODING LIFE EASIER)
            //This is an example of a delegate
            //FirstOrDefault allows us to grab one instance from the List given some sort of condition we set
            // return GetAllRestaurant().FirstOrDefault(rest => rest.Equals(p_rest)); //=> gives a lambda operator
            //Create the equals method in the model so it makes more sense what we are comparing

            //Query syntax way
            var found = (from rest in _context.Restaurants
                        where rest.Name == p_rest.Name &&
                            rest.City == p_rest.City &&
                            rest.State == p_rest.State
                        select rest).AsNoTracking().ToList(); //You can add .First method syntax to get the first instance but this is strictly query way 

            if(found.Count == 0)
                return null;

            //We are just getting the first element
            return new Model.Restaurant{
                Id = found[0].Id, 
                Name = found[0].Name,
                City = found[0].City,
                State = found[0].State
            };

            //Method syntax way
            // Entity.Restaurant found = _context.Restaurants.AsNoTracking().FirstOrDefault( rest => 
            //     rest.Name == p_rest.Name &&
            //     rest.City == p_rest.City &&
            //     rest.State == p_rest.State
            // );

            //We added this because if found is null then our next logic will fail
            // if(found == null)
            //     return null;

            // //If found is null then we can't access its properties which will fail our logic below
            // return new Model.Restaurant{
            //     Id = found.Id,
            //     Name = found.Name,
            //     City = found.City,
            //     State = found.State
            // };
        }
    }
}
