namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class UpdatedFavoriteVerseResult
{
  public string Id { get; set; } = null!;
	//public string Name { get; set; } = null!;
	//public string PluralsightUrl { get; set; } = null!;
	//public string? TwitterAlias { get; set; }
	public string VerseName { get; set; } = null!;
	public string VerseNameAbrv { get; set; } = null!;
	public int ScriptureIdBeg { get; set; }
	public int ScriptureIdEnd { get; set; }
	public byte BookID { get; set; }
	public string? Commentary { get; set; } = null!;
}
