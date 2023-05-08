using Moq;
using RepositoryPatternDemo.Business.Repositories;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Tests.MovieServiceTests
{
    public class Get
    {
        [Fact]
        public void Should_ReturnFiveMovies()
        {
            Mock<IGenreRepository> mockGenreRepository = new();
            Mock<IMovieRepository> mockMovieRepository = new();

            mockMovieRepository.Setup(x => x.Get()).Returns(new List<Movie>
            {
                new Movie { Id = 1 },
                new Movie { Id = 2 },
                new Movie { Id = 3 },
                new Movie { Id = 4 },
                new Movie { Id = 5 },
            }.AsQueryable);

            MovieService classUnderTest = new(mockMovieRepository.Object, mockGenreRepository.Object);

            List<Movie> result = classUnderTest.Get().ToList();

            Assert.Equal(5, result.Count);
        }
    }
}
