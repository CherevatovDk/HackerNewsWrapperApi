using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoriesController : ControllerBase
{
    private readonly IDetailsHttpService _detailsHttpService;

    public StoriesController(IDetailsHttpService detailsHttpService)
    {
        _detailsHttpService = detailsHttpService;
    }

    [HttpGet("best-stories")]
    public async Task<ActionResult<StoryDto>> BestStoriesAsync(int count)
    {
        var getDetails = await _detailsHttpService.GetStoryDetailsAsync();
        return Ok(getDetails);
    }
}