using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business;

public class DataContext : DbContext
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(new Genre { Id = 1, Name = "Comedy" });
        modelBuilder.Entity<Genre>().HasData(new Genre { Id = 2, Name = "Horror" });
        modelBuilder.Entity<Genre>().HasData(new Genre { Id = 3, Name = "Sci-Fi" });
        modelBuilder.Entity<Genre>().HasData(new Genre { Id = 4, Name = "Action" });
        modelBuilder.Entity<Genre>().HasData(new Genre { Id = 5, Name = "Drama" });
    }
}
