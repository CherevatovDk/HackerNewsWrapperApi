using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoriesController : ControllerBase
{
    private readonly IDetailsService _detailsService;

    public StoriesController(IDetailsService detailsService)
    {
        _detailsService = detailsService;
    }

    [HttpGet("best-stories")]
    public async Task<ActionResult<StoryDto>> BestStoriesAsync(int count)
    {
        var getDetails = await _detailsService.GetSortedStoryAsync(count);
        return Ok(getDetails);
    }
    
}