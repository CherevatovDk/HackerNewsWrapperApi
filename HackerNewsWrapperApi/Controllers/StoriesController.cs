using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
    private readonly IHackerHttpService _hackerHttpService;

    public StoriesController(IHackerHttpService hackreHttpService)
    {

        _hackerHttpService = hackreHttpService;
    }

    [HttpGet("best-stories")]
    public async Task<ActionResult<IEnumerable<StoryDto>>> BestStoriesAsync(int storiesCount)
    {

        return Ok(await _hackerHttpService.GetStorie(storiesCount));
    }
}