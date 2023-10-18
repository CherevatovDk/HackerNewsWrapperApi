namespace HackerNewsWrapperApi.Options;

public static class Helper
{
    public static string GetIdsUrl(this HackerApiSettings settings)
    {
        if (settings == null || string.IsNullOrEmpty(settings.Url) || settings.Paths == null)
        {
            throw new ArgumentNullException("Invalid HackerApiSettings");
        }

        if (settings.Paths.TryGetValue("Ids", out string? idsPath) && !string.IsNullOrEmpty(idsPath))
        {
            throw new InvalidOperationException("Ids path not found in HackerApiSettings");
        }

        return $"{settings.Url}{idsPath}";
    }

    public static string GetItemUrl(this HackerApiSettings settings, string itemId)
    {
        if (settings == null || string.IsNullOrEmpty(settings.Url) || settings.Paths == null)
        {
            throw new ArgumentNullException("Invalid HackerApiSettings");
        }

        if (settings.Paths.TryGetValue("Item", out string? itemPath) && !string.IsNullOrEmpty(itemPath))
        {
            throw new InvalidOperationException("Item path not found in HackerApiSettings");
        }

        return $"{settings.Url}{itemPath}{itemId}.json";
    }
}