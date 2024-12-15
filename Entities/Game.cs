namespace gamedev.Entities;

public class Game
{
    public int Id { get; init; }
    public required string Name { get; init; } = string.Empty;
    public required string GenreId { get; init; } = string.Empty;
    public required Genre? Genre { get; init; }
    public decimal Price { get; init; }
    public DateOnly ReleaseDate { get; init; }
}