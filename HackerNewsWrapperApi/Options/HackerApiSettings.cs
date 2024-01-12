namespace HackerNewsWrapperApi.Options;

public class HackerApiSettings
{
    public string? Url { get; set; }
    public Dictionary<string, string>? Paths { get; set; }
}

public class Path
{
    public string? Ids { get; set; }
    public string? Item { get; set; }
}