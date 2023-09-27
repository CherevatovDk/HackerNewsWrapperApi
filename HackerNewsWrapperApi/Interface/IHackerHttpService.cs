namespace HackerNewsWrapperApi.Interface;

public interface IHackerHttpService
{
    public Task<List<int>> GetStory(int storiesCount);
}