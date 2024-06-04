using Microsoft.EntityFrameworkCore;
using CarPhotoAPI.Models;

namespace CarPhotoAPI.Data
{
    public class CarPhotoContext : DbContext
    {
        public CarPhotoContext(DbContextOptions<CarPhotoContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Photo>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Photo)
                .WithMany()
                .HasForeignKey(c => c.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
