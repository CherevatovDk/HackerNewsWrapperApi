using HackerNewsWrapperApi.Dtos;

namespace HackerNewsWrapperApi.Interfaces;

public interface IDetailsService
{
    public Task<List<StoryDto>> GetStoryDetailsAsync();
}