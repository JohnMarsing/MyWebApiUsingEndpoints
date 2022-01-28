using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.DataAccess;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<FavoriteVerse> FavoriteVerses { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
  }
}
