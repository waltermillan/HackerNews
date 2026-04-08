using HackerNews.Core.Entities;

namespace HackerNews.Core.Interfaces;

public interface IStoryRepository
{
    Task<IEnumerable<Story>> GetBestStoriesAsync(int count);
}