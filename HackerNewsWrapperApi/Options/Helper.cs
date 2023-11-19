namespace HackerNewsWrapperApi.Options;

public static class Helper
{
    public static string GetIdsUrl(this HackerApiSettings? settings)
    {
        if (settings == null || string.IsNullOrEmpty(settings.Url) || settings.Paths == null)
        {
            return "Invalid HackerApiSettings";
        }

        if (!settings.Paths.TryGetValue("Ids", out string? idsPath) && !string.IsNullOrEmpty(idsPath))
        {
            return "Ids path not found in HackerApiSettings";
        }

        return $"{settings.Url}{idsPath}";
    }

    public static string GetItemUrl(this HackerApiSettings? settings, int itemId)
    {
        if (settings == null || string.IsNullOrEmpty(settings.Url) || settings.Paths == null)
        {
            return "Invalid HackerApiSettings";
        }

        if (!settings.Paths.TryGetValue("Item", out string? itemPath) && !string.IsNullOrEmpty(itemPath))
        {
            return "Item path not found in HackerApiSettings";
        }

        return $"{settings.Url}{itemPath}{itemId}.json";
    }
}