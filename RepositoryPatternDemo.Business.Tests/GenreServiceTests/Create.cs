using Moq;
using RepositoryPatternDemo.Domain.Entities;

namespace GenreServiceTests;

public class Create : GenreServiceBase
{
    [Fact]
    public void Should_ThrowArgumentNullException_When_MovieIsNull()
    {
        Action a = () => classUnderTest.Create(null);

        Exception result = Assert.Throws<ArgumentNullException>(a);

        Assert.Equal("Value cannot be null. (Parameter 'genre')", result.Message);
    }

    [Fact]
    public void Should_CreateTheGenre()
    {
        classUnderTest.Create(new Genre
        {
            Name=  "Testing",
        });

        mockGenreRepository.Verify(x => x.Create(It.IsAny<Genre>()), Times.Once());
    }
}
