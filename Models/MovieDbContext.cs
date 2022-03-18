using Microsoft.EntityFrameworkCore;

namespace MovieCharacterAPI.Models
{
    public class MovieDbContext : DbContext
    {
        //Wrap Movie, Character and Franchise in DB sets 
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Franchise> Franchise { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Next we seed data for all the entities that we have in database
            modelBuilder.Entity<Character>().HasData(SeedData_Helper.NewCharacter());
            modelBuilder.Entity<Franchise>().HasData(SeedData_Helper.NewFranchise());
            modelBuilder.Entity<Movie>().HasData(SeedData_Helper.NewMovie());
            //Seed many to many Movie-Characteres. 
            modelBuilder.Entity<Character>()
                .HasMany(m => m.Movies)
                .WithMany(c => c.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCharacter",
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),

                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { CharacterId = 1, MovieId = 1 },
                            new { CharacterId = 1, MovieId = 2 },
                            new { CharacterId = 1, MovieId = 3 },
                            new { CharacterId = 2, MovieId = 2 },
                            new { CharacterId = 3, MovieId = 2 }

                            );

                    });


        }


    }

}
