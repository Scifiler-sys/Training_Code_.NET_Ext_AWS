xusing Microsoft.EntityFrameworkCore;
using RRDL;
using RRModels;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace RRTests
{
    public class RepoTest
    {
        /*
            Unit testing in DB needs Microsoft.EntityFrameworkCore.Sqlite package
            Sqlite has features that allows us to create inmemory rdb to test our repo

            We will also need Microsoft.EntityFrameworkCore.Design
        */

        //readonly non-access modifier indicates that the fields are read only
        private readonly DbContextOptions<RRDBContext> _options;

        public RepoTest()
        {
            //Gets the configurations for the inmemory rdb we have created
            _options = new DbContextOptionsBuilder<RRDBContext>().UseSqlite("FileName = Test.db").Options;
            Seed();
        }

        [Fact]
        public void GetAllRestaurantShouldReturnAllRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);

                //Act
                var test = repo.GetAllRestaurant();

                //Assert
                Assert.Equal(2, test.Count);
                Assert.Equal("Kura sushi", test[0].Name);
                Assert.Equal("Olive Garden", test[1].Name);
            }
        }

        [Fact]
        public void GetRestaurantShouldReturnRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);

                //Act
                Restaurant rest = repo.GetRestaurant(new Restaurant {
                    Name = "Kura sushi",
                    City = "Dallas",
                    State = "Texas"
                });

                //Assert
                Assert.Equal(1,rest.Id);
            }
        }

        [Fact]
        public void GetRestaurantByIdShouldReturnRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);

                //Act
                Restaurant rest = repo.GetRestaurant(1);

                //Assert
                Assert.Equal("Kura sushi", rest.Name);
            }
        }

        [Fact]
        public void AddRestaurantShouldAddRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);

                //Act
                var test = repo.AddRestaurant(
                    new Restaurant
                    {
                        Name = "Whataburger",
                        City = "Houston",
                        State = "Texas"
                    }
                );
            }

            //Assert
            using (var context = new RRDBContext(_options))
            {
                //Gets the restaurant we jsut added (It should be id = 3)
                //What method of linq syntax I used here?
                var result = context.Restaurants.FirstOrDefault(rest => rest.Id == 3);

                Assert.NotNull(result); //Checks it isn't null
                Assert.Equal("Whataburger", result.Name); //Checks if Name is Whataburger
                Assert.Equal("Houston", result.City);
            }
        }

        [Fact]
        public void GetReviewShouldGetallReviewFromRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Restaurant rest = repo.GetRestaurant(new Restaurant
                {
                    Name = "Kura sushi",
                    City = "Dallas",
                    State = "Texas"
                });

                List<Review> reviews = repo.GetReviews(rest);

                Assert.Single(reviews);
            }
        }

        [Fact]
        public void AddReviewShouldAddReviewToRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                Review rev = new Review
                {
                    Rating = 5,
                    Description = "Godlike food"
                };

                //Act
                Restaurant rest = repo.GetRestaurant(new Restaurant {
                    Name = "Kura sushi",
                    City = "Dallas",
                    State = "Texas"
                });

                repo.AddReview(rest, rev);
            }

            //Assert
            using (var context = new RRDBContext(_options))
            {
                IRepository repo = new Repository(context);

                Restaurant rest = repo.GetRestaurant(new Restaurant{
                    Name = "Kura sushi",
                    City = "Dallas",
                    State = "Texas"
                });

                List<Review> reviews = repo.GetReviews(rest);

                Assert.NotNull(reviews);
                Assert.Equal(2, reviews.Count);
            }
        }

        [Fact]
        public void UpdateRestaurantShouldChangeRestaurantColumnValues()
        {
            using (var context = new RRDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Restaurant found = repo.GetRestaurant(1);

                found.Name = "Kura Sushi Even Better";
                repo.UpdateRestaurant(found);

                found = repo.GetRestaurant(1);
                Assert.Equal("Kura Sushi Even Better", found.Name);
            }
        }

        [Fact]
        public void DeleteRestaurantShouldDeleteRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Restaurant found = repo.GetRestaurant(1);

                repo.DeleteRestaurant(found);

                found = repo.GetRestaurant(1);

                Assert.Null(found);

            }
        }
        
        //Seeding our inmemory rdb
        private void Seed()
        {
            //using (with resource) will automatically close that resource after the using block
            using(var context = new RRDBContext(_options))
            {
                //We want to make sure that our inmemory rdb gets deleted and created each tests
                //Why? to make sure we have a pristine database each test and previous test didn't contaminate our sample
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Kura sushi",
                        City = "Dallas",
                        State = "Texas",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 3,
                                Description = "It was good"
                            }
                        }
                    },

                    new Restaurant
                    {
                        Name = "Olive Garden",
                        City = "Dallas",
                        State = "Texas",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 2,
                                Description = "Pasta was burnt"
                            },
                            new Review
                            {
                                Rating = 1,
                                Description = "Even burnt my fork"
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}