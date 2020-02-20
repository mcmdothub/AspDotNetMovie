using AspDotNetMovie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetMovie.DbContexts
{
    public class AspDotNetMovieDbContext : DbContext
    {
        public AspDotNetMovieDbContext(DbContextOptions<AspDotNetMovieDbContext> options) : base(options)
        {

        }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rated> Rateds { get; set; }

        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
                // .HasData is going to allow us to add some default or seeded data to our model and it does it by embedding it into the migration
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<OrderItem>()
               .Property(p => p.UnitPrice)
               .HasColumnType("decimal(18,2)");
            // open command:"dotnet ef migrations add SeedDate"

        }





    }
}
