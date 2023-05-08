using Moq;
using RepositoryPatternDemo.Domain.Entities;

namespace MovieServiceTests
{
    public class Update : MovieServiceBase
    {
        [Fact]
        public void Should_UpdateMovie()
        {
            classUnderTest.Update(new Movie()
            {
                GenreId = 1,
                Id = 1,
                ReleaseDate = DateTime.Now.ToShortDateString(),
                Title = "Testing"
            });

            mockMovieRepository.Verify(x => x.Update(It.IsAny<Movie>()), Times.Once());
        }
    }
}
