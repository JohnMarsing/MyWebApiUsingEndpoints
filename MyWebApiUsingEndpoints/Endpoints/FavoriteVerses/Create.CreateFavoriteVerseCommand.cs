using System.ComponentModel.DataAnnotations;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class CreateFavoriteVerseCommand
{
  //[Required]
  //public string Name { get; set; } = null!;
  //[Required]
  //public string PluralsightUrl { get; set; } = null!;
  //public string? TwitterAlias { get; set; }

	[Required]
	public string VerseName { get; set; } = null!;

	[Required]
	public string VerseNameAbrv { get; set; } = null!;

	[Required]
	public int ScriptureIdBeg { get; set; }

	[Required]
	public int ScriptureIdEnd { get; set; }

	[Required]
	public byte BookID { get; set; }

	public string? Commentary { get; set; }

}
