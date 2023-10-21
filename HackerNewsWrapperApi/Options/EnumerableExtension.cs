using HackerNewsWrapperApi.Dtos;

namespace HackerNewsWrapperApi.Options;

public static class EnumerableExtension
{
    public static async Task<List<TResult>> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, Task<TResult>> selector)
    {
        var tasks = await Task.WhenAll(source.Select(s => selector(s)));
        return  tasks.Where(result => result != null).ToList();;
    }
}