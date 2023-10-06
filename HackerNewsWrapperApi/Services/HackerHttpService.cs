using HackerNewsWrapperApi.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsWrapperApi.Services;

public class HackerHttpService : IHackerHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;

    public HackerHttpService(HttpClient httpClient, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
    }

    public async Task<List<int>> GetStoryIdAsync()
    {
        if (_cache.TryGetValue<List<int>>(Constans.BestId, out var value))
        {
            return value ?? new List<int>();
        }

        var response = await _httpClient.GetFromJsonAsync<List<int>>(Constans.Url);
        _cache.Set(Constans.BestId, response, TimeSpan.FromMinutes(5));
        return response ?? new List<int>();
    }
}