using HackerNewsWrapperApi.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsWrapperApi.Services;

public class HackerHttpService : IHackerHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;

    public HackerHttpService(HttpClient httpClient, IMemoryCache cache)
    {
        _cache = cache;
        _httpClient = httpClient;
    }

    public async Task<List<int>> GetStorie(int storiesCount)
    {
        var response = await _httpClient.GetFromJsonAsync<List<int>>("https://hacker-news.firebaseio.com/v0/beststories.json ");
        var ids = _cache.Set("id", response, TimeSpan.FromMinutes(5));
        return ids;
    }
    
}