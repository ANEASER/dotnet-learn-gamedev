using System.ComponentModel.DataAnnotations;

namespace gamedev.Dtos;

public record class CreateGameDto
(
        [Required][StringLength(50)] string Name, 
        [Required][StringLength(150)] string Genre, 
        [Range(1,100)] decimal Price, 
        DateOnly ReleaseDate
);
