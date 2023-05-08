using Moq;

namespace MovieServiceTests;
public class Delete : MovieServiceBase
{
    [Fact]
    public void Should_DeleteMovie()
    {
        classUnderTest.Delete(1);

        mockMovieRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
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
