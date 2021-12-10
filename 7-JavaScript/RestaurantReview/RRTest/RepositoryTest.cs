using Microsoft.EntityFrameworkCore;
using RRDL;
using RRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RRTest
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<RRDBContext> _options;

        //Constructors in unit test will always run before a test case
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<RRDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }

        [Fact]
        public async void GetAllRestaurantShouldGetAllRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                //Arrange
                IRepository repo = new Repository(context);
                List<Restaurant> restaurants;

                //Act
                restaurants = await repo.GetAllRestaurantAsync();

                //Assert
                Assert.NotNull(restaurants);
                Assert.Equal(2,restaurants.Count);
            }
        }

        [Fact]
        public async void GetRestaurantShouldGetASpecificRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Restaurant tryToFindRest = new Restaurant()
                {
                    Name = "Kura sushi",
                    City = "Houston",
                    State = "Texas"
                };

                Restaurant found = await repo.GetRestaurantAsync(tryToFindRest);

                Assert.NotNull(found);
                Assert.Equal(found.Name, tryToFindRest.Name);
            }
        }

        [Fact]
        public async void GetRestaurantByIdShouldGetASpecificRestaurant()
        {
            using (var context = new RRDBContext(_options))
            {
                IRepository repo = new Repository(context);

                Restaurant found = await repo.GetRestaurantAsync(1);

                Assert.NotNull(found);
                Assert.Equal("Kura sushi", found.Name);
            }
        }

        [Fact]
        public async void UpdateRestaurantShouldChangePropertiesInDB()
        {
            using (var context = new RRDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Restaurant tryUpdate = await repo.GetRestaurantAsync(1);

                tryUpdate.Name = "Kura Sushi The Better Version";
                await repo.UpdateRestaurantAsync(tryUpdate);

                tryUpdate = await repo.GetRestaurantAsync(1);
                Assert.Equal("Kura Sushi The Better Version", tryUpdate.Name);
            }
        }

        private void Seed()
        {
            using (var context = new RRDBContext(_options))
            {
                //We want ot make sure our inmemory database gets deleted everytime before another test case runs it
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Kura sushi",
                        City = "Houston",
                        State = "Texas",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 4.7,
                                Description = "Who doesn't like sushi anyway"
                            }
                        }
                    },
                    new Restaurant
                    {
                        Name = "Pasta place",
                        City = "Venice",
                        State = "Rome",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 3.8,
                                Description = "Pasta was a little burnt"
                            },
                            new Review
                            {
                                Rating = 4.9,
                                Description = "Mama mia"
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
