using Microsoft.EntityFrameworkCore;

using LibraryApp.Models;

namespace LibraryApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Inventory> Inventory { get; set; }
        
        public DbSet<User> User { get; set; }
        
        public DbSet<Reservation> Reservation { get; set; }
        
        public DbSet<Transaction> Transaction { get; set; }
        
        public DbSet<GuestMessage> GuestMessage { get; set; }
        
        public DbSet<Return> Return { get; set; }
        
        // populate the database with some initial data for user and inventory
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = -1, // Use a negative Id
                    Username = "admin",
                    Password = "admin",
                    Email = "admin@admin.com",
                    Name = "Admin",
                    Contact = "1234567890",
                    Active = true
                });

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = -1, // Use a negative Id
                    Name = "The Great Gatsby",
                    Type = "Book",
                    Status = "Available",
                    ISBN = "9780743273565",
                    Author = "F. Scott Fitzgerald"
                },
                new Inventory
                {
                    Id = -2, // Use a negative Id
                    Name = "To Kill a Mockingbird",
                    Type = "Book",
                    Status = "Available",
                    ISBN = "9780061120084",
                    Author = "Harper Lee"
                },
                new Inventory
                {
                    Id = -3, // Use a negative Id
                    Name = "1984",
                    Type = "Book",
                    Status = "Available",
                    ISBN = "9780451524935",
                    Author = "George Orwell"
                },
                new Inventory
                {
                    Id = -4, // Use a negative Id
                    Name = "Pride and Prejudice",
                    Type = "Book",
                    Status = "Available",
                    ISBN = "9780141439518",
                    Author = "Jane Austen"
                },
                new Inventory
                {
                    Id = -5, // Use a negative Id
                    Name = "Moby Dick",
                    Type = "Book",
                    Status = "Available",
                    ISBN = "9781503280786",
                    Author = "Herman Melville"
                }
            );
        }

    }
}
