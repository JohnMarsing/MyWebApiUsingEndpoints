using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class Get : EndpointBaseAsync
      .WithRequest<int>
      .WithActionResult<FavoriteVerseResult>
{
  private readonly IAsyncRepository<FavoriteVerse> _repository;
  private readonly IMapper _mapper;

  public Get(IAsyncRepository<FavoriteVerse> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Get a specific FavoriteVerse
  /// </summary>
  [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
  public override async Task<ActionResult<FavoriteVerseResult>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var favVerse = await _repository.GetByIdAsync(id, cancellationToken);

    if (favVerse is null) return NotFound();

    var result = _mapper.Map<FavoriteVerseResult>(favVerse);

    return result;
  }
}
