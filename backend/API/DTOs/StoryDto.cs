using System.Text.Json.Serialization;

namespace HackerNews.API.Dtos;

public record StoryDto(
    string Title,
    [property: JsonPropertyName("uri")] string Uri,
    [property: JsonPropertyName("postedBy")] string PostedBy,
    DateTimeOffset Time,
    int Score,
    int CommentCount
);