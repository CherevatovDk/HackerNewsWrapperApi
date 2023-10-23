using HackerNewsWrapperApi.Dtos;

namespace HackerNewsWrapperApi.Options;

public static class EnumerableExtension
{
    public static async Task<List<TResult>> SelectAsync<TSource, TResult>(this IEnumerable<TSource> sources,
        Func<TSource, Task<TResult>> selector)
    {
        var results = new List<TResult>();
        foreach (var item in sources)
        {
            TResult result = await selector(item);
            results.Add(result);
        }

        return results;
    }
}