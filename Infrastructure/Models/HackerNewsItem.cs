namespace HackerNews.Infrastructure.Models;

// Este es un modelo interno de la capa de infraestructura
internal record HackerNewsItem(
    string Title,
    string Url,
    string By,
    long Time,
    int Score,
    int Descendants
);