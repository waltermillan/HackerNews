using HackerNews.Core.Entities;
using HackerNews.Core.Interfaces;
using HackerNews.Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;

namespace HackerNews.Infrastructure.Repositories;

public class HackerNewsRepository : IStoryRepository
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "BestStoriesIds";

    public HackerNewsRepository(HttpClient httpClient, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
    }

    public async Task<IEnumerable<Story>> GetBestStoriesAsync(int count)
    {
        var storyIds = await _cache.GetOrCreateAsync(CacheKey, entry => {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return _httpClient.GetFromJsonAsync<List<int>>("beststories.json");
        });

        if (storyIds == null) return Enumerable.Empty<Story>();

        // Corregido: Ahora usamos HackerNewsItem (el nombre real del record)
        var tasks = storyIds.Take(count).Select(id =>
            _httpClient.GetFromJsonAsync<HackerNewsItem>($"item/{id}.json"));

        var results = await Task.WhenAll(tasks);

        return results
            .Where(x => x != null)
            .Select(item => new Story
            {
                // Corregido: Usamos las propiedades con mayúscula como en el record
                Title = item!.Title,
                Url = item.Url,
                Author = item.By,
                Score = item.Score,
                Time = item.Time,
                CommentCount = item.Descendants
            })
            .OrderByDescending(s => s.Score);
    }
}