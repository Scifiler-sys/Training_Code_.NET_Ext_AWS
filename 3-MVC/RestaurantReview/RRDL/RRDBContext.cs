using Microsoft.EntityFrameworkCore;
using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRDL
{
    public class RRDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public RRDBContext() : base()
        { }

        public RRDBContext(DbContextOptions options) : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder p_options)
        //{
        //    p_options.UseSqlServer(@"Server=tcp:210628-stephen-pagdilao.database.windows.net,1433;Initial Catalog=DemoDb;Persist Security Info=False;User ID=admin123;Password=Pagdilao123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}

            
        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            //It will auto generate the ID column for both tables
            p_modelBuilder.Entity<Restaurant>()
                .Property(rest => rest.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Review>()
                .Property(rev => rev.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
