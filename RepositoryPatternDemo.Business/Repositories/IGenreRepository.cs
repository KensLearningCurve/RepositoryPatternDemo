using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Repositories;

public interface IGenreRepository: IDisposable
{
    void Create(Genre movie);
    IQueryable<Genre> Get();
    Genre? Get(int id);
    void Update(Genre movie);
    void Delete(int id);
}
