using HackerNewsWrapperApi.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Timer = System.Timers.Timer;

namespace HackerNewsWrapperApi.Services;

public class CacheService:ICacheService
{
    private readonly IMemoryCache _memoryCache;
    private readonly HackerHttpService _hackerHttpService;

    public CacheService(IMemoryCache memoryCache, HackerHttpService hackerHttpService)
    {
        _memoryCache = memoryCache;
        _hackerHttpService = hackerHttpService;
    }


    public async Task<List<int>> AddInCache()
    {
        var respons = _hackerHttpService.GetStorie();
        var ids =await _memoryCache.Set("id", respons, TimeSpan.FromMinutes(5));
        return ids;

    }
}