using HackerNews.Core.Entities;

namespace HackerNews.Core.Interfaces;

public interface IStoryRepository
{
    // Ahora la interfaz devuelve objetos de dominio reales
    Task<IEnumerable<Story>> GetBestStoriesAsync(int count);
}