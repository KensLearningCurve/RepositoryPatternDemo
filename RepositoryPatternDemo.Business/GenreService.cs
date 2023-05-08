using RepositoryPatternDemo.Business.Repositories;
using RepositoryPatternDemo.Domain.Entities;
using RepositoryPatternDemo.Domain.Interfaces;

namespace RepositoryPatternDemo.Business;

public class GenreService : IGenreService
{
    private readonly IGenreRepository genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        this.genreRepository=genreRepository;
    }

    public void Create(Genre genre)
    {
        if (genre==null) throw new ArgumentNullException(nameof(genre));

        genreRepository.Create(genre);
        genreRepository.SaveChanges();
    }

    public void Delete(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

        Genre found = context?.Genres.SingleOrDefault(x => x.Id == id) ?? throw new Exception("Can't find genre to delete");

        context.Genres.Remove(found);
        context.SaveChanges();
    }
}
