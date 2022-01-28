using System.Text.Json;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MyWebApiUsingEndpoints.DomainModel;

namespace MyWebApiUsingEndpoints.Endpoints.FavoriteVerses;

public class ListJsonFile : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
  private readonly IAsyncRepository<FavoriteVerse> repository;

  public ListJsonFile(IAsyncRepository<FavoriteVerse> repository)
  {
    this.repository = repository;
  }

  /// <summary>
  /// List all FavoriteVerse as a JSON file
  /// </summary>
  [HttpGet("api/[namespace]/Json")]
  public override async Task<ActionResult> HandleAsync(
      CancellationToken cancellationToken = default)
  {
    var result = (await repository.ListAllAsync(cancellationToken)).ToList();

    var streamData = JsonSerializer.SerializeToUtf8Bytes(result);
    return File(streamData, "text/json", "favoriteverses.json");
  }
}
