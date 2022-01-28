using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class Update : EndpointBaseAsync
    .WithRequest<UpdateFavoriteVerseCommand>
    .WithActionResult<UpdatedFavoriteVerseResult>
{
  private readonly IAsyncRepository<FavoriteVerse> _repository;
  private readonly IMapper _mapper;

  public Update(IAsyncRepository<FavoriteVerse> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing FavoriteVerse
  /// </summary>
  [HttpPut("api/[namespace]")]
  public override async Task<ActionResult<UpdatedFavoriteVerseResult>> HandleAsync([FromBody] UpdateFavoriteVerseCommand request, CancellationToken cancellationToken)
  {
    var favVerse = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (favVerse is null) return NotFound();

    _mapper.Map(request, favVerse);
    await _repository.UpdateAsync(favVerse, cancellationToken);

    var result = _mapper.Map<UpdatedFavoriteVerseResult>(favVerse);
    return result;
  }
}
