namespace HackerNews.Infrastructure.Models;

internal record HackerNewsItem(
    string Title,
    string Url,
    string By,
    long Time,
    int Score,
    int Descendants
);