using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.DataAccess.Config;

public class FavoriteVerseConfig : IEntityTypeConfiguration<FavoriteVerse>
{
  public void Configure(EntityTypeBuilder<FavoriteVerse> builder)
  {
    builder.Property(e => e.VerseName).IsRequired();
    builder.Property(e => e.VerseNameAbrv).IsRequired();
    builder.Property(e => e.ScriptureIdBeg).IsRequired();
    builder.Property(e => e.ScriptureIdEnd).IsRequired();
    builder.Property(e => e.BookID).IsRequired();
    builder.HasData(SeedData.FavoriteVerses());
  }
}
