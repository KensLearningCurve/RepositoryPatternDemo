using Moq;

namespace GenreServiceTests;

public class Delete: GenreServiceBase
{
    [Fact]
    public void Should_DeleteGenre()
    {
        classUnderTest.Delete(1);

        mockGenreRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void Should_ThowArgumentOutOfRangeException_When_IdIsInvalid(int id)
    {
        Action a = () => classUnderTest.Delete(id);

        Exception result = Assert.Throws<ArgumentOutOfRangeException>(a);

        Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'id')", result.Message);
    }
}
