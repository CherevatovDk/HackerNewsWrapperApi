using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using HackerNewsWrapperApi.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace HackerNewsWrapperApi.Services;

public class DetailsHttpService : IDetailsHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private readonly HackerApiSettings _hackerApiSettings;
    private readonly HackerHttpService _hackerHttpService;

    public DetailsHttpService(HttpClient httpClient, IMemoryCache cache, IOptions<HackerApiSettings> hackerApiSettings,
        HackerHttpService hackerHttpService)
    {
        _cache = cache;
        _httpClient = httpClient;
        _hackerApiSettings = hackerApiSettings.Value;
        _hackerHttpService = hackerHttpService;
    }

    private async Task<StoryDto> DetailsStoyAsync(int itemId)
    {
        if (_cache.TryGetValue<StoryDto>(Constans.BestIds, out var value))
        {
            return value ?? new StoryDto();
        }

        var response = await _httpClient.GetFromJsonAsync<StoryDto>(_hackerApiSettings.GetItemUrl(itemId));
        _cache.Set(Constans.BestIds, response, TimeSpan.FromMinutes(5));
        return response ?? new StoryDto();
    }

    public async Task<List<StoryDto>> GetStoryDetailsAsync()
    {
        var ids = await _hackerHttpService.GetStoryIdsAsync();
        var details = new List<StoryDto>();
        foreach (var item in ids)
        {
            var st = await DetailsStoyAsync(item);
            details.Add(st);
        }

        return details;
    }
}