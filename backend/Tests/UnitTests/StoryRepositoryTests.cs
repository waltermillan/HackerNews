using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;
using Microsoft.Extensions.Caching.Memory;
using HackerNews.Infrastructure.Repositories;
using HackerNews.Infrastructure.Models;

namespace HackerNews.Tests.UnitTests;

public class StoryRepositoryTests
{
    [Fact]
    public async Task GetBestStoriesAsync_ShouldReturnSortedStories()
    {
        // --- ARRANGE (Preparación) ---
        var handlerMock = new Mock<HttpMessageHandler>();

        var idsJson = JsonSerializer.Serialize(new List<int> { 1, 2 });

        var item1Json = JsonSerializer.Serialize(new { title = "Story 1", score = 100, by = "user1" });
        var item2Json = JsonSerializer.Serialize(new { title = "Story 2", score = 200, by = "user2" });

        handlerMock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(idsJson) })
            .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(item1Json) })
            .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(item2Json) });

        var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var repository = new HackerNewsRepository(httpClient, memoryCache);

        // --- ACT (Ejecución) ---
        var result = (await repository.GetBestStoriesAsync(2)).ToList();

        // --- ASSERT (Verificación) ---
        Assert.Equal(2, result.Count);
        Assert.Equal("Story 2", result[0].Title);
        Assert.Equal(200, result[0].Score);
        Assert.Equal("Story 1", result[1].Title);
    }
}