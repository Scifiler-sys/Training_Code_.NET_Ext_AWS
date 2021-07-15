using Microsoft.EntityFrameworkCore;
using RRModels;

namespace RRDL
{
    public class RRDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants {get; set;}
        
        public DbSet<Review> Reviews { get; set; }
        public RRDBContext(): base()
        { }

        public RRDBContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {

        }
    }
}