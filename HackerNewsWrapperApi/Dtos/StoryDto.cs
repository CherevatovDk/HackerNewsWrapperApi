using Newtonsoft.Json;

namespace HackerNewsWrapperApi.Dtos;

public class StoryDto
{
    [JsonProperty("by")] 
    public string? By { get; set; }
    
    [JsonProperty("title")] 
    public string? Title { get; set; }
    
    [JsonProperty("descendants")] 
    public int Descendants { get; set; }
    
    [JsonProperty("id")] 
    public int Id { get; set; }
    
    [JsonProperty("kids")] 
    public List<int>? Kids { get; set; }
    
    [JsonProperty("type")]
    public string? Type { get; set; }
    
    [JsonProperty("url")] 
    public string? Url { get; set; }
    
    [JsonProperty("postedBy")] 
    public string? PostedBy { get; set; }
    
    [JsonProperty("time")] 
    public long Time { get; set; }
    
    [JsonProperty("score")] 
    public int Score { get; set; }
    
    [JsonProperty("commentCount")] 
    public int CommentCount { get; set; }
}