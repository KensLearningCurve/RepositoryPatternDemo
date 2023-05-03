using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Domain.Interfaces;

public interface IGenreService
{
    void Create(Genre genre);
    void Delete(int id);
}
