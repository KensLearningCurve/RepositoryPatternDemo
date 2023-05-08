using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly DataContext dataContext;
    private bool disposed = false;

    public MovieRepository(DataContext dataContext)
    {
        this.dataContext=dataContext;
    }

    public void Create(Movie movie)
    {
        dataContext.Movies.Add(movie);
    }

    public void Delete(int id)
    {
        dataContext.Movies.Remove(Get(id));
    }

    public IQueryable<Movie> Get()
    {
        return dataContext.Movies;
    }

    public Movie? Get(int id)
    {
        return dataContext.Movies.Find(id); ;
    }

    public void Update(Movie movie)
    {
        dataContext.Entry(movie).State = EntityState.Modified;
    }

    public void SaveChanges()
    {
        dataContext.SaveChanges();
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
