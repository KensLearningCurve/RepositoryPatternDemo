using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly DataContext dataContext;
    private bool disposed = false;

    public GenreRepository(DataContext dataContext)
    {
        this.dataContext=dataContext;
    }

    public void Create(Genre genre)
    {
        dataContext.Genres.Add(genre);
    }

    public void Delete(int id)
    {
        dataContext.Genres.Remove(Get(id));
    }

    public IQueryable<Genre> Get()
    {
        return dataContext.Genres;
    }

    public Genre? Get(int id)
    {
        return dataContext.Genres.Find(id); ;
    }

    public void Update(Genre genre)
    {
        dataContext.Entry(genre).State = EntityState.Modified;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
            if (disposing)
                dataContext.Dispose();

        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
