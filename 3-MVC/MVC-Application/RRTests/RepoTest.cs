using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RRDL;
using RRModels;
using Xunit;

namespace RRTests
{
    public class RepoTest
    {
        //Unit testing in DB needs Microsoft.EntityFrameworkCore.Sqlite package
        //Sqlite has features that allows us to create an inmemory rdb (relational database) to test our DB

        //readonly non-access modifier indicates that the fields are read only and can't set anything once initialized
        private readonly DbContextOptions<RestaurantDBContext> options;

        //Constructor runs before each test
        public RepoTest()
        {
            //Gets the configurations for the inmemory rdb we have created
            options = new DbContextOptionsBuilder<RestaurantDBContext>().UseSqlite("Filename = Test.db").Options;
            Seed();
        }

        //Will check if GetAllRestaurant() method will return all the restaurant
        [Fact]
        public void GetAllRestaurantShouldReturnAllRestaurants()
        {
            using (var context = new RestaurantDBContext(options))
            {
                //Arrange
                IRepository _repo = new RestaurantRepository(context);

                //Act
                var test = _repo.GetAllRestaurant();

                //Assert
                Assert.Equal(2, test.Count);
            }
        }

        [Fact]
        public void AddRestaurantShouldAddRestaurant()
        {
            using (var context = new RestaurantDBContext(options))
            {
                //Arrange
                IRepository _repo = new RestaurantRepository(context);

                //Act
                var test = _repo.AddRestaurant
                (
                    new Restaurant
                    {
                        Name = "Whataburger",
                        City = "Houston",
                        State = "Texas"
                    }
                );
            }

            //Assert
            using (var context = new RestaurantDBContext(options))
            {
                //Gets the restaurant we just added (It should have id = 3 because we only had 2 restaurant)
                var result = context.Restaurants.FirstOrDefault(rest => rest.Id == 3);

                Assert.NotNull(result); //Checks it isn't null (which it shouldn't)
                Assert.Equal("Whataburger", result.Name); //Checks if city is houston
                Assert.Equal("Houston", result.City);
            }
            
        }

        private void Seed()
        {
            //using (with resource) will automatically close that resource after the using block
            using (var context = new RestaurantDBContext(options))
            {
                //We want to make sure that our inmemory rdb gets deleted and created each tests
                //We want a pristine database each test to make sure the other unit test didn't contaminate it (kinda like in biology)
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Restaurants.AddRange
                (
                    new Restaurant
                    {
                        Id = 1,
                        Name = "Kura sushi",
                        City = "Dallas",
                        State = "Texas",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Id = 1,
                                Rating = 3,
                                Description = "It was good"
                            },
                            new Review
                            {
                                Id = 2,
                                Rating = 4,
                                Description = "It was very good"
                            }
                        }
                    },
                    new Restaurant
                    {
                        Id = 2,
                        Name = "Olive Garden",
                        City = "Dallas",
                        State = "Texas",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Id = 3,
                                Rating = 2,
                                Description = "Pasta burnt"
                            },
                            new Review
                            {
                                Id = 4,
                                Rating = 1,
                                Description = "Sound burnt"
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}