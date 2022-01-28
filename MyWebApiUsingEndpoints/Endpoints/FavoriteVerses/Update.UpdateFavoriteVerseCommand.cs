using System.ComponentModel.DataAnnotations;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class UpdateFavoriteVerseCommand
{
  [Required]
  public int Id { get; set; }
  [Required]
  public string Name { get; set; } = null!;
}
