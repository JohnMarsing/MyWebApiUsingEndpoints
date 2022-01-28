using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class Create : EndpointBaseAsync
    .WithRequest<CreateFavoriteVerseCommand>
    .WithActionResult
{
  private readonly IAsyncRepository<FavoriteVerse> _repository;
  private readonly IMapper _mapper;

  public Create(IAsyncRepository<FavoriteVerse> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Creates a new FavoriteVerse
  /// </summary>
  [HttpPost("api/[namespace]")]
  public override async Task<ActionResult> HandleAsync([FromBody] CreateFavoriteVerseCommand request, CancellationToken cancellationToken)
  {
    var favVerse = new FavoriteVerse();
    _mapper.Map(request, favVerse);
    await _repository.AddAsync(favVerse, cancellationToken);

    var result = _mapper.Map<CreateFavoriteVerseResult>(favVerse);
    return CreatedAtRoute("FavoriteVerses_Get", new { id = result.Id }, result);
  }
}
