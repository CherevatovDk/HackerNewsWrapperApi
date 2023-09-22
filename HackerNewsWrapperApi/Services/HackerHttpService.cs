using HackerNewsWrapperApi.Dtos;
using HackerNewsWrapperApi.Interfaces;


namespace HackerNewsWrapperApi.Services;

public class HackerHttpService : IHackerHttpService
{
    private readonly HttpClient _httpClient;

    private readonly CacheService _cacheService;

    public HackerHttpService(HttpClient httpClient)
    {
       
        _httpClient = httpClient;
       

    }
    
    public async Task<List<int>> GetStorie()
    {
        var response = await _httpClient.GetFromJsonAsync<List<int>>("https://hacker-news.firebaseio.com/v0/beststories.json ");
        return response;
    }

  

    
}