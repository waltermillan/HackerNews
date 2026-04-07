namespace HackerNews.Core.Entities;

public class Story
{
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public long Time { get; set; }
    public int Score { get; set; }
    public int CommentCount { get; set; }
}