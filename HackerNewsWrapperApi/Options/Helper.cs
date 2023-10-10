namespace HackerNewsWrapperApi.Options;

public static class Helper
{
    
    public static string GetIdsUrl(this HackerApiSettings settings)
    {
        if (settings == null || string.IsNullOrEmpty(settings.Url) || settings.Paths == null)
        {
            throw new ArgumentNullException("Invalid HackerApiSettings");
        }

        var idsPath = settings.Paths.FirstOrDefault(p => !string.IsNullOrEmpty(p.Ids));

        if (idsPath == null)
        {
            throw new InvalidOperationException("Ids path not found in HackerApiSettings");
        }

        return $"{settings.Url}{idsPath.Ids}";
    }

    public static string GetItemUrl(this HackerApiSettings settings, string itemId)
    {
        if (settings == null || string.IsNullOrEmpty(settings.Url) || settings.Paths == null)
        {
            throw new ArgumentNullException("Invalid HackerApiSettings");
        }

        var itemPath = settings.Paths.FirstOrDefault(p => !string.IsNullOrEmpty(p.Item));

        if (itemPath == null)
        {
            throw new InvalidOperationException("Item path not found in HackerApiSettings");
        }

        return $"{settings.Url}{itemPath.Item}{itemId}.json";
    }
    
    
    
}