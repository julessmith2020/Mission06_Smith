using Mission06_Smith.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Smith.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options) 
        {
        }

        public DbSet<MovieForm> Movies { get; set; }
        public DbSet<MovieCategory> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //seed data
        {
            modelBuilder.Entity<MovieCategory>().HasData(
                new MovieCategory { CategoryId = 1, Category = "Miscellaneous" },
                new MovieCategory { CategoryId = 2, Category = "Drama" },
                new MovieCategory { CategoryId = 3, Category = "Television" },
                new MovieCategory { CategoryId = 4, Category = "Horror/Suspense" },
                new MovieCategory { CategoryId = 5, Category = "Comedy" },
                new MovieCategory { CategoryId = 6, Category = "Family" },
                new MovieCategory { CategoryId = 7, Category = "Action/Adventure" },
                new MovieCategory { CategoryId = 8, Category = "VHS" }
                );
        }
    }
}