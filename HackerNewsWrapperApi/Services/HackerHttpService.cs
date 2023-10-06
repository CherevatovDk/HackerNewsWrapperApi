using HackerNewsWrapperApi.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsWrapperApi.Services;

public class HackerHttpService : IHackerHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;

    public HackerHttpService(HttpClient httpClient, IMemoryCache cache, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _cache = cache;
        _configuration = configuration;
    }

    public async Task<List<int>> GetStoryIdAsync()
    {
        if (_cache.TryGetValue<List<int>>(Constans.BestId, out var value))
        {
            return value ?? new List<int>();
        }

        var response = await _httpClient.GetFromJsonAsync<List<int>>(_configuration["MySettings:ApiUrl"]);
        _cache.Set(Constans.BestId, response, TimeSpan.FromMinutes(5));
        return response ?? new List<int>();
    }
}