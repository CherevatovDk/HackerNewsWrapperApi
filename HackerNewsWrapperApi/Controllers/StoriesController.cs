using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using HackerNewsWrapperApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWrapperApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
    private readonly IHackerHttpService _hackreHttpService;
    private readonly ICacheService _cacheService;
    
    

    public StoriesController(IHackerHttpService hackreHttpService, ICacheService cacheService)
    {
        _cacheService = cacheService;
        _hackreHttpService = hackreHttpService;
        

    }
   
    
    [HttpGet("best-stories")]
    public async Task<ActionResult<IEnumerable<StoryDto>>> BestStoriesAsync(int storiesCount)
    {
        await _cacheService.AddInCache();
        return Ok(await _hackreHttpService.GetStorie());
    }
}