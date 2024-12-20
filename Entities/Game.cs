namespace gamedev.Entities;

public class Game
{
    public int Id { get; init; }
    public required string Name { get; init; } = string.Empty;
    public int GenreId { get; init; }
    public Genre? Genre { get; set; }
    public decimal Price { get; init; }
    public DateOnly ReleaseDate { get; init; }
}