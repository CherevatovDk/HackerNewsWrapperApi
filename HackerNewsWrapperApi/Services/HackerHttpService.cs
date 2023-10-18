using System.Text;
using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;
using HackerNewsWrapperApi.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace HackerNewsWrapperApi.Services;

public class HackerHttpService : IHackerHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private readonly HackerApiSettings _hackerApiSettings;

    public HackerHttpService(HttpClient httpClient, IMemoryCache cache, IOptions<HackerApiSettings> hackerApiSettings)
    {
        _httpClient = httpClient;
        _cache = cache;
        _hackerApiSettings = hackerApiSettings.Value;
    }

    public async Task<List<int>> GetStoryIdsAsync()
    {
        if (_cache.TryGetValue<List<int>>(Constans.BestIds, out var value))
        {
            return value ?? new List<int>();
        }

        var response = await _httpClient.GetFromJsonAsync<List<int>>(_hackerApiSettings.GetIdsUrl());
        _cache.Set(Constans.BestIds, response, TimeSpan.FromMinutes(5));
        return response ?? new List<int>();
    }
}