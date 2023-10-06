using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interface;
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
    public async Task<ActionResult<IOrderedEnumerable<StoryDto>>> GetAll(int storiesCount)
    {
        var bestIds = await _hackerHttpService.GetAll(storiesCount);
        if (!bestIds.Any())
        {
            NotFound();
        }

        return Ok(bestIds);
    }
}
    
