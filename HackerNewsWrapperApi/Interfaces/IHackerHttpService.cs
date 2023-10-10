using HackerNewsWrapperApi.Dtos;

namespace HackerNewsWrapperApi.Interfaces;

public interface IHackerHttpService
{
    public Task<List<int>> GetStoryIdsAsync();
    public Task<StoryDto> GetDetailsAsync();
}