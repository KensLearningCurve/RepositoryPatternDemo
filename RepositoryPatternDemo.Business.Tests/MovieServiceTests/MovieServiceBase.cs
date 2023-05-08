using Moq;
using RepositoryPatternDemo.Business;
using RepositoryPatternDemo.Business.Repositories;

namespace MovieServiceTests;

public class MovieServiceBase
{
    public Mock<IGenreRepository> mockGenreRepository;
    public Mock<IMovieRepository> mockMovieRepository;
    public MovieService classUnderTest;

    public MovieServiceBase()
    {
        mockGenreRepository = new();
        mockMovieRepository = new();

        classUnderTest = new(mockMovieRepository.Object, mockGenreRepository.Object);
    }
}
