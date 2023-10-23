using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using HackerNewsWrapperApi.Options;

namespace HackerNewsWrapperApi.Services;

public class DetailsService : IDetailsService
{
    private readonly HackerHttpService _hackerHttpService;

    public DetailsService(HackerHttpService hackerHttpService)
    {
        _hackerHttpService = hackerHttpService;
    }

    public async Task<List<StoryDto>> GetStoryDetailsAsync()
    {
        var result = new List<StoryDto>();
        var ids = await _hackerHttpService.StoryIdsAsync();
        foreach (var item in ids)
        {
            var s = await _hackerHttpService.DetailsStoryAsync(item);
            result.Add(s);
        }

        return result;
    }
}