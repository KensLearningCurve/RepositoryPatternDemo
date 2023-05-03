using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Domain.Interfaces;

public interface IMovieService
{
    Movie? Get(int id);
    IEnumerable<Movie> Get();
    IEnumerable<Movie> Get(string query);
    void Create(Movie movie);
    void Update(Movie movie);
    void Delete(int id);
}
