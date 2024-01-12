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

    private async Task<List<StoryDto>> GetStoryDetailsAsync(int count)
    {
        var result = new List<StoryDto>();
        var ids = await _hackerHttpService.StoryIdsAsync();
        foreach (var item in ids.Take(count))
        {
            var s = await _hackerHttpService.DetailsStoryAsync(item);
            result.Add(s);
        }

        return result;
    }

    public async Task<List<StoryDto>> GetSortedStoryAsync(int count)
    {
        var storyDetails = await GetStoryDetailsAsync(count);
        return storyDetails.OrderByDescending(s => s.Score).ToList();
    }
}