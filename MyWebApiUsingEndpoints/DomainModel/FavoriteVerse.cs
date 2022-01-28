namespace MyWebApiUsingEndpoints.DomainModel;

public class FavoriteVerse : BaseEntity
{
	public string VerseName { get; set; } = null!;  //Genesis 12:1-2
	public string VerseNameAbrv { get; set; } = null!;  // Gen 1:1, or Exo 20:16-21
	public int ScriptureIdBeg { get; set; }   // 373  https://myhebrewbiblecore.azurewebsites.net/VerseByScriptureIdRange/373/378/Genesis%2015%3A12-17
	public int ScriptureIdEnd { get; set; }   // /378
	public byte BookID { get; set; } // Gen-1, Used to put ScrollSpies into buckets
	public string? Commentary { get; set; }  // This is the "ricochet" blessings
}

