using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoriesController
{
    private readonly IHackerHttpService _hackerHttpService;

    public StoriesController(IHackerHttpService hackerHttpService)
    {
        _hackerHttpService = hackerHttpService;
    }

    [HttpGet("best-stories")]
    public async Task<ActionResult<List<StoryDto>>> BestStoriesAsync(int count)
    {
        var bestIds = await _hackerHttpService.SortingStoryAsync(count);
        return bestIds;
    }
}