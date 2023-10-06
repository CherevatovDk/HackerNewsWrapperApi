using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json;

namespace HackerNewsWrapperApi.Dtos;

public class StoryDto
{
    public string by { get; set; }
    public int descendants { get; set; }
    public int id { get; set; }
    public List<int> kids { get; set; }
    public int score { get; set; }
    public long time { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public string url { get; set; }
}