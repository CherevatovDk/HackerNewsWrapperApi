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
        var ids = await _hackerHttpService.StoryIdsAsync();
        return await ids.SelectAsync(async item => await _hackerHttpService.DetailsStoryAsync(item));
    }
}