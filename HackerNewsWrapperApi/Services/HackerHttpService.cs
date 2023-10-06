using HackerNewsWrapperApi.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsWrapperApi.Services;

public class HackerHttpService: IHackerHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;

    public HackerHttpService(HttpClient httpClient, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
    }

    public async Task<List<int>> CacheIdAsync()
    {
        var storyId = await GetStoryIdAsync();
        _cache.Set<List<int>>(Constans.BestId, storyId, TimeSpan.FromMinutes(5));
        return storyId;
    }

    public async Task<List<int>> GetStoryIdAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<int>>(Constans.Url);
        return response ?? new List<int>();
    }
}