using System;
using Microsoft.EntityFrameworkCore;
using RRModels;

namespace RRDL
{
    public class RestaurantDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public RestaurantDBContext() : base()
        { }

        public RestaurantDBContext(DbContextOptions options) : base(options)
        { }

        // protected override void OnConfiguring(DbContextOptionsBuilder p_option)
        //     => p_option.UseNpgsql(@"server = stephen-pagdilao-postgresql.cekyyol8wngg.us-east-2.rds.amazonaws.com;
        //     database = postgres; User ID = postgres;Password = postgres123");  

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            //Create self generating Ids
            p_modelBuilder.Entity<Restaurant>()
                .Property(rest => rest.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Review>()
                .Property(rev => rev.Id)
                .ValueGeneratedOnAdd();
                
            
        }
    }
}