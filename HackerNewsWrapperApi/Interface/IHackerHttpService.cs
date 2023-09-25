namespace HackerNewsWrapperApi.Interface;

public interface IHackerHttpService
{
    public Task<List<int>> GetStorie(int storiesCount);
}