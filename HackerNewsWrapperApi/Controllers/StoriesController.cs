using HackerNewsWrapperApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoriesController : ControllerBase
{
    private readonly IHackerHttpService _hackerHttpService;

    public StoriesController(IHackerHttpService hackerHttpService)
    {
        _hackerHttpService = hackerHttpService;
    }

    [HttpGet("best-stories")]
    public async Task<ActionResult<List<int>>> BestStoriesAsync(int storiesCount)
    {
        var bestIds = await _hackerHttpService.CacheIdAsync();
        return Ok(bestIds);
    }
    


}