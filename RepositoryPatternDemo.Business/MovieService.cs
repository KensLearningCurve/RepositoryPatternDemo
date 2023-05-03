using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Domain.Entities;
using RepositoryPatternDemo.Domain.Interfaces;

namespace RepositoryPatternDemo.Business;

public class MovieService : IMovieService
{
    private readonly DataContext context;

    public MovieService(DataContext context)
    {
        this.context=context;
    }

    public void Create(Movie movie)
    {
        if (movie==null) throw new ArgumentNullException(nameof(movie));

        Genre selectedGenre = context.Genres.SingleOrDefault(x => x.Id == movie.GenreId) ?? throw new Exception("Genre not found");

        movie.Genre = selectedGenre;

        context.Movies.Add(movie);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

        Movie found = context?.Movies.SingleOrDefault(x => x.Id == id) ?? throw new Exception("Can't find movie to delete");

        context.Movies.Remove(found);
        context.SaveChanges();
    }

    public Movie? Get(int id) => context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id) ?? null;

    public IEnumerable<Movie> Get() => context.Movies;

    public IEnumerable<Movie> Get(string query) => context.Movies.Include(x => x.Genre).Where(x => x.Title.Contains(query));

    public void Update(Movie movie)
    {
        Movie found = context?.Movies.SingleOrDefault(x => x.Id == movie.Id) ?? throw new Exception("Can't find movie to delete");
        Genre selectedGenre = context.Genres.SingleOrDefault(x => x.Id == movie.GenreId) ?? throw new Exception("Genre not found");

        found.Title = movie.Title;
        found.Genre = selectedGenre;
        found.ReleaseDate = movie.ReleaseDate;

        context.SaveChanges();
    }
}
