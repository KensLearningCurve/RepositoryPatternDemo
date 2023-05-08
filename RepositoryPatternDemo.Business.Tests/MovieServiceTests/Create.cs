using Moq;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Tests.MovieServiceTests;

public class Create : MovieServiceBase
{
    [Fact]
    public void Should_ThrowArgumentNullException_When_MovieIsNull()
    {
        Action a = () => classUnderTest.Create(null);

        Exception result = Assert.Throws<ArgumentNullException>(a);

        Assert.Equal("Value cannot be null. (Parameter 'movie')", result.Message);
    }

    [Fact]
    public void Should_ThrowException_When_GenreIsNotFound()
    {
        Action a = () => classUnderTest.Create(new Movie
        {
            Title = "Testing"
        });

        Exception result = Assert.Throws<Exception>(a);

        Assert.Equal("Genre not found", result.Message);
    }

    [Fact]
    public void Should_CreateTheMovie()
    {
        mockGenreRepository.Setup(x => x.Get(1)).Returns(new Genre
        {
            Id = 1,
            Name = "TestGenre"
        });

        classUnderTest.Create(new Movie
        {
            Title = "Testing",
            GenreId = 1
        });

        mockMovieRepository.Verify(x => x.Create(It.IsAny<Movie>()), Times.Once());
    }

}
