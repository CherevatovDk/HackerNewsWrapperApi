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
   
    
    

    public StoriesController(IHackerHttpService hackreHttpService)
    {
        
        _hackreHttpService = hackreHttpService;
        

    }
   
    
    [HttpGet("best-stories")]
    public async Task<ActionResult<IEnumerable<StoryDto>>> BestStoriesAsync(int storiesCount)
    {
        
        return Ok(await _hackreHttpService.GetStorie());
    }
}