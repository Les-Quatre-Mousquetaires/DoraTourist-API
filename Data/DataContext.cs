using DoraTourist.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoraTourist.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options) {}
        public DbSet<User> Users { get; set; }  
        public DbSet<Hotel> Hotels{ get; set; }
        public DbSet<Review> Reviews{ get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Review>()
            // .HasKey(k => new {k.Id, k.SenderId, k.RecipientId});

            modelBuilder.Entity<Review>()
            .HasOne( u => u.Sender)
            .WithMany( r => r.ReviewsSent )
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
            .HasOne(h => h.Recipient)
            .WithMany( r => r.ReviewsReceived)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}