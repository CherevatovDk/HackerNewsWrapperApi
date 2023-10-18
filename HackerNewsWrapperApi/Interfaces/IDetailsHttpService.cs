using HackerNewsWrapperApi.Dtos;

namespace HackerNewsWrapperApi.Interfaces;

public interface IDetailsHttpService
{
    public Task<List<StoryDto>> GetStoryDetailsAsync();
}