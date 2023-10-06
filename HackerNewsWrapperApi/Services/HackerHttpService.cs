using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsWrapperApi.Services;

public class HackerHttpService : IHackerHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;

    public HackerHttpService(HttpClient httpClient, IMemoryCache cache, IConfiguration configuration)
    {
        _cache = cache;
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<StoryDto>> GetAll(int storiesCount)
    {
        var ids = await GetStoryIdAsync();
        var storyDetailsId = new List<StoryDto>();
        foreach (var id in ids.Take(storiesCount))
        {
            if (_cache.TryGetValue<StoryDto>(id, out var value))
            {
                storyDetailsId.Add(value ?? new StoryDto());
            }
            else
            {
                var st = await GetStoryIdDetails(id);
                storyDetailsId.Add(st);
            }
        }

        storyDetailsId = storyDetailsId.OrderByDescending(s => s.score).ToList();
        return storyDetailsId;
    }

    private async Task<List<int>> GetStoryIdAsync()
    {
        if (_cache.TryGetValue<List<int>>(Constans.Id, out var value))
        {
            return value?? new List<int>();
        }

        var response = await _httpClient.GetFromJsonAsync<List<int>>(_configuration["MySettings:ApiUrl"]);
        _cache.Set(Constans.Id, response, TimeSpan.FromMinutes(5));
        return response ?? new List<int>();
    }

    private async Task<StoryDto> GetStoryIdDetails(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<StoryDto>($"{Constans.BestStoyUrl}{id}.json");
        _cache.Set(id, response, TimeSpan.FromMinutes(5));
        return response ?? new StoryDto();
    }
}