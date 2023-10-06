using HackerNewsWrapperApi.Dtos;

namespace HackerNewsWrapperApi.Interface;

public interface IHackerHttpService
{
    public Task<List<StoryDto>> GetAll(int storiesCount);
}