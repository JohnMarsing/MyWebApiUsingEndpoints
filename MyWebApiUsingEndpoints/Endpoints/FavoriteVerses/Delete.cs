using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class Delete : EndpointBaseAsync
    .WithRequest<DeleteFavoriteVerseRequest>
    .WithActionResult
{
  private readonly IAsyncRepository<FavoriteVerse> _repository;

  public Delete(IAsyncRepository<FavoriteVerse> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Deletes an FavoriteVerse
  /// </summary>
  [HttpDelete("api/[namespace]/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteFavoriteVerseRequest request, CancellationToken cancellationToken)
  {
    var favVerse = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (favVerse is null)
    {
      return NotFound(request.Id);
    }

    await _repository.DeleteAsync(favVerse, cancellationToken);

    // see https://restfulapi.net/http-methods/#delete
    return NoContent();
  }
}
