using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Business;
using RepositoryPatternDemo.Domain.Entities;
using RepositoryPatternDemo.Domain.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuring the data context with the connection string from the 
// appsettings.
string sqlConnectionString = builder.Configuration["ConnectionStrings:Default"] ?? throw new Exception("Connection string not found");
builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(sqlConnectionString),
                ServiceLifetime.Transient);

// Configuring the dependency injection
builder.Services.AddScoped<IMovieService, MovieService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configuring the mappings
app.MapGet("api/Movies", (IMovieService movieService) =>
{
    return Results.Ok(movieService.Get());
});

app.MapPost("api/Movies", (Movie movie, IMovieService movieService) =>
{
    try
    {
        movieService.Create(movie);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPut("api/Movies", (Movie movie, IMovieService movieService) =>
{
    try
    {
        movieService.Update(movie);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapDelete("api/Movies/{id:int}", (int id, IMovieService movieService) =>
{
    try
    {
        movieService.Delete(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPost("api/Genres", (Genre genre, IGenreService genreService) =>
{
    try
    {
        genreService.Create(genre);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapDelete("api/Genres/{id:int}", (int id, IGenreService genreService) =>
{
    try
    {
        genreService.Delete(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.Run();