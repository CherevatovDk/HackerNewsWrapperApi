using Newtonsoft.Json;

namespace HackerNewsWrapperApi.Dtos;

public class StoryDto
{
    [JsonProperty("title")] 
    public string? Title { get; set; } 
    
    [JsonProperty("uri")]
    public string? Uri { get; set; }
    
    [JsonProperty("postedBy")]
    public string? PostedBy { get; set; }
    
    [JsonProperty("time")]
    public DateTime Time { get; set; }

    [JsonProperty("score")]
    public int Score { get; set; }

    [JsonProperty("commentCount")]
    public int CommentCount { get; set; }
}