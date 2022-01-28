using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.DataAccess;

public static class SeedData
{
	public static List<FavoriteVerse> FavoriteVerses()
	{
		int id = 1;

		var FavoriteVerses = new List<FavoriteVerse>()
						{
								new FavoriteVerse
								{
										Id = id++,
										VerseName = "Genesis 1:1",
										VerseNameAbrv = "Gen 1:1",
										ScriptureIdBeg = 1,
										ScriptureIdEnd = 2,
										BookID = 1,
										Commentary = "All remaining verses are commentary"
								},
								new FavoriteVerse
								{
										Id = id++,
										VerseName = "Genesis 12:1-2",
										VerseNameAbrv = "Gen 12:1-2",
										ScriptureIdBeg = 373,
										ScriptureIdEnd = 378,
										BookID = 1,
										Commentary = "the ricochet blessings"
								}
						};

		return FavoriteVerses;
	}

	public static void PopulateTestData(AppDbContext dbContext)
	{
		dbContext.FavoriteVerses.AddRange(FavoriteVerses());

		dbContext.SaveChanges();
	}
}
