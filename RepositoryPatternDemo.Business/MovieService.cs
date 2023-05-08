using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Business.Repositories;
using RepositoryPatternDemo.Domain.Entities;
using RepositoryPatternDemo.Domain.Interfaces;

namespace RepositoryPatternDemo.Business;

public class MovieService : IMovieService
{
    private readonly IMovieRepository movieRepository;
    private readonly IGenreRepository genreRepository;

    public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
    {
        this.movieRepository=movieRepository;
        this.genreRepository=genreRepository;
    }

    public void Create(Movie movie)
    {
        if (movie==null) throw new ArgumentNullException(nameof(movie));

        Genre selectedGenre = genreRepository.Get(movie.GenreId) ?? throw new Exception("Genre not found");

        movie.Genre = selectedGenre;

        movieRepository.Create(movie);
        movieRepository.SaveChanges();
    }

    public void Delete(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

        movieRepository.Delete(id);
        movieRepository.SaveChanges();
    }

    public Movie? Get(int id) => movieRepository.Get().Include(x => x.Genre).SingleOrDefault(x => x.Id == id) ?? null;

    public IEnumerable<Movie> Get() => movieRepository.Get();

    public IEnumerable<Movie> Get(string query) => movieRepository.Get().Include(x => x.Genre).Where(x => x.Title.Contains(query));

    public void Update(Movie movie)
    {
        movieRepository.Update(movie);
        movieRepository.SaveChanges();
    }
}
