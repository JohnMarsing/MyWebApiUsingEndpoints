using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class List : EndpointBaseAsync
    .WithRequest<FavoriteVerseListRequest>
    .WithResult<IEnumerable<FavoriteVerseListResult>>
{
  private readonly IAsyncRepository<FavoriteVerse> repository;
  private readonly IMapper mapper;

  public List(
      IAsyncRepository<FavoriteVerse> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all FavoriteVerse
  /// </summary>
  [HttpGet("api/[namespace]")]
  public override async Task<IEnumerable<FavoriteVerseListResult>> HandleAsync(
      [FromQuery] FavoriteVerseListRequest request,
      CancellationToken cancellationToken = default)
  {
    if (request.PerPage == 0)
    {
      request.PerPage = 10;
    }
    if (request.Page == 0)
    {
      request.Page = 1;
    }
    var result = (await repository.ListAllAsync(request.PerPage, request.Page, cancellationToken))
        .Select(i => mapper.Map<FavoriteVerseListResult>(i));

    return result;
  }
}
