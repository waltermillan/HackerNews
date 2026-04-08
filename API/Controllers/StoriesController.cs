using HackerNews.API.Dtos;
using HackerNews.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackerNews.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
    private readonly IStoryRepository _repository;

    public StoriesController(IStoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("best/{n}")]
    public async Task<ActionResult<IEnumerable<StoryDto>>> GetBestStories(int n)
    {
        var stories = await _repository.GetBestStoriesAsync(n);

        // Entity mapping -> DTO
        var response = stories.Select(s => new StoryDto(
            s.Title,
            s.Url,
            s.Author,
            DateTimeOffset.FromUnixTimeSeconds(s.Time),
            s.Score,
            s.CommentCount
        ));

        return Ok(response);
    }
}