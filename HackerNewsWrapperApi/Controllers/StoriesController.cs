using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoriesController : ControllerBase
{
    [HttpGet("best-stories")]
    public async Task<ActionResult<IEnumerable<object>>> BestStoriesAsync(int storiesCount)
    {
        return Ok();
    }
}