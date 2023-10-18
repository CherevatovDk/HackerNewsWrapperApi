using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
namespace HackerNewsWrapperApi.Services;

public class DetailsService : IDetailsHttpService
{
    private readonly HackerHttpService _hackerHttpService;

    public DetailsService(HackerHttpService hackerHttpService)
    {
        _hackerHttpService = hackerHttpService;
    }

    public async Task<List<StoryDto>> GetStoryDetailsAsync()
    {
        var ids = await _hackerHttpService.StoryIdsAsync();
        var details = new List<StoryDto>();
        var tasks = ids.Select(item => _hackerHttpService.DetailsStoryAsync(item));
        var results = await Task.WhenAll(tasks);
        details.AddRange(results);
        return details;
    }
}