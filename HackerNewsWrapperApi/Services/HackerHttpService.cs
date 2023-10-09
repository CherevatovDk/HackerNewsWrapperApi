using HackerNewsWrapperApi.Dtos;
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

    private async Task<List<int>> GetStoryIdAsync()
    {
        if (_cache.TryGetValue<List<int>>(Constans.BestId, out var value))
        {
            return value ?? new List<int>();
        }

        var response = await _httpClient.GetFromJsonAsync<List<int>>(_configuration["MySettings:ApiUrl"]);
        _cache.Set(Constans.BestId, response, TimeSpan.FromMinutes(5));
        return response ?? new List<int>();
    }

    private async Task<StoryDto> GetStoryDetailsAsync(int id)
    {
        if (_cache.TryGetValue<StoryDto>(id, out var value))
        {
            return value ?? new StoryDto();
        }

        var response =
            await _httpClient.GetFromJsonAsync<StoryDto>($"{_configuration["MySettings:BestApiUrl"]}{id}.json");
        _cache.Set(id, response, TimeSpan.FromMinutes(5));
        return response ?? new StoryDto();
    }

    public async Task<List<StoryDto>> SortingStoryAsync(int count)
    {
        var listValueDetail = new List<StoryDto>();
        var ids = await GetStoryIdAsync();
        foreach (var item in ids.Take(count))
        {
            var detail = await GetStoryDetailsAsync(item);
            listValueDetail.Add(detail);
        }

        return listValueDetail.OrderByDescending(s => s.Score).ToList();
    }
    
    
}