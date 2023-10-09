using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoriesController:ControllerBase
{
    private readonly IHackerHttpService _hackerHttpService;

    public StoriesController(IHackerHttpService hackerHttpService)
    {
        _hackerHttpService = hackerHttpService;
    }

    [HttpGet("best-stories")]
    public async Task<ActionResult<List<StoryDto>>> BestStoriesAsync(int count)
    {
        return  Ok(await _hackerHttpService.GetStoryIdsAsync());
    }
}