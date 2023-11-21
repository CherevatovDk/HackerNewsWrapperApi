using HackerNewsWrapperApi.Filters;
using HackerNewsWrapperApi.Interfaces;
using HackerNewsWrapperApi.Models.Dtos;
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
    public async Task<ActionResult<StoryDto>> BestStoriesAsync(int count, [FromQuery] PaginationFilter filter)
    {
        var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
        var getDetails = await _detailsService.GetSortedStoryAsync(count);
        var query = getDetails.AsQueryable();
        var items = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
        return Ok(items);
    }
}