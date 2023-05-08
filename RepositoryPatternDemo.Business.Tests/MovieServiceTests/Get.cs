using RepositoryPatternDemo.Domain.Entities;

namespace MovieServiceTests
{
    public class Get : MovieServiceBase
    {
        [Fact]
        public void Should_ReturnFiveMovies()
        {
            mockMovieRepository.Setup(x => x.Get()).Returns(new List<Movie>
            {
                new Movie { Id = 1 },
                new Movie { Id = 2 },
                new Movie { Id = 3 },
                new Movie { Id = 4 },
                new Movie { Id = 5 },
            }.AsQueryable);

            List<Movie> result = classUnderTest.Get().ToList();

            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void Should_ReturnSingleMovie()
        {
            string expected = "Movie2";
            mockMovieRepository.Setup(x => x.Get()).Returns(new List<Movie>
            {
                new Movie { Id = 1,Title="Movie1" },
                new Movie { Id = 2,Title="Movie2" },
                new Movie { Id = 3,Title="Movie3" },
                new Movie { Id = 4,Title="Movie4" },
                new Movie { Id = 5,Title="Movie5" },
            }.AsQueryable);

            Movie? result = classUnderTest.Get(2);

            Assert.Equal(expected, result.Title);
        }

        [Fact]
        public void Should_ReturnNull_When_MovieIsNotFound()
        {
            Movie? result = classUnderTest.Get(2);

            Assert.Null(result);
        }

        [Fact]
        public void Should_ReturnOneMovie_When_QueryIsEntered()
        {
            mockMovieRepository.Setup(x => x.Get()).Returns(new List<Movie>
            {
                new Movie { Id = 1,Title="Movie1" },
                new Movie { Id = 2,Title="Movie2" },
                new Movie { Id = 3,Title="Movie3" },
                new Movie { Id = 4,Title="Movie4" },
                new Movie { Id = 5,Title="Movie5" },
            }.AsQueryable);

            List<Movie> result = classUnderTest.Get("ie2").ToList();

            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void Should_ReturnZeroMovies_When_QueryIsEntered()
        {
            mockMovieRepository.Setup(x => x.Get()).Returns(new List<Movie>
            {
                new Movie { Id = 1,Title="Movie1" },
                new Movie { Id = 2,Title="Movie2" },
                new Movie { Id = 3,Title="Movie3" },
                new Movie { Id = 4,Title="Movie4" },
                new Movie { Id = 5,Title="Movie5" },
            }.AsQueryable);

            List<Movie> result = classUnderTest.Get("shrek").ToList();

            Assert.Equal(0, result.Count);
        }
    }
}
