namespace HackerNewsWrapperApi.Interfaces;

public interface IHackerHttpService
{
    public Task<List<int>> GetStoryIdAsync();
}