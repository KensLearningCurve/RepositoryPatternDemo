using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternDemo.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string ReleaseDate { get; set; }
    [Required]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
