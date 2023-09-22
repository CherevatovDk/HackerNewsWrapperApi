namespace HackerNewsWrapperApi.Interfaces;

public interface ICacheService
{
    public Task<List<int>> AddInCache();
}