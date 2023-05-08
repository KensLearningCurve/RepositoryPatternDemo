using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Repositories;

public interface IMovieRepository: IDisposable
{
    void Create(Movie movie);
    IQueryable<Movie> Get();
    Movie? Get(int id);
    void Update(Movie movie);
    void Delete(int id);
    void SaveChanges();
}
