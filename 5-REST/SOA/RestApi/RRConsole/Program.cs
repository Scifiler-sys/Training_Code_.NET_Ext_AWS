using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RRBL;
using RRDL;
using RRModels;

namespace RRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gets the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsetting.json")
                    .Build();

            //Setting up my DB connection
            string connectionString = configuration.GetConnectionString("Reference2DB");

            DbContextOptions<RestaurantDBContext> options = new DbContextOptionsBuilder<RestaurantDBContext>()
            .UseNpgsql(connectionString)
            .Options;

            var context = new RestaurantDBContext(options);

            IRestaurant _repo = new RestaurantBL(new RestaurantRepository(context));

            Restaurant exmp1 = new Restaurant(4,"Stephen's Rest 10", "Houston", "Texas");

            // _repo.AddRestaurant(exmp1);

            // _repo.DeleteRestaurant(exmp1);

            // foreach (Restaurant rest in _repo.GetAllRestaurant())
            // {
            //     Console.WriteLine(rest);
            // }

            // Console.WriteLine(_repo.GetRestaurant(exmp1));

            // Console.WriteLine(_repo.GetRestaurantById(exmp1.Id));

            // exmp1.Name = "Stephen's Rest 10";
            // _repo.UpdateRestaurant(exmp1); //Update needs the id (Obviously since you are changing the values)

            IReview _repoRev = new ReviewBL(new RestaurantRepository(context));
            Review rev = new Review(2, "Bad");
            
            // _repoRev.AddReview(exmp1, rev);

            // Console.WriteLine("Average Rating: "+_repoRev.GetReviews(exmp1).Item2);
            // _repoRev.GetReviews(exmp1).Item1.ForEach( rev => Console.WriteLine(rev));
        }
    }
}
