using Moq;
using RepositoryPatternDemo.Business;
using RepositoryPatternDemo.Business.Repositories;

namespace GenreServiceTests;

public class GenreServiceBase
{
    public Mock<IGenreRepository> mockGenreRepository;
    public GenreService classUnderTest;

    public GenreServiceBase()
    {
        mockGenreRepository = new Mock<IGenreRepository>();
        classUnderTest = new(mockGenreRepository.Object);
    }
}
