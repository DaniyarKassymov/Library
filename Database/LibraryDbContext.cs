using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Database;

public class LibraryDbContext : DbContext
{
    public DbSet<Book>? Books { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<User>? Users { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Books)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);
        
        base.OnModelCreating(modelBuilder);
    }
}