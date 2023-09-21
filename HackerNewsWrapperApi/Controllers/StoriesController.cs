using HackerNewsWrapperApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
    [HttpGet("best-stories")]
    public async Task<ActionResult<IEnumerable<StoryDto>>> BestStoriesAsync(int storiesCount)
    {
        return Ok();
    }
}