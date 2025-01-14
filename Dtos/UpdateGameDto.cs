namespace gamedev.Dtos;

public record class UpdateGameDto(
        string Name, 
        string Genre, 
        decimal Price, 
        DateOnly ReleaseDate
    );