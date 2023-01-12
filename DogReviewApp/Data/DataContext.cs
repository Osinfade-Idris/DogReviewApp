using DogReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DogReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogOwner> DogOwners { get; set; }
        public DbSet<DogCategory> DogCategories { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DogCategory>()
                .HasKey(dc => new { dc.DogId, dc.CategoryId });
            modelBuilder.Entity<DogCategory>()
                .HasOne(d => d.Dog)
                .WithMany(dc => dc.DogCategories)
                .HasForeignKey(d => d.DogId);
            modelBuilder.Entity<DogCategory>()
                .HasOne(d => d.Category)
                .WithMany(dc => dc.DogCategories)
                .HasForeignKey(c => c.CategoryId);


            modelBuilder.Entity<DogOwner>()
                .HasKey(dow => new { dow.DogId, dow.OwnerId });
            modelBuilder.Entity<DogOwner>()
                .HasOne(d => d.Dog)
                .WithMany(dc => dc.DogOwners)
                .HasForeignKey(d => d.DogId);
            modelBuilder.Entity<DogOwner>()
                .HasOne(d => d.Owner)
                .WithMany(dc => dc.DogOwners)
                .HasForeignKey(c => c.OwnerId);
        }





    }
}
