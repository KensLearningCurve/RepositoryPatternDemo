using RepositoryPatternDemo.Domain.Entities;
using RepositoryPatternDemo.Domain.Interfaces;

namespace RepositoryPatternDemo.Business;

public class GenreService : IGenreService
{
    private readonly DataContext context;

    public GenreService(DataContext context)
    {
        this.context=context;
    }

    public void Create(Genre genre)
    {
        if (genre==null) throw new ArgumentNullException(nameof(genre));

        context.Genres.Add(genre);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

        Genre found = context?.Genres.SingleOrDefault(x => x.Id == id) ?? throw new Exception("Can't find genre to delete");

        context.Genres.Remove(found);
        context.SaveChanges();
    }
}
