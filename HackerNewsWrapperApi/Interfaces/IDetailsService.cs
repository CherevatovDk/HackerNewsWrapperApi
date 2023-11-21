using HackerNewsWrapperApi.Models.Dtos;

namespace HackerNewsWrapperApi.Interfaces;

public interface IDetailsService
{
    public Task<List<StoryDto>> GetSortedStoryAsync(int count);
}