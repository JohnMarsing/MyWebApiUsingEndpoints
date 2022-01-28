namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class FavoriteVerseListResult
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? TwitterAlias { get; set; }
}
