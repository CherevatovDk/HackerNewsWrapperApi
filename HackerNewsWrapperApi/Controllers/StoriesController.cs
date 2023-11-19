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
    public async Task<ActionResult<StoryDto>> BestStoriesAsync(int count, [FromQuery] int page)
    {
        int pageSize = 4;
        var getDetails = await _detailsService.GetSortedStoryAsync(count);
        var query = getDetails.AsQueryable();
        var totalCount = query.Count();
        var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        PageViewModel pageViewModel = new PageViewModel(totalCount, page, pageSize);
        IndexViewModel viewModel = new IndexViewModel(pageViewModel, items);
        return Ok(viewModel);
    }
}