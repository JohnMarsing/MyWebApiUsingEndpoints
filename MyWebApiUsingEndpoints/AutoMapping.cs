using AutoMapper;
using MyWebApiUsingEndpoints.DomainModel;
using MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

namespace MyWebApiUsingEndpoints;

public class AutoMapping : Profile
{
	public AutoMapping()
	{
		CreateMap<CreateFavoriteVerseCommand, FavoriteVerse>();
		CreateMap<UpdateFavoriteVerseCommand, FavoriteVerse>();

		CreateMap<FavoriteVerse, CreateFavoriteVerseResult>();
		CreateMap<FavoriteVerse, UpdatedFavoriteVerseResult>();
		CreateMap<FavoriteVerse, FavoriteVerseListResult>();
		CreateMap<FavoriteVerse, FavoriteVerseResult>();
	}
}

